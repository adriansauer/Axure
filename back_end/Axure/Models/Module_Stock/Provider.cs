using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class Provider
    {
        //
        public int Id { get; set; }
        //
        [Required]
        [StringLength(200)]
        public string NameP { get; set; }
        //
        [StringLength(200)]
        public string AddressP { get; set; }
        //
        [StringLength(200)]
        public string Phone { get; set; }
        //
        [Required]
        public int Credit { get; set; }
    }
}