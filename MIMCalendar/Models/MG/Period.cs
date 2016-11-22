using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.MG
{
    [Table("MG_Periods")]
    public class Period
    {
        public Period()
        {
            this.Inputs = new List<Input>();
        }

        [Key]
        public int Id { get; set; }

        public int? GameId { get; set; }

        public byte PeriodNumber { get; set; }

        public DateTime? Deadline { get; set; }

        public virtual Game Game { get; set; }

        public virtual ICollection<Input> Inputs { get; set; }
    }
}