using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.MG
{
    [Table("MG_Games")]
    public class Game
    {
        public Game()
        {
            this.Teams = new List<Team>();
            this.Periods = new List<Period>();
        }

        [Key]
        public int Id { get; set; }

        public int GroupId { get; set; }

        public byte WorldsNumber { get; set; }

        public byte TeamsPerWorldNumber { get; set; }

        public byte PeriodNow { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Period> Periods { get; set; }
    }
}