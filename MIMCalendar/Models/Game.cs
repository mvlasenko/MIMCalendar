using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MIMCalendar.Models.Eval;
using MIMCalendar.Models.MG;

namespace MIMCalendar.Models
{
    public class Game
    {
        public Game()
        {
            this.Teams = new List<Team>();
            this.EmailMessages = new List<EmailMessage>();
            this.Periods = new List<Period>();
            this.Peers = new List<Peer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public byte WorldsNumber { get; set; }

        public byte TeamsPerWorldNumber { get; set; }

        public byte PeriodNow { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<EmailMessage> EmailMessages { get; set; }

        public virtual ICollection<Period> Periods { get; set; }

        public virtual ICollection<Peer> Peers { get; set; }
    }
}