using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Axure.Models
{
    public class AxureContext : DbContext
    {
    
        public AxureContext() : base("name=AxureContext")
        {
        }

        public System.Data.Entity.DbSet<Axure.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Setting> Settings { get; set; }

        //Module Stock

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Deposit> Deposits { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.MovementProductionType> MovementProductionTypes { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.MovementProduction> MovementProductions { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.MovementProductionDetail> MovementProductionDetails { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Transfer> Transfers { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ProductType> ProductTypes { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.TransferDetail> TransferDetails { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Stock> Stocks { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.MovementMotive> MovementMotives { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.Provider> Providers { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.PurchaseOrder> ProofPurchases { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.PurchaseOrderDetail> ProofPurchaseDetails { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ProductionState> ProductionStates { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ProductionOrder> ProductionOrders { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ProductComponent> ProductComponents { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.ProductionOrderDetail> ProductionOrderDetails { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.MovementType> MovementTypes { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.MovementProduct> MovementProducts { get; set; }

        public System.Data.Entity.DbSet<Axure.Models.Module_Stock.MovementProductDetail> MovementProductDetails { get; set; }


    }
}
