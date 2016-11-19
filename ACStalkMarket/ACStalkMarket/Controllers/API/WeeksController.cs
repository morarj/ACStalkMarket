using ACStalkMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using ACStalkMarket.Extensions;

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
            return Ok();
        }
    }
}
