using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MIMCalendar.Models.Calendar;
using MIMCalendar.Models.Eval;
using MIMCalendar.Models.MG;

namespace MIMCalendar.Models
{
    public class Group
    {
        public Group()
        {
            this.EmailMessages = new List<EmailMessage>();
            this.Games = new List<Game>();
            this.Peers = new List<Peer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<EmailMessage> EmailMessages { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<Peer> Peers { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}