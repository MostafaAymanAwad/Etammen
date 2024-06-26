﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataAccessLayerEF.Models;

namespace Etammen.ViewModels
{
    public class DoctorViewModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }

        [Required, MaxLength(30), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(30), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required,Display(Name ="About")]
        public string AboutTheDoctor { get; set; }

        [Required]
        public string? ProfilePicture { get; set; } = "";
        public string? OldProfilePicture { get; set; } 
        public IFormFile? ProfilePictureFormFile { get; set; } 
        [Display(Name = "Experience")]
        public string YearsOfExperience { get; set; }
        public string? Speciality { get; set; }
        public string? Degree { get; set; }
        public string? TotalRatings { get; set; }
        [Column(TypeName = "money"), Display(Name = "Home Visit Fees")]
        public decimal? HomeVisitFees { get; set; }
        [Required, Display(Name = "Home Visits")]
        public bool IsVisitHome { get; set; }
        public virtual ICollection<Clinic>? Clinics { get; set; } = new HashSet<Clinic>();
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public virtual ICollection<DoctorReviews>? DoctorReviews { get; set; } = new HashSet<DoctorReviews>();
    }
}
