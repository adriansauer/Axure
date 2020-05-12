namespace Axure.Migrations
{
    using Axure.Models;
    using Axure.Models.Module_Stock;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /* 
     * Configuration.cs
     * Created march 1, 2020 by Victor Ciceia
     * Modified the 09-03-2020 by Paola Acuna.
     * Modified the 20-04-2020 by Victor Ciceia.
     * 
     * Database configuration file.
     */
    internal sealed class Configuration : DbMigrationsConfiguration<Axure.Models.AxureContext>
    {
        public Configuration()
        {
            //Configuration where the base updates automatically when doing the migration, false to deactivate the configuration
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

         //Function that is called every time the migration is performed. 
        protected override void Seed(Axure.Models.AxureContext context)
        {
            //Users the page.
            context.Users.AddOrUpdate(x => x.Id,
                  new User { Id = 1, Role = "user", UserName = "User", Password = "pass", Status = false, IdEmployee=1},
                  new User { Id = 2, Role = "admin", UserName = "Admin", Password = "pass", Status = false , IdEmployee=2}
                  );
            //Settings
            context.Settings.AddOrUpdate(x => x.Id,
                new Setting { Id = 1, Key = "ID_DEPOSIT_RAW_MATERIAL", Value = "1" },
                new Setting { Id = 2, Key = "ID_DEPOSIT_PRODUCTION", Value = "2" },
                new Setting { Id = 3, Key = "ID_DEPOSIT_SALE", Value = "3" },
                new Setting { Id = 4, Key = "ID_ENTRY_PRODUCT", Value = "1" },
                new Setting { Id = 5, Key = "ID_OUTPUT_PRODUCT", Value = "2" },
                new Setting { Id = 6, Key = "ID_TYPE_OF_PRODUCT_RAW_MATERIAL_AND_FINISHED", Value = "1" },
                new Setting { Id = 7, Key = "ID_TYPE_OF_PRODUCT_RAW_MATERIAL", Value = "2" },
                new Setting { Id = 8, Key = "ID_TYPE_OF_PRODUCT_FINISHED", Value = "3" },
                new Setting { Id = 9, Key = "AUTOMATIC_PRODUCTION_ORDER", Value = "0" },
                new Setting { Id = 10, Key = "ID_PRODUCTION_STATE_PENDING", Value = "1" },
                new Setting { Id = 11, Key = "ID_PRODUCTION_STATE_PROGRESS", Value = "2" },
                new Setting { Id = 12, Key = "ID_PRODUCTION_STATE_FINALIZED", Value = "3" },
                new Setting { Id = 13, Key = "ID_PRODUCTION_STATE_CANCELLED", Value = "4" }
                );

            //--------------------------------------------------------------------------------------------------------------//
            //                                              Module Stock                                                    //
            //--------------------------------------------------------------------------------------------------------------//

            //Deposit the products.
            context.Deposits.AddOrUpdate(x => x.Id,
                new Deposit { Id = 1, Name = "Deposito de Materia Prima" },
                new Deposit { Id = 2, Name = "Deposito de Ensamblaje"},
                new Deposit { Id = 3, Name = "Deposito de Productos Terminados"}
                );
            //Type of products, utility that the company will give.
            context.ProductTypes.AddOrUpdate(x => x.Id,
                new ProductType { Id = 1, Type = "Materia Prima o Producto Terminado", Deleted = false },
                new ProductType { Id = 2, Type = "Materia Prima", Deleted = false },
                new ProductType { Id = 3, Type = "Producto Terminado", Deleted = false }
                );
            //Products 
           context.Products.AddOrUpdate(x => x.Id,
                new Product { Id = 1, Name = "Monitor 22", Description = "22 pulg. ACER", Cost = 700000, ProductTypeId = 1, QuantityMin = 3, Barcode = "001", Deleted = false },
                new Product { Id = 2, Name = "Monitor 12", Description = "12 pulg. ACER", Cost = 300000, ProductTypeId = 1, QuantityMin = 3, Barcode = "002", Deleted = false },
                new Product { Id = 3, Name = "Monitor 42", Description = "42 pulg. ACER", Cost = 1500000, ProductTypeId = 1, QuantityMin = 3, Barcode = "003", Deleted = false },
                new Product { Id = 4, Name = "Teclado", Description = "Gammer", Cost = 150000, ProductTypeId = 1, QuantityMin = 2, Barcode = "004", Deleted = false },
                new Product { Id = 5, Name = "Teclado", Description = "ACER", Cost = 50000, ProductTypeId = 1, QuantityMin = 2, Barcode = "005", Deleted = false },
                new Product { Id = 6, Name = "Mouse", Description = "Logitech B100", Cost = 45000, ProductTypeId = 1, QuantityMin = 2, Barcode = "006", Deleted = false },
                new Product { Id = 7, Name = "Mouse", Description = "Inalambrico Logitech M185", Cost = 75000, ProductTypeId = 1, QuantityMin = 2, Barcode = "007", Deleted = false },
                new Product { Id = 8, Name = "Teclado", Description = "Convencional", Cost = 50000, ProductTypeId = 1, QuantityMin = 2, Barcode = "008", Deleted = false },
                new Product { Id = 9, Name = "Teclado", Description = "Inalambrico", Cost = 80000, ProductTypeId = 1, QuantityMin = 2, Barcode = "009", Deleted = false },
                new Product { Id = 10, Name = "Mouse", Description = "Inalambrico Logitech M220 Silent", Cost = 120000, ProductTypeId = 1, QuantityMin = 2, Barcode = "010", Deleted = false },
                new Product { Id = 11, Name = "Placa Principal", Description = "ASUS", Cost = 350000, ProductTypeId = 2, QuantityMin = 2, Barcode = "011", Deleted = false },
                new Product { Id = 12, Name = "Microprocesador", Description = "Intel Core i5-9400F", Cost = 988149, ProductTypeId = 2, QuantityMin = 2, Barcode = "012", Deleted = false },
                new Product { Id = 13, Name = "Placa Principal", Description = "MSI", Cost = 338000, ProductTypeId = 2, QuantityMin = 1, Barcode = "013", Deleted = false },
                new Product { Id = 14, Name = "Microprocesador", Description = "Intel Core i7-9700", Cost = 2174000, ProductTypeId = 2, QuantityMin = 2, Barcode = "014", Deleted = false },
                new Product { Id = 15, Name = "Microprocesador", Description = "Intel Core i3-9100F", Cost = 539895, ProductTypeId = 2, QuantityMin = 2, Barcode = "015", Deleted = false },
                new Product { Id = 16, Name = "Placa Principal", Description = "MSI B360M Gaming", Cost = 545000, ProductTypeId = 2, QuantityMin = 1, Barcode = "016", Deleted = false },
                new Product { Id = 17, Name = "Placa Principal", Description = "ASUS Prime H310M-D", Cost = 445000, ProductTypeId = 2, QuantityMin = 1, Barcode = "017", Deleted = false },
                new Product { Id = 18, Name = "Microprocesador", Description = "AMD ATHLON", Cost = 500000, ProductTypeId = 2, QuantityMin = 2, Barcode = "018", Deleted = false },
                new Product { Id = 19, Name = "Microprocesador", Description = "AMD Ryzen", Cost = 250000, ProductTypeId = 2, QuantityMin = 2, Barcode = "019", Deleted = false },
                new Product { Id = 20, Name = "Placa Principal", Description = "MSI PRO-VH", Cost = 443000, ProductTypeId = 2, QuantityMin = 1, Barcode = "020", Deleted = false },
                //PC creation. 
                new Product { Id = 21, Name = "Computadora PC1", Description = "Gama Baja", Cost = 2000000, ProductTypeId = 3, QuantityMin = 1, Barcode = "021", Deleted = false },
                new Product { Id = 22, Name = "Computadora PC2", Description = "Gama Media", Cost = 2500000, ProductTypeId = 3, QuantityMin = 1, Barcode = "022", Deleted = false },
                new Product { Id = 23, Name = "Computadora PC3", Description = "Gama Alta", Cost = 3000000, ProductTypeId = 3, QuantityMin = 2, Barcode = "023", Deleted = false }

                );
            //Transfers the products.
            context.Transfers.AddOrUpdate(x => x.Id,
                new Transfer { Id = 1, DepositOriginId = 1, DepositDestinationId = 3, Date = new DateTime(2020, 03, 10), Observation = "Para la realizacion de ventas varias.", Deleted= false, Number = 1 });
            //Transfer details.
            context.TransferDetails.AddOrUpdate(x => x.Id,
                new TransferDetail { Id=1, TransferId = 1, ProductId = 1, Quantity = 1, Deleted = false, Number = 1 });
            //Existence of products.
            context.Stocks.AddOrUpdate(x => x.Id,
                //Deposit raw material.
                new Stock { Id = 1, ProductId = 1, DepositId = 1, Quantity = 10 },
                new Stock { Id = 2, ProductId = 3, DepositId = 1, Quantity = 10 },
                new Stock { Id = 3, ProductId = 4, DepositId = 1, Quantity = 10 },
                new Stock { Id = 4, ProductId = 5, DepositId = 1, Quantity = 10 },
                new Stock { Id = 5, ProductId = 6, DepositId = 1, Quantity = 10 },
                new Stock { Id = 6, ProductId = 7, DepositId = 1, Quantity = 10 },
                new Stock { Id = 7, ProductId = 8, DepositId = 1, Quantity = 10 },
                new Stock { Id = 8, ProductId = 9, DepositId = 1, Quantity = 10 },
                new Stock { Id = 9, ProductId = 10, DepositId = 1, Quantity = 10 },
                new Stock { Id = 10, ProductId = 11, DepositId = 1, Quantity = 10 },
                new Stock { Id = 11, ProductId = 13, DepositId = 1, Quantity = 10 },
                new Stock { Id = 12, ProductId = 14, DepositId = 1, Quantity = 10 },
                new Stock { Id = 13, ProductId = 15, DepositId = 1, Quantity = 10 },
                new Stock { Id = 14, ProductId = 16, DepositId = 1, Quantity = 10 },
                new Stock { Id = 15, ProductId = 17, DepositId = 1, Quantity = 10 },
                new Stock { Id = 16, ProductId = 18, DepositId = 1, Quantity = 10 },
                new Stock { Id = 17, ProductId = 20, DepositId = 1, Quantity = 10 },
                //Deposit sales
                new Stock { Id = 18, ProductId = 1, DepositId = 3, Quantity = 3 },
                new Stock { Id = 19, ProductId = 2, DepositId = 3, Quantity = 3 },
                new Stock { Id = 20, ProductId = 3, DepositId = 3, Quantity = 3 },
                new Stock { Id = 21, ProductId = 5, DepositId = 3, Quantity = 2 },
                new Stock { Id = 22, ProductId = 9, DepositId = 3, Quantity = 2 }
                );
            //Providers the raw material.
            context.Providers.AddOrUpdate(x => x.Id,
                new Provider { Id = 1, Name = "Maria Paredes", Address = "La Paz", Phone = "0985 758 239", Credit = 10000000, RUC = "5.563.547-5", Deleted = false },
                new Provider { Id = 2, Name = "Jorge Miranda", Address = "Ciudad del Este", Phone = "0991 566 143", Credit = 8000000, RUC = "1.348.376-1", Deleted = false },
                new Provider { Id = 3, Name = "Mauricio Rojas", Address = "Pilar", Phone = "0993 555 987", Credit = 6000000, RUC = "8.547.631-0", Deleted = false });
            //Parts the PC.
            context.ProductComponents.AddOrUpdate(x => x.Id,
                //Low range
                new ProductComponent { Id = 1, ProductId = 21, ProductComponentId = 2, Quantity = 1 },
                new ProductComponent { Id = 2, ProductId = 21, ProductComponentId = 5, Quantity = 1 },
                new ProductComponent { Id = 3, ProductId = 21, ProductComponentId = 10, Quantity = 1 },
                new ProductComponent { Id = 4, ProductId = 21, ProductComponentId = 15, Quantity = 1 },
                new ProductComponent { Id = 5, ProductId = 21, ProductComponentId = 20, Quantity = 1 },
                //Medium range
                new ProductComponent { Id = 6, ProductId = 22, ProductComponentId = 1, Quantity = 1 },
                new ProductComponent { Id = 7, ProductId = 22, ProductComponentId = 5, Quantity = 1 },
                new ProductComponent { Id = 8, ProductId = 22, ProductComponentId = 10, Quantity = 1 },
                new ProductComponent { Id = 9, ProductId = 22, ProductComponentId = 12, Quantity = 1 },
                new ProductComponent { Id = 10, ProductId = 22, ProductComponentId = 17, Quantity = 1 },
                //High range
                new ProductComponent { Id = 11, ProductId = 23, ProductComponentId = 3, Quantity = 1 },
                new ProductComponent { Id = 12, ProductId = 23, ProductComponentId = 4, Quantity = 1 },
                new ProductComponent { Id = 13, ProductId = 23, ProductComponentId = 10, Quantity = 1 },
                new ProductComponent { Id = 14, ProductId = 23, ProductComponentId = 14, Quantity = 1 },
                new ProductComponent { Id = 15, ProductId = 23, ProductComponentId = 16, Quantity = 1 }
                );
            //Company employees.
            context.Employees.AddOrUpdate(x => x.Id,
                new Employee { Id = 1, Name = "Juan Sanchez", CI="1.236.526", Address = "Carmen del Parana", RUC="1.236.526-5", Phone="0761 582 975", Deleted=false },
                new Employee { Id = 2, Name = "Sonia Ramos", CI = "5.632.789", Address = "Carmen del Parana", RUC = "5.632.789-3", Phone = "0761 888 975", Deleted = false },
                new Employee { Id = 3, Name = "Clara Pinto", CI = "5.689.425", Address = "Fram", RUC = "5.689.425-5", Phone = "0761 586 111", Deleted = false },
                new Employee { Id = 4, Name = "Oscar Sandoval", CI = "6.524.879", Address = "La Paz", RUC = "6.524.879-3", Phone = "0761 889 777", Deleted = false },
                new Employee { Id = 5, Name = "Julio Barrosa", CI = "2.683.256", Address = "Coronel Bogado", RUC = "2.683.256-4", Phone = "0761 769 542", Deleted = false }
                );
            //Status of a production order.
            context.ProductionStates.AddOrUpdate(x => x.Id,
                new ProductionState { Id = 1, State = "Pendiente", Deleted = false },
                new ProductionState { Id = 2, State = "En Proceso", Deleted = false },
                new ProductionState { Id = 3, State = "Terminado", Deleted = false },
                new ProductionState { Id = 4, State = "Cancelado", Deleted = false }
                );
            //Product production order.
            context.ProductionOrders.AddOrUpdate(x => x.Id,
                new ProductionOrder { Id = 1, ProductionStateId = 1, EmployeeId = 3, Date = new DateTime(2020,03,10), Observation = "Que los cables sean negros", Deleted = false },
                new ProductionOrder { Id = 2, ProductionStateId = 1, EmployeeId = 3, Date = new DateTime(2020, 03, 10), Observation = "Que los cables sean negros", Deleted = false },
                new ProductionOrder { Id = 3, ProductionStateId = 2, EmployeeId = 1, Date = new DateTime(2020, 03, 10), Observation = "Que los cables sean negros", Deleted = false },
                new ProductionOrder { Id = 4, ProductionStateId = 3, EmployeeId = 4, Date = new DateTime(2020, 03, 10), Observation = "Que los cables sean negros", Deleted = false },
                new ProductionOrder { Id = 5, ProductionStateId = 4, EmployeeId = 5, Date = new DateTime(2020, 03, 10), Observation = "Que los cables sean negros", Deleted = false }
                );
            //Products to produce.
            context.ProductionOrderDetails.AddOrUpdate(x => x.Id,
                new ProductionOrderDetail { Id = 1, ProductionOrderId = 1, ProductId = 23, Quantity = 1, Deleted = false },
                new ProductionOrderDetail { Id = 2, ProductionOrderId = 1, ProductId = 22, Quantity = 1, Deleted = false },
                new ProductionOrderDetail { Id = 3, ProductionOrderId = 1, ProductId = 1, Quantity = 1, Deleted = false }
                );
            //Types of product movements according to production order.
            context.MovementProductionTypes.AddOrUpdate(x => x.Id,
                new MovementProductionType { Id = 1, Type = "Para producción" },
                new MovementProductionType { Id = 2, Type = "Para Venta" });
            //Product movements according to production order.
            //context.MovementProductions.AddOrUpdate(x => x.Id);
            //Detail od the movement of products for production.
            //context.MovementProductionDetails.AddOrUpdate(x => x.Id);
            //It is used when products are missing from the raw material deposit. 
            //context.PurchaseOrders.AddOrUpdate(x => x.Id);
            //Purchase details.
            //context.PurchaseOrderDetails.AddOrUpdate(x => x.Id);

            //context.MovementProducts.AddOrUpdate(x => x.Id);
            //context.MovementProductDetails.AddOrUpdate(x => x.Id);
            //context.MovementMotives.AddOrUpdate(x => x.Id);
            context.MovementTypes.AddOrUpdate(x => x.Id,
                new MovementType { Id = 1, Abbreviation = "ENT", Description = "Entry" },
                new MovementType { Id = 2, Abbreviation = "OUT", Description = "Output"}
                );

            context.MovementMotives.AddOrUpdate(x => x.Id,
                new MovementMotive {Id = 1, MovementTypeId = 1, Motive = "Obsequio del proveedor." },
                new MovementMotive {Id = 2, MovementTypeId = 2, Motive = "Salida por rotura." }
                );
            
            
        }
    }
}
