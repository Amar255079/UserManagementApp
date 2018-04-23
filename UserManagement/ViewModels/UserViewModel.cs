using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Web.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Country")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Country is required")]
        public int? CountryID { get; set; }

        [Display(Name = "State")]
        [Range(1, Int32.MaxValue, ErrorMessage = "State is required")]
        public int? StateID { get; set; }

        [Display(Name = "City")]
        [Range(1, Int32.MaxValue, ErrorMessage = "City is required")]
        public int? CityID { get; set; }

        [Display(Name ="Country")]
        public string Country { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}