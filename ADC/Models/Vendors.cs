using ADC.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADC.Models
{

    [Table(nameof(Vendors))]
    public class Vendors:ModelBase
    {
        public string Name { get; set; }
       
    }
}
