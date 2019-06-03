using Microsoft.AspNetCore.Http;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class StudentCreateViewModel
    {
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Business Email")]
        public string Email { get; set; }

        public IFormFile Photo { get; set; }

        [Required]
        public Course? Course { get; set; }
    }
}
