using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {

        public string JobName { get; set; }
        public int EmployerID { get; set; }
        public List<SelectListItem> SelectedEmployers { get; set; }

        public Employer selectedemployer { get; set; }

        public List<Skill> SkillID { get; set; }
        public List<Skill> Skills { get; set; }
        public string[]  selectedSkills { get; set; }

        public AddJobViewModel()
        {
        
        }
        public void AddEmployer(Employer employer)
        {
            selectedemployer = employer;
        }
        public AddJobViewModel(List<Employer> Employers, List<Skill> listofskills)
        {
            SelectedEmployers = new List<SelectListItem>();
            foreach (var item in Employers)
            {
                SelectListItem obj = new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name

                };


                SelectedEmployers.Add(obj);


            }
            Skills = listofskills;
        }

        public AddJobViewModel(string[]selectedJobskillslist)
        {
            selectedSkills = selectedJobskillslist;

        }


    }
}
