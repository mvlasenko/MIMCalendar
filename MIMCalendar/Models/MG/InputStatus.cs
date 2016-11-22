using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.MG
{
    [Table("MG_InputStatus")]
    public class InputStatus
    {
        [Key]
        public int Id { get; set; }

        public byte Period { get; set; }

        public int InputTypeId { get; set; }

        public string UserId { get; set; }

        public int TeamId { get; set; }

        public DateTime? Saved { get; set; }

        public virtual InputType InputType { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Team Team { get; set; }
    }
}