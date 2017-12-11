using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Amaris.Models;
    

namespace Amaris.Controllers.Api
{
    public class WebTechnologiesController : ApiController
    {
        private ApplicationDbContext _context;

        public WebTechnologiesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/WebTechnologies
        public IHttpActionResult GetWebTechnologies(string query = null)
        {
            var techsQuery = _context.WebTechnologies;
            var quer = from tech in techsQuery select tech;
            if (!String.IsNullOrWhiteSpace(query))
                quer = quer.Where(t => t.Name.Contains(query));

            return Ok(quer);
           
        }


    }
}