namespace Axure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComprobantePurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdComprobantePurchase = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: false)
                .ForeignKey("dbo.Transfers", t => t.IdComprobantePurchase, cascadeDelete: false)
                .Index(t => t.IdComprobantePurchase)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProductType = c.Int(nullable: false),
                        NameP = c.String(nullable: false, maxLength: 200),
                        DescriprionP = c.String(nullable: false, maxLength: 200),
                        Cost = c.Int(nullable: false),
                        QuantityMin = c.Int(nullable: false),
                        Barcode = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTypes", t => t.IdProductType, cascadeDelete: false)
                .Index(t => t.IdProductType);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeP = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDepositOrigin = c.Int(nullable: false),
                        IdDepositDestination = c.Int(nullable: false),
                        IdTransferType = c.Int(nullable: false),
                        DateT = c.DateTime(nullable: false),
                        Observation = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deposits", t => t.IdDepositDestination, cascadeDelete: false)
                .ForeignKey("dbo.Deposits", t => t.IdDepositOrigin, cascadeDelete: false)
                .ForeignKey("dbo.TransferTypes", t => t.IdTransferType, cascadeDelete: false)
                .Index(t => t.IdDepositOrigin)
                .Index(t => t.IdDepositDestination)
                .Index(t => t.IdTransferType);
            
            CreateTable(
                "dbo.Deposits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameD = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransferTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeP = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComprobantePurchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateC = c.DateTime(nullable: false),
                        IdProvider = c.Int(nullable: false),
                        IdEmployee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.IdEmployee, cascadeDelete: false)
                .ForeignKey("dbo.Providers", t => t.IdProvider, cascadeDelete: false)
                .Index(t => t.IdProvider)
                .Index(t => t.IdEmployee);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameE = c.String(nullable: false, maxLength: 200),
                        CI = c.String(nullable: false, maxLength: 20),
                        Direction = c.String(nullable: false, maxLength: 200),
                        RUC = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameP = c.String(nullable: false, maxLength: 200),
                        AddressP = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 200),
                        Credit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovementDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMovement = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movements", t => t.IdMovement, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: false)
                .Index(t => t.IdMovement)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMotive = c.Int(nullable: false),
                        IdEmployee = c.Int(nullable: false),
                        DateM = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.IdEmployee, cascadeDelete: false)
                .ForeignKey("dbo.MovementMotives", t => t.IdMotive, cascadeDelete: false)
                .Index(t => t.IdMotive)
                .Index(t => t.IdEmployee);
            
            CreateTable(
                "dbo.MovementMotives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Motive = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductComponents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProduct = c.Int(nullable: false),
                        IdProductComponent = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.IdProductComponent, cascadeDelete: false)
                .Index(t => t.IdProduct)
                .Index(t => t.IdProductComponent);
            
            CreateTable(
                "dbo.ProductionOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProductComponent = c.Int(nullable: false),
                        IdProductionOrder = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductComponents", t => t.IdProductComponent, cascadeDelete: false)
                .ForeignKey("dbo.ProductionOrders", t => t.IdProductionOrder, cascadeDelete: false)
                .Index(t => t.IdProductComponent)
                .Index(t => t.IdProductionOrder);
            
            CreateTable(
                "dbo.ProductionOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProductionState = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                        IdEmployee = c.Int(nullable: false),
                        DateT = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.IdEmployee, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: false)
                .ForeignKey("dbo.ProductionStates", t => t.IdProductionState, cascadeDelete: false)
                .Index(t => t.IdProductionState)
                .Index(t => t.IdProduct)
                .Index(t => t.IdEmployee);
            
            CreateTable(
                "dbo.ProductionStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateP = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDeposit = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deposits", t => t.IdDeposit, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: false)
                .Index(t => t.IdDeposit)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "dbo.TransferDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProduct = c.Int(nullable: false),
                        IdTransfer = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: false)
                .ForeignKey("dbo.Transfers", t => t.IdTransfer, cascadeDelete: false)
                .Index(t => t.IdProduct)
                .Index(t => t.IdTransfer);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        IdEmployee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.IdEmployee, cascadeDelete: false)
                .Index(t => t.IdEmployee);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "IdEmployee", "dbo.Employees");
            DropForeignKey("dbo.TransferDetails", "IdTransfer", "dbo.Transfers");
            DropForeignKey("dbo.TransferDetails", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Stocks", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Stocks", "IdDeposit", "dbo.Deposits");
            DropForeignKey("dbo.ProductionOrderDetails", "IdProductionOrder", "dbo.ProductionOrders");
            DropForeignKey("dbo.ProductionOrders", "IdProductionState", "dbo.ProductionStates");
            DropForeignKey("dbo.ProductionOrders", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.ProductionOrders", "IdEmployee", "dbo.Employees");
            DropForeignKey("dbo.ProductionOrderDetails", "IdProductComponent", "dbo.ProductComponents");
            DropForeignKey("dbo.ProductComponents", "IdProductComponent", "dbo.Products");
            DropForeignKey("dbo.ProductComponents", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.MovementDetails", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.MovementDetails", "IdMovement", "dbo.Movements");
            DropForeignKey("dbo.Movements", "IdMotive", "dbo.MovementMotives");
            DropForeignKey("dbo.Movements", "IdEmployee", "dbo.Employees");
            DropForeignKey("dbo.ComprobantePurchases", "IdProvider", "dbo.Providers");
            DropForeignKey("dbo.ComprobantePurchases", "IdEmployee", "dbo.Employees");
            DropForeignKey("dbo.ComprobantePurchaseDetails", "IdComprobantePurchase", "dbo.Transfers");
            DropForeignKey("dbo.Transfers", "IdTransferType", "dbo.TransferTypes");
            DropForeignKey("dbo.Transfers", "IdDepositOrigin", "dbo.Deposits");
            DropForeignKey("dbo.Transfers", "IdDepositDestination", "dbo.Deposits");
            DropForeignKey("dbo.ComprobantePurchaseDetails", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Products", "IdProductType", "dbo.ProductTypes");
            DropIndex("dbo.Users", new[] { "IdEmployee" });
            DropIndex("dbo.TransferDetails", new[] { "IdTransfer" });
            DropIndex("dbo.TransferDetails", new[] { "IdProduct" });
            DropIndex("dbo.Stocks", new[] { "IdProduct" });
            DropIndex("dbo.Stocks", new[] { "IdDeposit" });
            DropIndex("dbo.ProductionOrders", new[] { "IdEmployee" });
            DropIndex("dbo.ProductionOrders", new[] { "IdProduct" });
            DropIndex("dbo.ProductionOrders", new[] { "IdProductionState" });
            DropIndex("dbo.ProductionOrderDetails", new[] { "IdProductionOrder" });
            DropIndex("dbo.ProductionOrderDetails", new[] { "IdProductComponent" });
            DropIndex("dbo.ProductComponents", new[] { "IdProductComponent" });
            DropIndex("dbo.ProductComponents", new[] { "IdProduct" });
            DropIndex("dbo.Movements", new[] { "IdEmployee" });
            DropIndex("dbo.Movements", new[] { "IdMotive" });
            DropIndex("dbo.MovementDetails", new[] { "IdProduct" });
            DropIndex("dbo.MovementDetails", new[] { "IdMovement" });
            DropIndex("dbo.ComprobantePurchases", new[] { "IdEmployee" });
            DropIndex("dbo.ComprobantePurchases", new[] { "IdProvider" });
            DropIndex("dbo.Transfers", new[] { "IdTransferType" });
            DropIndex("dbo.Transfers", new[] { "IdDepositDestination" });
            DropIndex("dbo.Transfers", new[] { "IdDepositOrigin" });
            DropIndex("dbo.Products", new[] { "IdProductType" });
            DropIndex("dbo.ComprobantePurchaseDetails", new[] { "IdProduct" });
            DropIndex("dbo.ComprobantePurchaseDetails", new[] { "IdComprobantePurchase" });
            DropTable("dbo.Users");
            DropTable("dbo.TransferDetails");
            DropTable("dbo.Stocks");
            DropTable("dbo.ProductionStates");
            DropTable("dbo.ProductionOrders");
            DropTable("dbo.ProductionOrderDetails");
            DropTable("dbo.ProductComponents");
            DropTable("dbo.MovementMotives");
            DropTable("dbo.Movements");
            DropTable("dbo.MovementDetails");
            DropTable("dbo.Providers");
            DropTable("dbo.Employees");
            DropTable("dbo.ComprobantePurchases");
            DropTable("dbo.TransferTypes");
            DropTable("dbo.Deposits");
            DropTable("dbo.Transfers");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.ComprobantePurchaseDetails");
        }
    }
}
