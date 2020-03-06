using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class Employee
    {
        //
        public int Id { get; set; }
        //
        [Required]
        [StringLength(200)]
        public string NameE { get; set; }
        //
        [Required]
        [StringLength(20)]
        public string CI { get; set; }
        //
        [Required]
        [StringLength(200)]
        public string Direction { get; set; }
        //
        [Required]
        [StringLength(20)]
        public string RUC { get; set; }
        //
        [StringLength(20)]
        public string Phone { get; set; }
    }
}