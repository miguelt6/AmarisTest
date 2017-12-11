using Amaris.Models;
using Amaris.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;


namespace Amaris.Controllers.Api
{
    public class DevelopersController : ApiController
    {
        private ApplicationDbContext _context;

        public DevelopersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/developers
        public IHttpActionResult GetDevelopers()
        {
            var developers = _context.Developers
                .Include(d=>d.WebTechnologies)
                .Include(d=>d.Stacks);
            return Ok(developers);
        }

        // GET api/developers/5
        public IHttpActionResult GetDeveloper(int id)
        {
            var developer = _context.Developers
                .Include(d=>d.WebTechnologies)
                .Include(d=>d.Stacks)
                .SingleOrDefault(c => c.Id == id);

            if (developer == null)
                return NotFound();

            return Ok(developer);
        }

        // POST api/developers
        [HttpPost]
        public IHttpActionResult CreateDeveloper(Developer dev)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Developers.Add(dev);
            _context.SaveChanges();

            return Ok(dev);
        }

        // PUT api/developers/5
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Developer developer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var developerInDb = _context.Developers.SingleOrDefault(c => c.Id == id);
            if (developerInDb == null)
                return NotFound();

            developerInDb.FirstName = developer.FirstName;
            developerInDb.LastName = developer.LastName;
            developerInDb.Address = developer.Address;
            developerInDb.Email = developer.Email;
            developerInDb.Dob = developer.Dob;
            developerInDb.Comments = developer.Comments;
            developerInDb.YearsOfExperience = developer.YearsOfExperience;


            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/developer/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var developerInDb = _context.Developers.SingleOrDefault(c => c.Id == id);
            if (developerInDb == null)
                return NotFound();

            _context.Developers.Remove(developerInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
