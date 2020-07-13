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
                        Phone = c.String(nullable: false, maxLength: 20),
                        RUC = c.String(nullable: false, maxLength: 20),
                        CreditMaximum = c.Int(nullable: false),
                        CreditPending = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreditNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReturnOrderId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReturnOrders", t => t.ReturnOrderId)
                .Index(t => t.ReturnOrderId);
            
            CreateTable(
                "dbo.ReturnOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .Index(t => t.ProviderId);
            
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
                "dbo.Debts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        FeeQuantity = c.Int(nullable: false),
                        RemainingDebt = c.Int(nullable: false),
                        FeeType = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderSaleId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        SaleCondition = c.String(maxLength: 20),
                        Status = c.String(maxLength: 20),
                        InvoiceNumber = c.String(maxLength: 20),
                        ClientName = c.String(nullable: false, maxLength: 100),
                        ClientRUC = c.String(nullable: false, maxLength: 20),
                        ClientAddress = c.String(nullable: false, maxLength: 200),
                        Date = c.DateTime(nullable: false),
                        Total = c.Int(nullable: false),
                        TaxTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.OrderSales", t => t.OrderSaleId)
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
                        EmployeeId = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                        OrderNumber = c.String(nullable: false, maxLength: 20),
                        Date = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.ClientId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Deposits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DebtId = c.Int(nullable: false),
                        FeeNumber = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Debts", t => t.DebtId)
                .Index(t => t.DebtId);
            
            CreateTable(
                "dbo.IncomeFees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeeId = c.Int(nullable: false),
                        IncomeTypeId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fees", t => t.FeeId)
                .ForeignKey("dbo.IncomeTypes", t => t.IncomeTypeId)
                .Index(t => t.FeeId)
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
                        PriceUnit = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        TaxQuantity = c.Int(nullable: false),
                        TaxTotal = c.Int(nullable: false),
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
                        TaxId = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 200),
                        Cost = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        QuantityMin = c.Int(nullable: false),
                        Barcode = c.String(maxLength: 20),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId)
                .ForeignKey("dbo.Taxes", t => t.TaxId)
                .Index(t => t.ProductTypeId)
                .Index(t => t.TaxId)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
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
                "dbo.Taxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 10),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceTaxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        TaxId = c.Int(nullable: false),
                        TaxPercentage = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .ForeignKey("dbo.Taxes", t => t.TaxId)
                .Index(t => t.InvoiceId)
                .Index(t => t.TaxId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderSales", t => t.SaleOrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.SaleOrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PriceRequestDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriceRequestId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceRequests", t => t.PriceRequestId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.PriceRequestId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PriceRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .Index(t => t.ProviderId);
            
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
                "dbo.ProviderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .Index(t => t.ProviderId)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProviderInvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderInvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        PriceUnit = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        TaxQuantity = c.Int(nullable: false),
                        TaxTotal = c.Int(nullable: false),
                        ReturndQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.ProviderInvoices", t => t.ProviderInvoiceId)
                .Index(t => t.ProviderInvoiceId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProviderInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        PurchaseOrderId = c.Int(nullable: false),
                        Status = c.String(maxLength: 20),
                        InvoiceNumber = c.String(maxLength: 20),
                        ProviderName = c.String(nullable: false, maxLength: 100),
                        ProviderRUC = c.String(nullable: false, maxLength: 20),
                        ProviderAddress = c.String(nullable: false, maxLength: 200),
                        Date = c.DateTime(nullable: false),
                        Total = c.Int(nullable: false),
                        TaxTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId)
                .Index(t => t.ProviderId)
                .Index(t => t.PurchaseOrderId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.PurchaseOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        QuantityPending = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PurchaseRequestDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseRequestId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.PurchaseRequests", t => t.PurchaseRequestId)
                .Index(t => t.PurchaseRequestId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PurchaseRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReceiptDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiptId = c.Int(nullable: false),
                        FeeId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fees", t => t.FeeId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .ForeignKey("dbo.Receipts", t => t.ReceiptId)
                .Index(t => t.ReceiptId)
                .Index(t => t.FeeId)
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
                "dbo.ReturnOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReturnOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.ReturnOrders", t => t.ReturnOrderId)
                .Index(t => t.ReturnOrderId)
                .Index(t => t.ProductId);
            
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
            DropForeignKey("dbo.ReturnOrderDetails", "ReturnOrderId", "dbo.ReturnOrders");
            DropForeignKey("dbo.ReturnOrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ReceiptDetails", "ReceiptId", "dbo.Receipts");
            DropForeignKey("dbo.Receipts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ReceiptDetails", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.ReceiptDetails", "FeeId", "dbo.Fees");
            DropForeignKey("dbo.PurchaseRequestDetails", "PurchaseRequestId", "dbo.PurchaseRequests");
            DropForeignKey("dbo.PurchaseRequestDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseOrderDetails", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProviderInvoiceItems", "ProviderInvoiceId", "dbo.ProviderInvoices");
            DropForeignKey("dbo.ProviderInvoices", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.ProviderInvoices", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.ProviderInvoiceItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProviderDetails", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.ProviderDetails", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductionOrderDetails", "ProductionOrderId", "dbo.ProductionOrders");
            DropForeignKey("dbo.ProductionOrders", "ProductionStateId", "dbo.ProductionStates");
            DropForeignKey("dbo.ProductionOrders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ProductionOrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductComponents", "ProductComponentId", "dbo.Products");
            DropForeignKey("dbo.ProductComponents", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PriceRequestDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PriceRequestDetails", "PriceRequestId", "dbo.PriceRequests");
            DropForeignKey("dbo.PriceRequests", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.OrderSaleDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderSaleDetails", "SaleOrderId", "dbo.OrderSales");
            DropForeignKey("dbo.MovementProductDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.MovementProductDetails", "MovementProductId", "dbo.MovementProducts");
            DropForeignKey("dbo.MovementProducts", "MovementTypeId", "dbo.MovementTypes");
            DropForeignKey("dbo.MovementProducts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.MovementProducts", "DepositId", "dbo.Deposits");
            DropForeignKey("dbo.MovementMotives", "MovementTypeId", "dbo.MovementTypes");
            DropForeignKey("dbo.InvoiceTaxes", "TaxId", "dbo.Taxes");
            DropForeignKey("dbo.InvoiceTaxes", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "TaxId", "dbo.Taxes");
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Incomes", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Incomes", "IncomeTypeId", "dbo.IncomeTypes");
            DropForeignKey("dbo.IncomeFees", "IncomeTypeId", "dbo.IncomeTypes");
            DropForeignKey("dbo.IncomeFees", "FeeId", "dbo.Fees");
            DropForeignKey("dbo.Fees", "DebtId", "dbo.Debts");
            DropForeignKey("dbo.Debts", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "OrderSaleId", "dbo.OrderSales");
            DropForeignKey("dbo.OrderSales", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.OrderSales", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Invoices", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Invoices", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.CreditNotes", "ReturnOrderId", "dbo.ReturnOrders");
            DropForeignKey("dbo.ReturnOrders", "ProviderId", "dbo.Providers");
            DropIndex("dbo.Users", new[] { "IdEmployee" });
            DropIndex("dbo.Transfers", new[] { "DepositDestinationId" });
            DropIndex("dbo.Transfers", new[] { "DepositOriginId" });
            DropIndex("dbo.TransferDetails", new[] { "TransferId" });
            DropIndex("dbo.TransferDetails", new[] { "ProductId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Stocks", new[] { "DepositId" });
            DropIndex("dbo.ReturnOrderDetails", new[] { "ProductId" });
            DropIndex("dbo.ReturnOrderDetails", new[] { "ReturnOrderId" });
            DropIndex("dbo.Receipts", new[] { "ClientId" });
            DropIndex("dbo.ReceiptDetails", new[] { "InvoiceId" });
            DropIndex("dbo.ReceiptDetails", new[] { "FeeId" });
            DropIndex("dbo.ReceiptDetails", new[] { "ReceiptId" });
            DropIndex("dbo.PurchaseRequestDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseRequestDetails", new[] { "PurchaseRequestId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrders", new[] { "ProviderId" });
            DropIndex("dbo.ProviderInvoices", new[] { "PurchaseOrderId" });
            DropIndex("dbo.ProviderInvoices", new[] { "ProviderId" });
            DropIndex("dbo.ProviderInvoiceItems", new[] { "ProductId" });
            DropIndex("dbo.ProviderInvoiceItems", new[] { "ProviderInvoiceId" });
            DropIndex("dbo.ProviderDetails", new[] { "ProductCategoryId" });
            DropIndex("dbo.ProviderDetails", new[] { "ProviderId" });
            DropIndex("dbo.ProductionOrders", new[] { "EmployeeId" });
            DropIndex("dbo.ProductionOrders", new[] { "ProductionStateId" });
            DropIndex("dbo.ProductionOrderDetails", new[] { "ProductId" });
            DropIndex("dbo.ProductionOrderDetails", new[] { "ProductionOrderId" });
            DropIndex("dbo.ProductComponents", new[] { "ProductComponentId" });
            DropIndex("dbo.ProductComponents", new[] { "ProductId" });
            DropIndex("dbo.PriceRequests", new[] { "ProviderId" });
            DropIndex("dbo.PriceRequestDetails", new[] { "ProductId" });
            DropIndex("dbo.PriceRequestDetails", new[] { "PriceRequestId" });
            DropIndex("dbo.OrderSaleDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderSaleDetails", new[] { "SaleOrderId" });
            DropIndex("dbo.MovementProducts", new[] { "MovementTypeId" });
            DropIndex("dbo.MovementProducts", new[] { "DepositId" });
            DropIndex("dbo.MovementProducts", new[] { "EmployeeId" });
            DropIndex("dbo.MovementProductDetails", new[] { "MovementProductId" });
            DropIndex("dbo.MovementProductDetails", new[] { "ProductId" });
            DropIndex("dbo.MovementMotives", new[] { "MovementTypeId" });
            DropIndex("dbo.InvoiceTaxes", new[] { "TaxId" });
            DropIndex("dbo.InvoiceTaxes", new[] { "InvoiceId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.Products", new[] { "TaxId" });
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropIndex("dbo.InvoiceItems", new[] { "ProductId" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            DropIndex("dbo.Incomes", new[] { "InvoiceId" });
            DropIndex("dbo.Incomes", new[] { "IncomeTypeId" });
            DropIndex("dbo.IncomeFees", new[] { "IncomeTypeId" });
            DropIndex("dbo.IncomeFees", new[] { "FeeId" });
            DropIndex("dbo.Fees", new[] { "DebtId" });
            DropIndex("dbo.OrderSales", new[] { "EmployeeId" });
            DropIndex("dbo.OrderSales", new[] { "ClientId" });
            DropIndex("dbo.Invoices", new[] { "ClientId" });
            DropIndex("dbo.Invoices", new[] { "EmployeeId" });
            DropIndex("dbo.Invoices", new[] { "OrderSaleId" });
            DropIndex("dbo.Debts", new[] { "InvoiceId" });
            DropIndex("dbo.ReturnOrders", new[] { "ProviderId" });
            DropIndex("dbo.CreditNotes", new[] { "ReturnOrderId" });
            DropTable("dbo.Users");
            DropTable("dbo.Transfers");
            DropTable("dbo.TransferDetails");
            DropTable("dbo.Stocks");
            DropTable("dbo.Settings");
            DropTable("dbo.ReturnOrderDetails");
            DropTable("dbo.Receipts");
            DropTable("dbo.ReceiptDetails");
            DropTable("dbo.PurchaseRequests");
            DropTable("dbo.PurchaseRequestDetails");
            DropTable("dbo.PurchaseOrderDetails");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.ProviderInvoices");
            DropTable("dbo.ProviderInvoiceItems");
            DropTable("dbo.ProviderDetails");
            DropTable("dbo.ProductionStates");
            DropTable("dbo.ProductionOrders");
            DropTable("dbo.ProductionOrderDetails");
            DropTable("dbo.ProductComponents");
            DropTable("dbo.PriceRequests");
            DropTable("dbo.PriceRequestDetails");
            DropTable("dbo.OrderSaleDetails");
            DropTable("dbo.MovementProducts");
            DropTable("dbo.MovementProductDetails");
            DropTable("dbo.MovementTypes");
            DropTable("dbo.MovementMotives");
            DropTable("dbo.InvoiceTaxes");
            DropTable("dbo.Taxes");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Incomes");
            DropTable("dbo.IncomeTypes");
            DropTable("dbo.IncomeFees");
            DropTable("dbo.Fees");
            DropTable("dbo.Deposits");
            DropTable("dbo.OrderSales");
            DropTable("dbo.Employees");
            DropTable("dbo.Invoices");
            DropTable("dbo.Debts");
            DropTable("dbo.Providers");
            DropTable("dbo.ReturnOrders");
            DropTable("dbo.CreditNotes");
            DropTable("dbo.Clients");
        }
    }
}
