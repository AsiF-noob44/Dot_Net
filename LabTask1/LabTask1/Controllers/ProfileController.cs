using Microsoft.AspNetCore.Mvc;
using LabTask1.Models;
using System.Collections.Generic;

namespace LabTask1.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Education()
        {
            var educationList = new List<Education>
            {
                new() { Degree = "BSc in Computer Science", Institute = "AIUB", Year = "2025", Result = "3.62/4.00" },
                new() { Degree = "HSC", Institute = "Shaheed Police Smrity Collage", Year = "2020", Result = "5.00/5.00" },
                new() { Degree = "SSC", Institute = "Adamjee Cantonment Public School", Year = "2018", Result = "4.83/5.00" }
            };

            return View(educationList);
        }

        public IActionResult Projects()
        {
            var projectsList = new List<Projects>
            {
                new() { Title = "Library Management System", Course = "OOP1", Description = "A system to manage book lending and returns." },
                new() { Title = "Attendance Tracker", Course = "OOP2", Description = "A student attendance tracking system using C#." },
                new() { Title = "E-commerce Website", Course = "Webtech", Description = "An online shopping website with various products." }
                
            };

            return View(projectsList);
        }

        public IActionResult Reference()
        {
            var references = new List<Reference>
            {
                new() { Name = "Tanvir Ahmed", Designation = "Professor", Organization = "AIUB", Contact = "tanvir.ahmed@aiub.edu" },
                new() { Name = "Sundar Pichai", Designation = "CEO", Organization = "Google", Contact = "pichai69@gmai.com" },
            };

            return View(references);
        }
    }
}
