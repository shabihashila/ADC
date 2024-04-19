 
create table Customers(
Id int identity(1,1) not null primary key clustered,
Name varchar(56) not null ,
Mobile varchar(14)  null ,
Email varchar(20)  null ,
IsActive bit not null default(1),
EntryDate datetime not null default(getdate()),
UpdateDate datetime  null ,
EntryBy varchar(20)  null ,
UpdateBy varchar(20)  null ,
 )