using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.MG
{
    [Table("MG_InputSubTypes")]
    public class InputSubType
    {
        public InputSubType()
        {
            this.InputDefinitions = new List<InputDefinition>();
            this.InputStatus = new List<InputStatus>();
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

        public virtual ICollection<InputDefinition> InputDefinitions { get; set; }

        public virtual ICollection<InputStatus> InputStatus { get; set; }
    }
}