using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Amaris.Models;

namespace Amaris.Controllers.Api
{
    public class StacksController : ApiController
    {
        private ApplicationDbContext _context;

        public StacksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/WebTechnologies
        public IHttpActionResult GetStacks(string query = null)
        {
            var stacksQuery = _context.Stacks;
            var quer = from stack in stacksQuery select stack;
            if (!String.IsNullOrWhiteSpace(query))
                quer = quer.Where(t => t.Name.Contains(query));

            return Ok(quer);

        }
    }
}
