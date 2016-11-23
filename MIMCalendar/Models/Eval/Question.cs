using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.Eval
{
    [Table("Eval_Questions")]
    public class Question
    {
        public Question()
        {
            this.Peers = new List<Peer>();
            this.Options = new List<Option>();
            this.Answers = new List<Answer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name_eng { get; set; }

        [StringLength(50)]
        public string Name_ukr { get; set; }

        [StringLength(50)]
        public string Name_rus { get; set; }

        public QuestionType QuestionType { get; set; }

        public int? Seq { get; set; }

        public virtual ICollection<Peer> Peers { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}