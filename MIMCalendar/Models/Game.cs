using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MIMCalendar.Models
{
    public class Game
    {
        public Game()
        {
            this.Teams = new List<Team>();
            this.EmailMessages = new List<EmailMessage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<EmailMessage> EmailMessages { get; set; }
    }
}
