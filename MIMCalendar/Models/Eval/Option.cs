using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.Eval
{
    [Table("Eval_Options")]
    public class Option
    {
        public Option()
        {
            this.Questions = new List<Question>();
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

        public int Value { get; set; }

        public int? Seq { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}