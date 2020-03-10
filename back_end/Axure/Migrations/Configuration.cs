namespace Axure.Migrations
{
    using Axure.Models;
    using Axure.Models.Module_Stock;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /* 
     *Configuration.cs
     * Creado el 1 de marzo de 2020 por Victor Ciceia.
     * Modificado el 09-03-2020 por Paola Acuna.
     * Modificado el 10-03-2020 por Victor Ciceia.
     * Archivo donde se realizan las configuraciones que tendra la base de datos.
     */
    internal sealed class Configuration : DbMigrationsConfiguration<Axure.Models.AxureContext>
    {
        public Configuration()
        {
            //Configuracion en donde la base se actualiza automaticamente al hacer la migracion, false para desactivar la configuracion.
            AutomaticMigrationsEnabled = true;
        }

        //Funcion que se llama cada vez que se realiza la migracion. 
        protected override void Seed(Axure.Models.AxureContext context)
        {
            //Usuarios que se logean en la pagina.
            context.Users.AddOrUpdate(x => x.Id,
                  new User { Id = 1, Role = "user", UserName = "User", Password = "pass", Status = false, IdEmployee=1},
                  new User { Id = 2, Role = "admin", UserName = "Admin", Password = "pass", Status = false , IdEmployee=2}
                  );

            //--------------------------------------------------------------------------------------------------------------//
            //                                              Modulo Stock                                                    //
            //--------------------------------------------------------------------------------------------------------------//

            //Depositos en donde se guardaran los productos.
            context.Deposits.AddOrUpdate(x => x.Id,
                new Deposit { Id = 1, NameD = "Deposito de Materia Prima", Code="001" },
                new Deposit { Id = 2, NameD = "Deposito de Ensamblaje", Code = "002" },
                new Deposit { Id = 3, NameD = "Deposito de Productos Terminados", Code = "003" }
                );
            //Tipo de producto, lo que se espera hacer con el producto.
            context.ProductTypes.AddOrUpdate(x => x.Id,
                new ProductType { Id = 1, TypeP = "Materia Prima o Producto Terminado" },
                new ProductType { Id = 2, TypeP = "Materia Prima" },
                new ProductType { Id = 3, TypeP = "Producto Terminado" }
                );
            //Productos informaticos.
            context.Products.AddOrUpdate(x => x.Id,
                new Product { Id = 1, NameP = "Monitor 22", DescriprionP = "22 pulg. ACER", Cost = 700000, IdProductType = 1, QuantityMin = 3, Barcode = "001" },
                new Product { Id = 2, NameP = "Monitor 12", DescriprionP = "12 pulg. ACER", Cost = 300000, IdProductType = 1, QuantityMin = 3, Barcode = "002" },
                new Product { Id = 3, NameP = "Monitor 42", DescriprionP = "42 pulg. ACER", Cost = 1500000, IdProductType = 1, QuantityMin = 3, Barcode = "003" },
                new Product { Id = 4, NameP = "Teclado", DescriprionP = "Gammer", Cost = 150000, IdProductType = 1, QuantityMin = 2, Barcode = "004" },
                new Product { Id = 5, NameP = "Teclado", DescriprionP = "ACER", Cost = 50000, IdProductType = 1, QuantityMin = 2, Barcode = "005" },
                new Product { Id = 6, NameP = "Mouse", DescriprionP = "Logitech B100", Cost = 45000, IdProductType = 1, QuantityMin = 2, Barcode = "006" },
                new Product { Id = 7, NameP = "Mouse", DescriprionP = "Inalambrico Logitech M185", Cost = 75000, IdProductType = 1, QuantityMin = 2, Barcode = "007" },
                new Product { Id = 8, NameP = "Teclado", DescriprionP = "Convencional", Cost = 50000, IdProductType = 1, QuantityMin = 2, Barcode = "008" },
                new Product { Id = 9, NameP = "Teclado", DescriprionP = "Inalambrico", Cost = 80000, IdProductType = 1, QuantityMin = 2, Barcode = "009" },
                new Product { Id = 10, NameP = "Mouse", DescriprionP = "Inalambrico Logitech M220 Silent", Cost = 120000, IdProductType = 1, QuantityMin = 2, Barcode = "010" },
                new Product { Id = 11, NameP = "Placa Principal", DescriprionP = "ASUS", Cost = 350000, IdProductType = 2, QuantityMin = 2, Barcode = "011" },
                new Product { Id = 12, NameP = "Microprocesador", DescriprionP = "Intel Core i5-9400F", Cost = 988149, IdProductType = 2, QuantityMin = 2, Barcode = "012" },
                new Product { Id = 13, NameP = "Placa Principal", DescriprionP = "MSI", Cost = 338000, IdProductType = 2, QuantityMin = 1, Barcode = "013" },
                new Product { Id = 14, NameP = "Microprocesador", DescriprionP = "Intel Core i7-9700", Cost = 2174000, IdProductType = 2, QuantityMin = 2, Barcode = "014" },
                new Product { Id = 15, NameP = "Microprocesador", DescriprionP = "Intel Core i3-9100F", Cost = 539895, IdProductType = 2, QuantityMin = 2, Barcode = "015" },
                new Product { Id = 16, NameP = "Placa Principal", DescriprionP = "MSI B360M Gaming", Cost = 545000, IdProductType = 2, QuantityMin = 1, Barcode = "016" },
                new Product { Id = 17, NameP = "Placa Principal", DescriprionP = "ASUS Prime H310M-D", Cost = 445000, IdProductType = 2, QuantityMin = 1, Barcode = "017" },
                new Product { Id = 18, NameP = "Microprocesador", DescriprionP = "AMD ATHLON", Cost = 500000, IdProductType = 2, QuantityMin = 2, Barcode = "018" },
                new Product { Id = 19, NameP = "Microprocesador", DescriprionP = "AMD Ryzen", Cost = 250000, IdProductType = 2, QuantityMin = 2, Barcode = "019" },
                new Product { Id = 20, NameP = "Placa Principal", DescriprionP = "MSI PRO-VH", Cost = 443000, IdProductType = 2, QuantityMin = 1, Barcode = "020" }
                );
            //El motivo por el cual se realiza el traslado.
            context.TransferTypes.AddOrUpdate(x => x.Id,
                new TransferType { Id = 1, TypeP = "Para produccion" }
                );
            //Transferir productos de un deposito a otro.
            context.Transfers.AddOrUpdate(x => x.Id,
                new Transfer { Id = 1, IdDepositOrigin = 1, IdDepositDestination = 2, IdTransferType = 1, DateT = new DateTime(2020, 03, 10), Observation = "Para ensamblaje" });
            //context.TransferDetails.AddOrUpdate(x => x.Id);
            context.Stocks.AddOrUpdate(x => x.Id,
                //Deposito de materia prima.
                new Stock { Id = 1, IdProduct = 1, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 2, IdProduct = 3, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 3, IdProduct = 4, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 4, IdProduct = 5, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 5, IdProduct = 6, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 6, IdProduct = 7, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 7, IdProduct = 8, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 8, IdProduct = 9, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 9, IdProduct = 10, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 10, IdProduct = 11, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 11, IdProduct = 13, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 12, IdProduct = 14, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 13, IdProduct = 15, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 14, IdProduct = 16, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 15, IdProduct = 17, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 16, IdProduct = 18, IdDeposit = 1, Quantity = 10 },
                new Stock { Id = 17, IdProduct = 20, IdDeposit = 1, Quantity = 10 },
                //Deposito de venta.
                new Stock { Id = 18, IdProduct = 1, IdDeposit = 3, Quantity = 3 },
                new Stock { Id = 19, IdProduct = 2, IdDeposit = 3, Quantity = 3 },
                new Stock { Id = 20, IdProduct = 3, IdDeposit = 3, Quantity = 3 },
                new Stock { Id = 21, IdProduct = 5, IdDeposit = 3, Quantity = 2 },
                new Stock { Id = 22, IdProduct = 9, IdDeposit = 3, Quantity = 2 }
                );
            //context.Providers.AddOrUpdate(x => x.Id);
            //context.ProductComponents.AddOrUpdate(x => x.Id);
            context.Employees.AddOrUpdate(x => x.Id,
                new Employee { Id = 1, NameE = "Juan Sanchez", CI="1.236.526", Direction="Carmen del Parana", RUC="1.236.526-5", Phone="0761 582 975" },
                new Employee { Id = 2, NameE = "Sonia Ramos", CI = "5.632.789", Direction = "Carmen del Parana", RUC = "5.632.789-3", Phone = "0761 888 975" },
                new Employee { Id = 3, NameE = "Clara Pinto", CI = "5.689.425", Direction = "Fram", RUC = "5.689.425-5", Phone = "0761 586 111" },
                new Employee { Id = 4, NameE = "Oscar Sandoval", CI = "6.524.879", Direction = "La Paz", RUC = "6.524.879-3", Phone = "0761 889 777" },
                new Employee { Id = 5, NameE = "Julio Barrosa", CI = "2.683.256", Direction = "Coronel Bogado", RUC = "2.683.256-4", Phone = "0761 769 542" }
                );
            context.ProductionStates.AddOrUpdate(x => x.Id,
                new ProductionState { Id = 1, StateP = "Materia prima o Producto terminado" },
                new ProductionState { Id = 2, StateP = "Materia prima" },
                new ProductionState { Id = 3, StateP = "Producto terminado" }
                );
            //context.ProductionOrders.AddOrUpdate(x => x.Id);
            //context.ProductionOrderDetails.AddOrUpdate(x => x.Id);
            context.MovementMotives.AddOrUpdate(x => x.Id,
                new MovementMotive { Id = 1, Motive = "Para ensamblaje" },
                new MovementMotive { Id = 2, Motive = "Para venta" },
                new MovementMotive { Id = 3, Motive = "Para desensamblar" }
                );
            //context.Movements.AddOrUpdate(x => x.Id);
            //context.MovementDetails.AddOrUpdate(x => x.Id);
            //context.ComprobantePurchases.AddOrUpdate(x => x.Id);
            //context.ComprobantePurchaseDetails.AddOrUpdate(x => x.Id);
        }
    }
}
