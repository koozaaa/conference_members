using ConferentionMembers.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConferentionMembers.Models
{
    public enum EducationType
    {
        None = 0,
        Primary = 1,
        Secondary = 2,
        Vocational = 3,
        IncompleteHigher = 4,
        Higher = 5
    }

    public class ConferenceMember
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        [Phone]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Required]
        [Display(Name = "Year of birth")]
        [YearOfBirth]
        public int YearOfBirth { get; set; }
        [Required]
        public EducationType Education { get; set; }
    }
}