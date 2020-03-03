use AXURE

CREATE TABLE Deposits(
	Id numeric(3) identity(1,1) PRIMARY KEY NOT NULL,
	NameD VARCHAR(50) NOT NULL
)

create table ProductTypes(
	Id numeric(3) identity(1,1) primary key not null,
	TypeP varchar(50) not null
)
create table Products(
	Id numeric(3) identity(1,1) primary key not null,
	NameP varchar(200) not null,
	DescriptionP varchar(200),
	Cost numeric(8) not null,
	ProductType numeric(3) foreign key references ProductTypes (id) not null,
	QuantityMin numeric(4) not null,
	Barcode varchar(15) not null
)

create table TransferTypes(
	Id numeric(3) identity(1,1) primary key not null,
	TypeT varchar(50) not null
)

CREATE TABLE Transfers(
	Id numeric(3) identity(1,1) PRIMARY KEY NOT NULL,
	DateT DATE NOT NULL,
	Observation VARCHAR(200),
	IdDepositOrigin numeric(3) foreign key references Deposits (Id) not null,
	IdDepositDestination numeric(3) foreign key references Deposits (Id) not null,
	IdTrasnferType numeric(3) foreign key references TransferTypes (id) not null
)

create table TransferDetails(
	Id numeric(3) identity(1,1) primary key not null,
	IdTransfer numeric(3) foreign key references Transfers (id) not null,
	IdProduct numeric(3) foreign key references Products (id) not null,
	Quantity numeric(5) not null
)

create table Stocks(
	Id numeric(3) identity(1,1) primary key not null,
    IdProduct numeric(3) foreign key references Products (id) not null,
	IdDeposit numeric(3) foreign key references Deposits (id) not null,
	Quantity numeric(5) not null
)

create table Providers(
	Id numeric(3) identity(1,1) primary key not null,
	NameP varchar(200) not null,
	AddressP varchar(200),
	Phone varchar(20),
	Credit numeric(12)
)

create table ProductComponents(
	Id numeric(3) identity(1,1) primary key not null,
	IdProduct numeric(3) foreign key references Products (id),
	IdProductComponent numeric(3) foreign key references Products (id),
	Quantity numeric(4) not null
)

create table Employees(
	Id numeric(3) identity(1,1) primary key not null,
	NameE varchar(200) not null
)

create table ProductionStates(
	Id numeric(3) identity(1,1) primary key not null,
	PState varchar(50)
)

create table ProductionOrders(
	Id numeric(3) identity(1,1) primary key not null,
	IdProduct numeric(3) foreign key references Products (id) not null,
	IdProductionState numeric(3) foreign key references ProductionStates (id) not null,
	DateT date not null, 
	Quantity numeric(4) not null,
	IdEmployee numeric(3) foreign key references Employees (id) not null
)

create Table ProductionOrderDetails(
	Id numeric(3) identity(1,1) primary key not null,
	IdProduction numeric(3) foreign key references ProductionStates (id) not null,
	IdProductComponent numeric(3) foreign key references ProductComponents (id) not null,
	Quantity numeric(3) not null
)

create table MovementMotives(
	Id numeric(3) identity(1,1) primary key not null,
	Motive varchar(50) not null
)

create table Movements(
	Id numeric(3) identity(1,1) primary key not null,
	DateM date not null,
	IdEmployee numeric(3) foreign key references Employees (id) not null,
	IdMovementMotive numeric(3) foreign key references MovementMotives (id) not null
)

create table MovementDetails(
	Id numeric(3) identity(1,1) primary key not null,
	IdMovement numeric(3) foreign key references Movements (id),
	IdProduct numeric(3) foreign key references Products (id),
	Quantity numeric(4) not null
)

create table ComprobantePurchases(
	Id numeric(3) identity(1,1) primary key not null,
	DateC date not null,
	IdEmployee numeric(3) foreign key references Employees (id) not null,
	IdProvider numeric(3) foreign key references Providers (id) not null
)

create table ComprobantePurchaseDetails(
	Id numeric(3) identity(1,1) primary key not null,
	IdComprobantePurchase numeric(3) foreign key references ComprobantePurchases (id),
	IdProduct numeric(3) foreign key references Products (id) not null,
	Quantity numeric(4) not null
)