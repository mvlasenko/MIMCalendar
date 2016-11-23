using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Title_eng { get; set; }

        public string Title_ukr { get; set; }

        public string Title_rus { get; set; }

        public string Description_eng { get; set; }

        public string Description_ukr { get; set; }

        public string Description_rus { get; set; }

        public string Body_eng { get; set; }

        public string Body_ukr { get; set; }

        public string Body_rus { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }
    }
}