using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MIMCalendar.Models.MG;

namespace MIMCalendar.Models
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            this.Users = new List<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        public int EmailTemplateId { get; set; }

        public int? GroupId { get; set; }

        public int? TeamId { get; set; }

        public DateTime? DateSent { get; set; }

        public virtual EmailTemplate EmailTemplate { get; set; }

        public virtual Group Group { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}