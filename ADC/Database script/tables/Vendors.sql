
create table Vendors(
Id int identity(1,1) not null primary key clustered,
Name varchar(56) not null ,
EntryDate datetime not null default(getdate()),
UpdateDate datetime  null ,
EntryBy varchar(20)  null ,
UpdateBy varchar(20)  null ,
 )

 go 

 ALTER TABLE Vendors
ALTER COLUMN EntryBy VARCHAR(128);


go

ALTER TABLE Vendors
ALTER COLUMN UpdateBy VARCHAR(128);
