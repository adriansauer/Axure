using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Axure.Models
{
    public class AxureContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AxureContext() : base("name=AxureContext")
        {
        }

        public System.Data.Entity.DbSet<Axure.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Deposit> Deposits { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ProductType> ProductTypes { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.TransferType> TransferTypes { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Transfer> Transfers { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.TransferDetail> TransferDetails { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Stock> Stocks { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Provider> Providers { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ProductComponent> ProductComponents { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ProductionState> ProductionStates { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ProductionOrder> ProductionOrders { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ProductionOrderDetail> ProductionOrderDetails { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.MovementMotive> MovementMotives { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Movement> Movements { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ComprobantePurchase> ComprobantePurchases { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ComprobantePurchaseDetail> ComprobantePurchaseDetails { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.MovementDetail> MovementDetails { get; set; }
    }
}
