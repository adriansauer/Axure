using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Axure.Models.Module_Stock;

namespace Axure.Models
{
    public class User
    {
        //
        public int Id { get; set; }
        //
        [Required]
        [StringLength(50)]
        public string Role { get; set; }
        //
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        //
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        //
        [Required]
        public bool Status { get; set; }
        //
        [Required]
        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }
    }
}