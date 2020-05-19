using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ClientDTO class
 * Created May 18, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Sale
{
    public class ClientDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Client name.
        public string Name { get; set; }

        //Client address.
        public string Address { get; set; }

        //Client number RUC.
        public string RUC { get; set; }

        //Maximum credit the client can get.
        public int CreditMaximum { get; set; }

        //Current customer credit.
        public int CreditPending { get; set; }
    }
}