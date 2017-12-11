using Amaris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Amaris.ViewModels;

namespace Amaris.Controllers
{
    public class DevelopersController : Controller
    {
        private ApplicationDbContext _context;

        public DevelopersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Developers
        public ActionResult Index()
        {
            return View(_context.Developers);
        }

        public ActionResult New()
        {
            var developer = new Developer();
            developer.WebTechnologies = new List<WebTechnology>();
            developer.Stacks = new List<Stack>();
            PopulateDeveloperCB(developer);
            return View("DeveloperForm",developer);
        }

        [HttpPost]
        public ActionResult Save(Developer dev, string[] selectedtechs, string[] selectedstacks)
        {
            if (!ModelState.IsValid)
            {
                if (selectedtechs == null || selectedstacks == null)
                {
                    return View("DeveloperForm", dev);
                }
                PopulateDeveloperCB(dev);
                return View("DeveloperForm", dev);
            }

            if(selectedtechs == null && selectedstacks == null)
            {
                ModelState.AddModelError("WebTechnologies", "You must select at least one Web Technology");
                ModelState.AddModelError("Stacks", "You must select at least one Web Technology");
                dev.WebTechnologies = new List<WebTechnology>();
                dev.Stacks = new List<Stack>();
                PopulateDeveloperCB(dev);
                return View("DeveloperForm", dev);
            }
            if (selectedtechs == null)
            {
                ModelState.AddModelError("WebTechnologies", "You must select at least one Stack");
                dev.WebTechnologies = new List<WebTechnology>();
                PopulateDeveloperCB(dev);
                return View("DeveloperForm", dev);
            }
            if(selectedstacks == null)
            {
                ModelState.AddModelError("Stacks", "You must select at least one Web Technology");
                dev.Stacks = new List<Stack>();
                PopulateDeveloperCB(dev);
                return View("DeveloperForm", dev);
            }

            //If a new Developer is being created
            if (dev.Id==0)
            {
                if (selectedstacks != null)
                {
                    dev.Stacks = new List<Stack>();
                    foreach (var st in selectedstacks)
                    {
                        var stackToAdd = _context.Stacks.Find(int.Parse(st));
                        dev.Stacks.Add(stackToAdd);
                    }
                }
                if (selectedtechs != null)
                {
                    dev.WebTechnologies = new List<WebTechnology>();
                    foreach (var te in selectedtechs)
                    {
                        var techToAdd = _context.WebTechnologies.Find(int.Parse(te));
                        dev.WebTechnologies.Add(techToAdd);
                    }
                }
                    _context.Developers.Add(dev);
            }
            //if an existing developer is being updated
            else
            {
                var developerInDb = _context.Developers
                    .Include(d => d.Stacks)
                    .Include(d => d.WebTechnologies)
                    .SingleOrDefault(d => d.Id == dev.Id);

                developerInDb.FirstName = dev.FirstName;
                developerInDb.LastName = dev.LastName;
                developerInDb.Address = dev.Address;
                developerInDb.Phone = dev.Phone;
                developerInDb.Dob = dev.Dob;
                developerInDb.Email = dev.Email;
                developerInDb.YearsOfExperience = dev.YearsOfExperience;
                developerInDb.Comments = dev.Comments;

                UpdateDeveloperCB(selectedtechs, selectedstacks, developerInDb);

            }
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            var developer = _context.Developers
                .Include(c => c.WebTechnologies)
                .Include(c => c.Stacks)
                .SingleOrDefault(c => c.Id == id);

            PopulateDeveloperCB(developer);

            if (developer == null)
                return HttpNotFound();

            return View("DeveloperForm",developer);
        }

        private void PopulateDeveloperCB(Developer dev)
        {
            var Techs = _context.WebTechnologies;
            var devtechs = new HashSet<int>(dev.WebTechnologies.Select(w => w.Id));
            var viewModel1 = new List<AssignedWebTechsToDeveloper>();
            foreach (var tech in Techs)
            {
                viewModel1.Add(new AssignedWebTechsToDeveloper
                {
                    WebTechId = tech.Id,
                    Name = tech.Name,
                    Assigned = devtechs.Contains(tech.Id)
                });
            }
            ViewBag.Techs = viewModel1;

            var Stacks = _context.Stacks;
            var devstacks = new HashSet<int>(dev.Stacks.Select(w => w.Id));
            var viewModel2 = new List<AssignedStacksToDeveloper>();
            foreach (var stack in Stacks)
            {
                viewModel2.Add(new AssignedStacksToDeveloper
                {
                    StackId = stack.Id,
                    Name = stack.Name,
                    Assigned = devstacks.Contains(stack.Id)
                });
            }
            ViewBag.Stacks = viewModel2;
        }

        private void UpdateDeveloperCB(string[] selectedtechs,string[] selectedstacks, Developer developerToUpdate)
        {
            //Update Web Technologies checkboxes
            if (selectedtechs == null)
            {
                developerToUpdate.WebTechnologies = new List<WebTechnology>();
                return;
            }
            var selectedTechsHS = new HashSet<string>(selectedtechs);
            var developerTechs = new HashSet<int>
                (developerToUpdate.WebTechnologies.Select(c => c.Id));
            foreach (var tech in _context.WebTechnologies)
            {
                if (selectedTechsHS.Contains(tech.Id.ToString()))
                {
                    if (!developerTechs.Contains(tech.Id))
                    {
                        developerToUpdate.WebTechnologies.Add(tech);
                    }
                }
                else
                {
                    if (developerTechs.Contains(tech.Id))
                    {
                        developerToUpdate.WebTechnologies.Remove(tech);
                    }
                }
            }

            //Update Stack checkboxes
            if (selectedstacks == null)
            {
                developerToUpdate.Stacks = new List<Stack>();
                return;
            }
            var selectedStacksHS = new HashSet<string>(selectedstacks);
            var developerStacks = new HashSet<int>
                (developerToUpdate.Stacks.Select(c => c.Id));
            foreach (var stack in _context.Stacks)
            {
                if (selectedStacksHS.Contains(stack.Id.ToString()))
                {
                    if (!developerStacks.Contains(stack.Id))
                    {
                        developerToUpdate.Stacks.Add(stack);
                    }
                }
                else
                {
                    if (developerStacks.Contains(stack.Id))
                    {
                        developerToUpdate.Stacks.Remove(stack);
                    }
                }
            }
        }
    }
}