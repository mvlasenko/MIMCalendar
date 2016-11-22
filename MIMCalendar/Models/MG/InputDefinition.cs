using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.MG
{
    [Table("MG_InputDefinitions")]
    public class InputDefinition
    {
        public InputDefinition()
        {
            this.Inputs = new List<Input>();
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

        public int InputTypeId { get; set; }

        public int InputSubTypeId { get; set; }

        public int? ProductId { get; set; }

        public int? MarketId { get; set; }

        public int? UnitId { get; set; }

        public bool Required { get; set; }

        public bool Autofill { get; set; }

        public string Group { get; set; }

        public bool NonMatch { get; set; }

        public bool Percent100 { get; set; }

        public int? Order { get; set; }

        public virtual InputType InputType { get; set; }

        public virtual InputSubType InputSubType { get; set; }

        public virtual Product Product { get; set; }

        public virtual Market Market { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual ICollection<Input> Inputs { get; set; }
    }
}