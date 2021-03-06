﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> Employers = context.Employers.ToList();
            return View(Employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
               
                Employer employer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                context.Employers.Add(employer);
                context.SaveChanges();
                return Redirect("/Employer/Index/");

            }
            else
            {
                return View("Add");
            }
            
            

           
        }

        public IActionResult about (int id)
        {
            Employer findemployer = context.Employers.Single(e => e.Id == id);
            AddEmployerViewModel addemployerviewmodel = new AddEmployerViewModel(findemployer);
            return View("about",addemployerviewmodel);
        }
    }
}
