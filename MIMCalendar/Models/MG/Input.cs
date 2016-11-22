using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.MG
{
    [Table("MG_Inputs")]
    public class Input
    {
        [Key]
        public int Id { get; set; }

        public int PeriodId { get; set; }

        public int InputDefinitionId { get; set; }

        public int TeamId { get; set; }

        public decimal Value { get; set; }

        public virtual Period Period { get; set; }

        public virtual InputDefinition InputDefinition { get; set; }

        public virtual Team Team { get; set; }
    }
}