namespace Axure.Migrations
{
    using Axure.Models;
    using Axure.Models.Module_Stock;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Axure.Models.AxureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Axure.Models.AxureContext context)
        {
           context.Users.AddOrUpdate(x => x.Id,
                 new User { Id = 1, UserName = "Admin", Role = "user", Password = "pass", Status = false },
                 new User { Id = 2, UserName = "Admin2", Role = "user", Password = "pass", Status = false }
                 );

            //Modulo Stock
            context.Deposits.AddOrUpdate(x => x.Id,
                new Deposit { Id = 1, NameD ="Deposito de Materia Prima" },
                new Deposit { Id = 2, NameD = "Deposito de Ensamblaje" },
                new Deposit { Id = 3, NameD = "Deposito de Productos Terminados" }
                );
            context.ProductTypes.AddOrUpdate(x => x.Id,
                new ProductType { Id=1, TypeP="Materia Prima o Producto Terminado"},
                new ProductType { Id = 2, TypeP = "Materia Prima" },
                new ProductType { Id = 3, TypeP = "Producto Terminado" }
                );
            context.Products.AddOrUpdate(x => x.Id,
                //En el deposito de materia prima
                new Product { Id = 1, NameP = "Monitor 22", DescriprionP = "22 pulg. ACER", Cost = 700000, IdProductType = 1, QuantityMin = 1, Barcode = "001" },
                new Product { Id = 2, NameP = "Monitor 12", DescriprionP = "12 pulg. ACER", Cost = 300000, IdProductType = 1, QuantityMin = 1, Barcode = "002" },
                new Product { Id = 3, NameP = "Monitor 42", DescriprionP = "42 pulg. ACER", Cost = 1500000, IdProductType = 1, QuantityMin = 1, Barcode = "003" },
                new Product { Id = 4, NameP = "Teclado", DescriprionP = "Gaming", Cost = 150000, IdProductType = 1, QuantityMin = 2, Barcode = "004" },
                new Product { Id = 5, NameP = "Teclado", DescriprionP = "ACER", Cost = 50000, IdProductType = 1, QuantityMin = 2, Barcode = "005" },
                //Para la venta
                new Product { Id=6, NameP="Monitor 22", DescriprionP="22 pulg. ACER", Cost= 700000, IdProductType = 3, QuantityMin=3,Barcode="001"},
                new Product { Id = 7, NameP = "Monitor 12", DescriprionP = "12 pulg. ACER", Cost = 300000, IdProductType = 3, QuantityMin = 3, Barcode = "002" },
                new Product { Id = 8, NameP = "Monitor 42", DescriprionP = "42 pulg. ACER", Cost = 1500000, IdProductType = 3, QuantityMin = 3, Barcode = "003" },
                new Product { Id = 9, NameP = "Teclado", DescriprionP = "Gaming", Cost = 150000, IdProductType = 3, QuantityMin = 3, Barcode = "004" },
                new Product { Id = 10, NameP = "Teclado", DescriprionP = "ACER", Cost = 50000, IdProductType = 3, QuantityMin = 3, Barcode = "005" }                 
                );
            context.TransferTypes.AddOrUpdate(x => x.Id,
                new TransferType { Id = 1, TypeP="Para produccion"}
                );
            context.Transfers.AddOrUpdate(x => x.Id);
            context.TransferDetails.AddOrUpdate(x => x.Id);
            context.Stocks.AddOrUpdate(x => x.Id);
            context.Providers.AddOrUpdate(x => x.Id);
            context.ProductComponents.AddOrUpdate(x => x.Id);
            context.Employees.AddOrUpdate(x => x.Id,
                new Employee { Id=1, NameE="Juan Sanchez"},
                new Employee { Id = 2, NameE = "Sonia Ramos" },
                new Employee { Id = 3, NameE = "Clara Pinto" },
                new Employee { Id = 4, NameE = "Oscar Sandoval" },
                new Employee { Id = 5, NameE = "Julio Barrosa" }
                );
            context.ProductionStates.AddOrUpdate(x => x.Id,
                new ProductionState { Id=1, PState="Materia prima o Producto terminado"},
                new ProductionState { Id = 2, PState = "Materia prima" },
                new ProductionState { Id = 3, PState = "Producto terminado" }
                );
            context.ProductionOrders.AddOrUpdate(x => x.Id);
            context.ProductionOrderDetails.AddOrUpdate(x => x.Id);
            context.MovementMotives.AddOrUpdate(x => x.Id,
                new MovementMotive { Id=1, Motive="Para ensamblaje"},
                new MovementMotive { Id = 2, Motive = "Para venta" },
                new MovementMotive { Id = 3, Motive = "Para desensamblar" }
                );
            context.Movements.AddOrUpdate(x => x.Id);
            context.MovementDetails.AddOrUpdate(x => x.Id);
            context.ComprobantePurchases.AddOrUpdate(x => x.Id);
            context.ComprobantePurchaseDetails.AddOrUpdate(x => x.Id);
        }
    }
}
