namespace Axure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deposits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CI = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 200),
                        RUC = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(maxLength: 20),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovementMotives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovementTypeId = c.Int(nullable: false),
                        Motive = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovementTypes", t => t.MovementTypeId, cascadeDelete: false)
                .Index(t => t.MovementTypeId);
            
            CreateTable(
                "dbo.MovementTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovementProductDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        MovementProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalCost = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        Observation = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovementProductionTypes", t => t.MovementProductId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .Index(t => t.ProductId)
                .Index(t => t.MovementProductId);
            
            CreateTable(
                "dbo.MovementProductionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 200),
                        Cost = c.Int(nullable: false),
                        QuantityMin = c.Int(nullable: false),
                        Barcode = c.String(maxLength: 20),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId, cascadeDelete: false)
                .Index(t => t.ProductTypeId);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovementProductionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovementProductionId = c.Int(nullable: false),
                        ProductionOrderId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovementProductions", t => t.MovementProductionId, cascadeDelete: false)
                .ForeignKey("dbo.ProductionOrders", t => t.ProductionOrderId, cascadeDelete: false)
                .Index(t => t.MovementProductionId)
                .Index(t => t.ProductionOrderId);
            
            CreateTable(
                "dbo.MovementProductions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        MovementProductionTypeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.MovementProductionTypes", t => t.MovementProductionTypeId, cascadeDelete: false)
                .Index(t => t.EmployeeId)
                .Index(t => t.MovementProductionTypeId);
            
            CreateTable(
                "dbo.ProductionOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductionStateId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Observation = c.String(maxLength: 200),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.ProductionStates", t => t.ProductionStateId, cascadeDelete: false)
                .Index(t => t.ProductionStateId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ProductionStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        State = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovementProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TotalCost = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        DepositId = c.Int(nullable: false),
                        MovementMotiveId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deposits", t => t.DepositId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.MovementMotives", t => t.MovementMotiveId, cascadeDelete: false)
                .Index(t => t.EmployeeId)
                .Index(t => t.DepositId)
                .Index(t => t.MovementMotiveId);
            
            CreateTable(
                "dbo.ProductComponents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductComponentId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductComponentId, cascadeDelete: false)
                .Index(t => t.ProductId)
                .Index(t => t.ProductComponentId);
            
            CreateTable(
                "dbo.ProductionOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductionOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.ProductionOrders", t => t.ProductionOrderId, cascadeDelete: false)
                .Index(t => t.ProductionOrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PurchaseOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId, cascadeDelete: false)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: false)
                .Index(t => t.ProviderId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 20),
                        Credit = c.Int(nullable: false),
                        RUC = c.String(maxLength: 20),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 50),
                        Value = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepositId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deposits", t => t.DepositId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .Index(t => t.DepositId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.TransferDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        TransferId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Transfers", t => t.TransferId, cascadeDelete: false)
                .Index(t => t.ProductId)
                .Index(t => t.TransferId);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepositOriginId = c.Int(nullable: false),
                        DepositDestinationId = c.Int(nullable: false),
                        TransferTypeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Observation = c.String(maxLength: 200),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deposits", t => t.DepositDestinationId, cascadeDelete: false)
                .ForeignKey("dbo.Deposits", t => t.DepositOriginId, cascadeDelete: false)
                .ForeignKey("dbo.TransferTypes", t => t.TransferTypeId, cascadeDelete: false)
                .Index(t => t.DepositOriginId)
                .Index(t => t.DepositDestinationId)
                .Index(t => t.TransferTypeId);
            
            CreateTable(
                "dbo.TransferTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.TransferDetails", "TransferId", "dbo.Transfers");
            DropForeignKey("dbo.Transfers", "TransferTypeId", "dbo.TransferTypes");
            DropForeignKey("dbo.Transfers", "DepositOriginId", "dbo.Deposits");
            DropForeignKey("dbo.Transfers", "DepositDestinationId", "dbo.Deposits");
            DropForeignKey("dbo.TransferDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Stocks", "DepositId", "dbo.Deposits");
            DropForeignKey("dbo.PurchaseOrderDetails", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.PurchaseOrders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PurchaseOrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductionOrderDetails", "ProductionOrderId", "dbo.ProductionOrders");
            DropForeignKey("dbo.ProductionOrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductComponents", "ProductComponentId", "dbo.Products");
            DropForeignKey("dbo.ProductComponents", "ProductId", "dbo.Products");
            DropForeignKey("dbo.MovementProducts", "MovementMotiveId", "dbo.MovementMotives");
            DropForeignKey("dbo.MovementProducts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.MovementProducts", "DepositId", "dbo.Deposits");
            DropForeignKey("dbo.MovementProductionDetails", "ProductionOrderId", "dbo.ProductionOrders");
            DropForeignKey("dbo.ProductionOrders", "ProductionStateId", "dbo.ProductionStates");
            DropForeignKey("dbo.ProductionOrders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.MovementProductionDetails", "MovementProductionId", "dbo.MovementProductions");
            DropForeignKey("dbo.MovementProductions", "MovementProductionTypeId", "dbo.MovementProductionTypes");
            DropForeignKey("dbo.MovementProductions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.MovementProductDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.MovementProductDetails", "MovementProductId", "dbo.MovementProductionTypes");
            DropForeignKey("dbo.MovementMotives", "MovementTypeId", "dbo.MovementTypes");
            DropIndex("dbo.Users", new[] { "IdEmployee" });
            DropIndex("dbo.Transfers", new[] { "TransferTypeId" });
            DropIndex("dbo.Transfers", new[] { "DepositDestinationId" });
            DropIndex("dbo.Transfers", new[] { "DepositOriginId" });
            DropIndex("dbo.TransferDetails", new[] { "TransferId" });
            DropIndex("dbo.TransferDetails", new[] { "ProductId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Stocks", new[] { "DepositId" });
            DropIndex("dbo.PurchaseOrders", new[] { "EmployeeId" });
            DropIndex("dbo.PurchaseOrders", new[] { "ProviderId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "PurchaseOrderId" });
            DropIndex("dbo.ProductionOrderDetails", new[] { "ProductId" });
            DropIndex("dbo.ProductionOrderDetails", new[] { "ProductionOrderId" });
            DropIndex("dbo.ProductComponents", new[] { "ProductComponentId" });
            DropIndex("dbo.ProductComponents", new[] { "ProductId" });
            DropIndex("dbo.MovementProducts", new[] { "MovementMotiveId" });
            DropIndex("dbo.MovementProducts", new[] { "DepositId" });
            DropIndex("dbo.MovementProducts", new[] { "EmployeeId" });
            DropIndex("dbo.ProductionOrders", new[] { "EmployeeId" });
            DropIndex("dbo.ProductionOrders", new[] { "ProductionStateId" });
            DropIndex("dbo.MovementProductions", new[] { "MovementProductionTypeId" });
            DropIndex("dbo.MovementProductions", new[] { "EmployeeId" });
            DropIndex("dbo.MovementProductionDetails", new[] { "ProductionOrderId" });
            DropIndex("dbo.MovementProductionDetails", new[] { "MovementProductionId" });
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropIndex("dbo.MovementProductDetails", new[] { "MovementProductId" });
            DropIndex("dbo.MovementProductDetails", new[] { "ProductId" });
            DropIndex("dbo.MovementMotives", new[] { "MovementTypeId" });
            DropTable("dbo.Users");
            DropTable("dbo.TransferTypes");
            DropTable("dbo.Transfers");
            DropTable("dbo.TransferDetails");
            DropTable("dbo.Stocks");
            DropTable("dbo.Settings");
            DropTable("dbo.Providers");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseOrderDetails");
            DropTable("dbo.ProductionOrderDetails");
            DropTable("dbo.ProductComponents");
            DropTable("dbo.MovementProducts");
            DropTable("dbo.ProductionStates");
            DropTable("dbo.ProductionOrders");
            DropTable("dbo.MovementProductions");
            DropTable("dbo.MovementProductionDetails");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.MovementProductionTypes");
            DropTable("dbo.MovementProductDetails");
            DropTable("dbo.MovementTypes");
            DropTable("dbo.MovementMotives");
            DropTable("dbo.Employees");
            DropTable("dbo.Deposits");
        }
    }
}
