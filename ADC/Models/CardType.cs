using ADC.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADC.Models
{
    [Table(nameof(CardType))]
    public class CardType:ModelBase
    {
   
        public string Name { get; set; }
       
    }
}


//Id int identity(1,1) not null primary key clustered,
//Name varchar(56) not null ,
//EntryDate datetime not null default(getdate()),
//UpdateDate datetime  null ,
//EntryBy varchar(20)  null ,
//UpdateBy varchar(20)  null ,