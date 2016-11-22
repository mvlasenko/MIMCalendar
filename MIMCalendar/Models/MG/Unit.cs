using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.MG
{
    [Table("MG_Units")]
    public class Unit
    {
        public Unit()
        {
            this.InputDefinitions = new List<InputDefinition>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name_eng { get; set; }

        [StringLength(50)]
        public string Name_ukr { get; set; }

        [StringLength(50)]
        public string Name_rus { get; set; }

        [Required]
        public ControlType ControlType { get; set; }

        public decimal MinValue { get; set; }

        public decimal MaxValue { get; set; }

        public virtual ICollection<InputDefinition> InputDefinitions { get; set; }
    }
}