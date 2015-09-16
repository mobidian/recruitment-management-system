﻿using System.ComponentModel.DataAnnotations;
using RecruitmentManagementSystem.Model;

namespace RecruitmentManagementSystem.App.ViewModels
{
    public class CandidateViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name = "E-mail Address")]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Avatar")]
        public File Avatar { get; set; }

        [Display(Name = "Others")]
        [StringLength(3000, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Others { get; set; }

        [Url]
        [Display(Name = "Website link")]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Website { get; set; }
    }
}