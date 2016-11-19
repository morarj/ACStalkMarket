using AutoMapper;
using ACStalkMarket.Extensions;
using ACStalkMarket.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using ACStalkMarket.Dtos;

namespace ACStalkMarket.Controllers.API
{
    public class WeeksController : ApiController
    {
        private ApplicationDbContext _context;

        public WeeksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/weeks
        public IHttpActionResult GetMovies()
        {
            var weekQuery = _context.Weeks.Include(w => w.WeekPattern).
                    Where(w => w.PeopleId == Convert.ToInt32(User.Identity.GetPeopleId())).
                    OrderByDescending(w => w.StartingDate);

            return Ok(weekQuery.ToList().Select(Mapper.Map<Week, WeekDto>));
        }

        // PUT: /api/weeks/1
        [HttpPut]
        public IHttpActionResult FinishWeek(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var weekInDb = _context.Weeks.Single(w => w.Id == id);

            if (weekInDb == null)
                return NotFound();

            weekInDb.WeekActive = false;

            _context.SaveChanges();

            return Ok();
        }
    }
}
