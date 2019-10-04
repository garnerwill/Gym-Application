using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GYM_APP.Models
{
    public class Calender
        
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Eventstart { get; set; }
        public DateTime Eventend { get; set; }
        
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        [Display(Name = "User Roles")]
        public string UserRoles { get; set; }
    }
}