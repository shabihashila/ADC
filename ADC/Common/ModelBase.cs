using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ADC.Common
{
    public class ModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }

        public string? EntryBy { get; set; }
        public string? UpdateBy { get; set; }
    }
}
