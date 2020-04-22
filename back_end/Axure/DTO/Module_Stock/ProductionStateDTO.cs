using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProductionState class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class ProductionStateDTO
    {
        //Unique identifier.
        public int Id { get; set; }
        //Prduction state.
        public string State { get; set; }
    }
}