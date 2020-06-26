using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProviderDTO class
 * Created march 1, 2020 by Victor Ciceia.
 * Raw material suppliers.
 */
namespace Axure.DTO.Module_Purchase
{
    public class ProviderDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Provider name.
        public string Name { get; set; }

        //Provider address.
        public string Address { get; set; }

        //Provider phone.
        public string Phone { get; set; }

        //Credit that the company has available with the supplier.
        public int Credit { get; set; }

        //Provider RUC.
        public string RUC { get; set; }
    }
}