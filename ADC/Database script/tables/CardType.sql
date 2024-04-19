create table CardType(
Id int identity(1,1) not null primary key clustered,
Name varchar(256) not null ,
EntryDate datetime not null default(getdate()),
UpdateDate datetime  null ,
EntryBy varchar(200)  null ,
UpdateBy varchar(200)  null ,
 )