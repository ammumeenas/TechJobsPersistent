using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public Employer employer { get; set; }

        public AddEmployerViewModel() { 
        }

        public  AddEmployerViewModel(Employer FindEmployer)
        {
            employer = FindEmployer;


        }

    }
     
    
}
