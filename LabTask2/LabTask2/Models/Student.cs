using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LabTask2.Models
{
    public class Student
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z .-]+$", ErrorMessage = "Name can only contain alphabets, space, dot, and dash.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "ID must be same as provided by the Institution.")]
        public string ID { get; set; }

        [Required]
        [CustomValidation(typeof(DateOfBirthValidator), "IsValid")]
        public DateTime DateOfBirth { get; set; } = DateTime.Today;

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]@student\.aiub\.edu$", ErrorMessage = "Email must match the ID format followed by @student.aiub.edu.")]
        public string Email { get; set; }
    }
}
