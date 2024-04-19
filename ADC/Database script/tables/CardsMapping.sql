--Id
--CustomerId
--CardPan
--MaskPan
--ClientID
--CardType [Prepaid/Credit/Debit]
--CardVeCardsMapping
--ndor [VISA/MASTER/UNIONPAY]
--NameOnCard
--IsActive
--EntryDate
--UpdateDate
--EntryBy
--LastUpdateBy

create table CardsMapping(
Id int identity(1,1) not null primary key clustered,
CustomerId int null foreign key references Customers(Id),
CardPan varchar(56) not null ,
MaskPan int null foreign key references AccountType(Id),
ClientID int  null ,
CardTypeId int null foreign key references CardType(Id),
VendorId int null foreign key references Vendors(Id),
NameOnCard varchar(56)  null ,
IsActive bit not null default(1),
EntryDate datetime not null default(getdate()),
UpdateDate datetime  null ,
EntryBy varchar(200)  null ,
UpdateBy varchar(200)  null ,
 )