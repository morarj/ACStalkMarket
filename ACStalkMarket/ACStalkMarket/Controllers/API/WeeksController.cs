using AutoMapper;
using ACStalkMarket.Extensions;
using ACStalkMarket.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

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
