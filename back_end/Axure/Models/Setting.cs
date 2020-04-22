using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Setting class
 * Created april 21, 2020 by Victor Ciceia.
 */
namespace Axure.Models
{
    public class Setting
    {
        //Unique identifier.
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Key { get; set; }

        [Required]
        [StringLength(50)]
        public string Value { get; set; }
    }
}