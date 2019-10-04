using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYM_APP.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "User Name")]
        public string  UserName { get; set; }
       
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip")]
        public string ZipCode { get; set; }

        

        //[DataType(DataType.Date)]
        

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        [Display(Name = "User Roles")]
        public string UserRoles { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public enum DayOfWeek { }

    }
}