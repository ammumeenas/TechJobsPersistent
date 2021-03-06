﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Employer> Employerfromdatabase = context.Employers.ToList();
            List<Skill> Skillsfromdatabase = context.Skills.ToList();
            AddJobViewModel addJobViewModel = new AddJobViewModel(Employerfromdatabase,Skillsfromdatabase);

            return View(addJobViewModel);
        }

        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel)
        {
            if (ModelState.IsValid)
            {
                Job job = new Job()
                {
                    
                    Name = addJobViewModel.JobName,
                    EmployerId = addJobViewModel.EmployerID
                };

                job.JobSkills = new List<JobSkill>();
                foreach( string item in addJobViewModel.selectedSkills)
                {
                    JobSkill jobskill = new JobSkill()
                    {
                        SkillId = int.Parse(item),
                        JobId = job.Id

                    };
                    job.JobSkills.Add(jobskill);
                    context.Jobs.Add(job);
                    context.JobSkills.Add(jobskill);
                }
                context.SaveChanges();
                return Redirect("/");
            }
            else { 
            return View("AddJob", addJobViewModel);
            }
        }

            public IActionResult Detail(int id)
            {
                Job theJob = context.Jobs
                    .Include(j => j.Employer)
                    .Single(j => j.Id == id);

                List<JobSkill> jobSkills = context.JobSkills
                    .Where(js => js.JobId == id)
                    .Include(js => js.Skill)
                    .ToList();

                JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
                return View(viewModel);
            }
        
}    }





