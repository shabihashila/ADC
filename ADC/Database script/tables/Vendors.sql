create table Vendors(
Id int identity(1,1) not null primary key clustered,
Name varchar(56) not null ,
EntryDate datetime not null default(getdate()),
UpdateDate datetime  null ,
EntryBy varchar(20)  null ,
UpdateBy varchar(20)  null ,
 )