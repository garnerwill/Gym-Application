using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYM_APP.Models
{
    public class Gym
    {
        [Key]

        public int Id { get; set; }
        [Display(Name = "Company Name")]
        public string UserName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip")]
        public string ZipCode { get; set; }
        

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = " Ratings")]
        public int Ratings { get; set; }
        [Required]
        [Display(Name = "User Roles")]
        public string UserRoles { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}