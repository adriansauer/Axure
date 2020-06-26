using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Purchase
{
    public class ProviderDetailDTO
    {
        public int Id { get; set; }

        public ProductCategoryDTO Category { get; set; }
    }
}