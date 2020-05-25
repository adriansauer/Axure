namespace Axure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 200),
                        RUC = c.String(nullable: false, maxLength: 20),
                        CreditMaximum = c.Int(nullable: false),
                        CreditPending = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        IncomeDeadlineId = c.Int(nullable: false),
                        FeeQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IncomeDeadlines", t => t.IncomeDeadlineId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .Index(t => t.InvoiceId)
                .Index(t => t.IncomeDeadlineId);
            
            CreateTable(
                "dbo.IncomeDeadlines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthsQuantity = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateInvoiceId = c.Int(nullable: false),
                        PaymentTermId = c.Int(nullable: false),
                        OrderSaleId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        InvoiceNumber = c.String(maxLength: 20),
                        ClientName = c.String(nullable: false, maxLength: 100),
                        ClientRUC = c.String(nullable: false, maxLength: 20),
                        ClientAddress = c.String(nullable: false, maxLength: 200),
                        Total = c.Int(nullable: false),
                        TotalIVA10 = c.Int(nullable: false),
                        TotalIVA5 = c.Int(nullable: false),
                        TotalExempt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.OrderSales", t => t.OrderSaleId)
                .ForeignKey("dbo.PaymentTerms", t => t.PaymentTermId)
                .ForeignKey("dbo.StateInvoices", t => t.StateInvoiceId)
                .Index(t => t.StateInvoiceId)
                .Index(t => t.PaymentTermId)
                .Index(t => t.OrderSaleId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ClientId);
            
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
                "dbo.OrderSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        StateOrderSaleId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        OrderNumber = c.String(nullable: false, maxLength: 20),
                        Date = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
<<<<<<< HEAD:back_end/Axure/Migrations/202005121704297_Initial.cs
                .ForeignKey("dbo.MovementTypes", t => t.MovementTypeId, cascadeDelete: true)
                .Index(t => t.MovementTypeId);
=======
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.StateOrderSales", t => t.StateOrderSaleId)
                .Index(t => t.ClientId)
                .Index(t => t.StateOrderSaleId)
                .Index(t => t.EmployeeId);
>>>>>>> master:back_end/Axure/Migrations/202005121132267_Initial.cs
            
            CreateTable(
                "dbo.StateOrderSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentTerms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StateInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deposits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeeCredits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditId = c.Int(nullable: false),
                        FeeNumber = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Credits", t => t.CreditId)
                .Index(t => t.CreditId);
            
            CreateTable(
                "dbo.IncomeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeeCreditId = c.Int(nullable: false),
                        IncomeTypeId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeeCredits", t => t.FeeCreditId)
                .ForeignKey("dbo.IncomeTypes", t => t.IncomeTypeId)
                .Index(t => t.FeeCreditId)
                .Index(t => t.IncomeTypeId);
            
            CreateTable(
                "dbo.IncomeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncomeTypeId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IncomeTypes", t => t.IncomeTypeId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .Index(t => t.IncomeTypeId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        PricePurchase = c.Int(nullable: false),
                        PriceUnit = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        IVAQuantity = c.Int(nullable: false),
                        IVATotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductTypeId = c.Int(nullable: false),
                        IVAId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 200),
                        Cost = c.Int(nullable: false),
                        QuantityMin = c.Int(nullable: false),
                        Barcode = c.String(maxLength: 20),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IVAs", t => t.IVAId)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId)
                .Index(t => t.ProductTypeId)
                .Index(t => t.IVAId);
            
            CreateTable(
                "dbo.IVAs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 10),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.MovementMotives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovementTypeId = c.Int(nullable: false),
                        Motive = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovementTypes", t => t.MovementTypeId)
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
                .ForeignKey("dbo.MovementProducts", t => t.MovementProductId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.MovementProductId);
            
            CreateTable(
                "dbo.MovementProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TotalCost = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        DepositId = c.Int(nullable: false),
                        MovementTypeId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Observation = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deposits", t => t.DepositId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.MovementTypes", t => t.MovementTypeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.DepositId)
                .Index(t => t.MovementTypeId);
            
            CreateTable(
                "dbo.OrderSaleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        QuantityPending = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderSales", t => t.SaleOrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.SaleOrderId)
                .Index(t => t.ProductId);
            
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
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Products", t => t.ProductComponentId)
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
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.ProductionOrders", t => t.ProductionOrderId)
                .Index(t => t.ProductionOrderId)
                .Index(t => t.ProductId);
            
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
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.ProductionStates", t => t.ProductionStateId)
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
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId)
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
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
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
                "dbo.ReceiptDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiptId = c.Int(nullable: false),
                        FeeCreditId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeeCredits", t => t.FeeCreditId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .ForeignKey("dbo.Receipts", t => t.ReceiptId)
                .Index(t => t.ReceiptId)
                .Index(t => t.FeeCreditId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ClientName = c.String(nullable: false, maxLength: 100),
                        Amount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.ClientId);
            
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
                .ForeignKey("dbo.Deposits", t => t.DepositId)
                .ForeignKey("dbo.Products", t => t.ProductId)
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
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Transfers", t => t.TransferId)
                .Index(t => t.ProductId)
                .Index(t => t.TransferId);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepositOriginId = c.Int(nullable: false),
                        DepositDestinationId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Observation = c.String(maxLength: 200),
                        Number = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deposits", t => t.DepositDestinationId)
                .ForeignKey("dbo.Deposits", t => t.DepositOriginId)
                .Index(t => t.DepositOriginId)
                .Index(t => t.DepositDestinationId);
            
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
                .ForeignKey("dbo.Employees", t => t.IdEmployee)
                .Index(t => t.IdEmployee);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "IdEmployee", "dbo.Employees");
            DropForeignKey("dbo.TransferDetails", "TransferId", "dbo.Transfers");
            DropForeignKey("dbo.Transfers", "DepositOriginId", "dbo.Deposits");
            DropForeignKey("dbo.Transfers", "DepositDestinationId", "dbo.Deposits");
            DropForeignKey("dbo.TransferDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Stocks", "DepositId", "dbo.Deposits");
            DropForeignKey("dbo.ReceiptDetails", "ReceiptId", "dbo.Receipts");
            DropForeignKey("dbo.Receipts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ReceiptDetails", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.ReceiptDetails", "FeeCreditId", "dbo.FeeCredits");
            DropForeignKey("dbo.PurchaseOrderDetails", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.PurchaseOrders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PurchaseOrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductionOrderDetails", "ProductionOrderId", "dbo.ProductionOrders");
            DropForeignKey("dbo.ProductionOrders", "ProductionStateId", "dbo.ProductionStates");
            DropForeignKey("dbo.ProductionOrders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ProductionOrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductComponents", "ProductComponentId", "dbo.Products");
            DropForeignKey("dbo.ProductComponents", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderSaleDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderSaleDetails", "SaleOrderId", "dbo.OrderSales");
            DropForeignKey("dbo.MovementProductDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.MovementProductDetails", "MovementProductId", "dbo.MovementProducts");
            DropForeignKey("dbo.MovementProducts", "MovementTypeId", "dbo.MovementTypes");
            DropForeignKey("dbo.MovementProducts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.MovementProducts", "DepositId", "dbo.Deposits");
            DropForeignKey("dbo.MovementMotives", "MovementTypeId", "dbo.MovementTypes");
            DropForeignKey("dbo.InvoiceItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.Products", "IVAId", "dbo.IVAs");
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Incomes", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Incomes", "IncomeTypeId", "dbo.IncomeTypes");
            DropForeignKey("dbo.IncomeDetails", "IncomeTypeId", "dbo.IncomeTypes");
            DropForeignKey("dbo.IncomeDetails", "FeeCreditId", "dbo.FeeCredits");
            DropForeignKey("dbo.FeeCredits", "CreditId", "dbo.Credits");
            DropForeignKey("dbo.Credits", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "StateInvoiceId", "dbo.StateInvoices");
            DropForeignKey("dbo.Invoices", "PaymentTermId", "dbo.PaymentTerms");
            DropForeignKey("dbo.Invoices", "OrderSaleId", "dbo.OrderSales");
            DropForeignKey("dbo.OrderSales", "StateOrderSaleId", "dbo.StateOrderSales");
            DropForeignKey("dbo.OrderSales", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.OrderSales", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Invoices", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Invoices", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Credits", "IncomeDeadlineId", "dbo.IncomeDeadlines");
            DropIndex("dbo.Users", new[] { "IdEmployee" });
            DropIndex("dbo.Transfers", new[] { "DepositDestinationId" });
            DropIndex("dbo.Transfers", new[] { "DepositOriginId" });
            DropIndex("dbo.TransferDetails", new[] { "TransferId" });
            DropIndex("dbo.TransferDetails", new[] { "ProductId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Stocks", new[] { "DepositId" });
            DropIndex("dbo.Receipts", new[] { "ClientId" });
            DropIndex("dbo.ReceiptDetails", new[] { "InvoiceId" });
            DropIndex("dbo.ReceiptDetails", new[] { "FeeCreditId" });
            DropIndex("dbo.ReceiptDetails", new[] { "ReceiptId" });
            DropIndex("dbo.PurchaseOrders", new[] { "EmployeeId" });
            DropIndex("dbo.PurchaseOrders", new[] { "ProviderId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "PurchaseOrderId" });
            DropIndex("dbo.ProductionOrders", new[] { "EmployeeId" });
            DropIndex("dbo.ProductionOrders", new[] { "ProductionStateId" });
            DropIndex("dbo.ProductionOrderDetails", new[] { "ProductId" });
            DropIndex("dbo.ProductionOrderDetails", new[] { "ProductionOrderId" });
            DropIndex("dbo.ProductComponents", new[] { "ProductComponentId" });
            DropIndex("dbo.ProductComponents", new[] { "ProductId" });
            DropIndex("dbo.OrderSaleDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderSaleDetails", new[] { "SaleOrderId" });
            DropIndex("dbo.MovementProducts", new[] { "MovementTypeId" });
            DropIndex("dbo.MovementProducts", new[] { "DepositId" });
            DropIndex("dbo.MovementProducts", new[] { "EmployeeId" });
            DropIndex("dbo.MovementProductDetails", new[] { "MovementProductId" });
            DropIndex("dbo.MovementProductDetails", new[] { "ProductId" });
            DropIndex("dbo.MovementMotives", new[] { "MovementTypeId" });
            DropIndex("dbo.Products", new[] { "IVAId" });
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropIndex("dbo.InvoiceItems", new[] { "ProductId" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            DropIndex("dbo.Incomes", new[] { "InvoiceId" });
            DropIndex("dbo.Incomes", new[] { "IncomeTypeId" });
            DropIndex("dbo.IncomeDetails", new[] { "IncomeTypeId" });
            DropIndex("dbo.IncomeDetails", new[] { "FeeCreditId" });
            DropIndex("dbo.FeeCredits", new[] { "CreditId" });
            DropIndex("dbo.OrderSales", new[] { "EmployeeId" });
            DropIndex("dbo.OrderSales", new[] { "StateOrderSaleId" });
            DropIndex("dbo.OrderSales", new[] { "ClientId" });
            DropIndex("dbo.Invoices", new[] { "ClientId" });
            DropIndex("dbo.Invoices", new[] { "EmployeeId" });
            DropIndex("dbo.Invoices", new[] { "OrderSaleId" });
            DropIndex("dbo.Invoices", new[] { "PaymentTermId" });
            DropIndex("dbo.Invoices", new[] { "StateInvoiceId" });
            DropIndex("dbo.Credits", new[] { "IncomeDeadlineId" });
            DropIndex("dbo.Credits", new[] { "InvoiceId" });
            DropTable("dbo.Users");
            DropTable("dbo.Transfers");
            DropTable("dbo.TransferDetails");
            DropTable("dbo.Stocks");
            DropTable("dbo.Settings");
            DropTable("dbo.Receipts");
            DropTable("dbo.ReceiptDetails");
            DropTable("dbo.Providers");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseOrderDetails");
            DropTable("dbo.ProductionStates");
            DropTable("dbo.ProductionOrders");
            DropTable("dbo.ProductionOrderDetails");
            DropTable("dbo.ProductComponents");
            DropTable("dbo.OrderSaleDetails");
            DropTable("dbo.MovementProducts");
            DropTable("dbo.MovementProductDetails");
            DropTable("dbo.MovementTypes");
            DropTable("dbo.MovementMotives");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.IVAs");
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Incomes");
            DropTable("dbo.IncomeTypes");
            DropTable("dbo.IncomeDetails");
            DropTable("dbo.FeeCredits");
            DropTable("dbo.Deposits");
            DropTable("dbo.StateInvoices");
            DropTable("dbo.PaymentTerms");
            DropTable("dbo.StateOrderSales");
            DropTable("dbo.OrderSales");
            DropTable("dbo.Employees");
            DropTable("dbo.Invoices");
            DropTable("dbo.IncomeDeadlines");
            DropTable("dbo.Credits");
            DropTable("dbo.Clients");
        }
    }
}
