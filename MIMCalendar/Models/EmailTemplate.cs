using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models
{
    public class EmailTemplate
    {
        public EmailTemplate()
        {
            this.EmailMessages = new List<EmailMessage>();
        }

        [Key]
        public int Id { get; set; }

        public EmailTemplateType Type { get; set; }

        [Required]
        [StringLength(200)]
        public string Subject { get; set; }

        [Column(TypeName = "ntext")]
        [MaxLength]
        public string Body { get; set; }

        public virtual ICollection<EmailMessage> EmailMessages { get; set; }
    }
}