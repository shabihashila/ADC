 
create table AccountMapping(
Id int identity(1,1) not null primary key clustered,
CustomerId int null foreign key references Customers(Id),
AccountNumber varchar(56) not null ,
AccountTypeId int null foreign key references AccountType(Id),
AccountTitle varchar(56)  null ,
Email varchar(20)  null ,
IsActive bit not null default(1),
IsFundTransferEnabled bit not null default(1),
IsCheckbookEnable bit not null default(1),
EntryDate datetime not null default(getdate()),
UpdateDate datetime  null ,
EntryBy varchar(20)  null ,
UpdateBy varchar(20)  null ,
 )

 /*

AccountType [DEPOSIT/CURRENT/LOAN/FD/RD]
ProductCode
AccountTitle
IsFundTransferEnabled
IsCheckbookEnable
IsActive
EntryDate
UpdateDate
EntryBy
LastUpdateBy
 */