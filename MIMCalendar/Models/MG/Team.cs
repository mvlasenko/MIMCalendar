using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.MG
{
    [Table("MG_Teams")]
    public class Team
    {
        public Team()
        {
            this.Users = new List<ApplicationUser>();
            this.EmailMessages = new List<EmailMessage>();
            this.InputStatus = new List<InputStatus>();
            this.Inputs = new List<Input>();
        }

        [Key]
        public int Id { get; set; }

        public int GameId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int FirmId { get; set; }

        public int WorldId { get; set; }

        public virtual Game Game { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<EmailMessage> EmailMessages { get; set; }

        public virtual ICollection<InputStatus> InputStatus { get; set; }

        public virtual ICollection<Input> Inputs { get; set; }
    }
}