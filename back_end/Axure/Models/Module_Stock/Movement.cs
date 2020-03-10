using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class Movement
    {
        //
        public int Id { get; set; }
        //
        [Required]
        public int IdMotive { get; set; }
        [ForeignKey("IdMotive")]
        public MovementMotive MovementMotive { get; set; }
        //
        [Required]
        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }
        //
        [Required]
        public DateTime DateM { get; set; }
    }
}