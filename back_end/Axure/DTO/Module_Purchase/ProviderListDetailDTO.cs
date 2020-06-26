using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProviderListDetailDTO class
 * Created June 25, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Purchase
{
    public class ProviderListDetailDTO : ProviderDTO
    {
        //List provider categories.
        public List<ProviderDetailDTO> ListCategories { get; set; }
    }
}