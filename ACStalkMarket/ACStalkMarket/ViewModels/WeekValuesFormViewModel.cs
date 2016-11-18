using ACStalkMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACStalkMarket.ViewModels
{
    public class WeekValuesFormViewModel
    {
        public IEnumerable<WeekPattern> WeekPatterns { get; set; }

        public string SellingDateShort
        {
            get
            {
                var date = Week.SellingDate;

                if(date != null)
                {
                    var day = date.Value.ToString("dddd");
                    var time = date.Value.ToString(" tt", CultureInfo.InvariantCulture).ToUpper();
                    return string.Concat(day, time);
                }

                return null;
            }
        }

        public WeekValues WeekValues { get; set; }

        public Week Week { get; set; }

        public string Title
        {
            get
            {
                return WeekValues.Id == 0 ? "Nueva Semana" : "Editar Semana";
            }
        }
    }
}