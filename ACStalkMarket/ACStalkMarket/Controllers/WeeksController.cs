﻿using ACStalkMarket.Models;
using ACStalkMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACStalkMarket.Extensions;

namespace ACStalkMarket.Controllers
{
    public class WeeksController : Controller
    {
        private ApplicationDbContext _context;

        public WeeksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Weeks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Weeks/New
        public ActionResult New()
        {
            var personId = Convert.ToInt32(User.Identity.GetPeopleId());
            var town = _context.Towns.Single(p => p.PeopleId == personId);

            var viewModel = new WeekValuesFormViewModel()
            {
                WeekPatterns = _context.WeekPatterns.ToList(),
            };

            viewModel.WeekValues = new WeekValues();
            viewModel.Week = new Week()
            {
                PeopleId = personId,
                StartingDate = DateTime.Today,
                TownId = town.Id,
                WeekActive = true,
                WeekPatternId = StalkMarketPatterns.Default
            };

            return View("WeekValuesForm", viewModel);
        }

        // GET: Weeks/Edit
        public ActionResult Edit(int id)
        {
            var weekInDB = _context.Weeks.SingleOrDefault(w => w.Id == id);
            var weekValuesInDB = _context.WeekValues.SingleOrDefault(w => w.Id == weekInDB.WeekValuesId);

            if (weekInDB == null || weekValuesInDB == null)
                return HttpNotFound();

            var viewModel = new WeekValuesFormViewModel()
            {
                Week = weekInDB,
                WeekPatterns = _context.WeekPatterns.ToList(),
                WeekValues = weekValuesInDB
            };

            return View("WeekValuesForm", viewModel);
        }

        // POST: Weeks/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(WeekValuesFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("WeekValuesForm", viewModel);
            }

            if (viewModel.WeekValues.Id == 0)
            {
                _context.WeekValues.Add(viewModel.WeekValues);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }

                var week = new Week();
                week = viewModel.Week;
                week.WeekValuesId = viewModel.WeekValues.Id;
                week.CalculatePattern(viewModel.WeekValues);
                week.CalculateProfit();

                _context.Weeks.Add(week);
            }
            else
            {
                // For the FK
                viewModel.Week.WeekValuesId = viewModel.WeekValues.Id;

                viewModel.Week.CalculatePattern(viewModel.WeekValues);
                viewModel.Week.CalculateProfit();

                var weekValuesInDB = _context.WeekValues.Single(w => w.Id == viewModel.WeekValues.Id);
                var weekInDB = _context.Weeks.Single(w => w.Id == viewModel.Week.Id);

                weekValuesInDB.Map(viewModel.WeekValues);
                weekInDB.Map(viewModel.Week);
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Weeks");
        }
    }
}