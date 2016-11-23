using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.Eval
{
    [Table("Eval_Answers")]
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public int EvaluationId { get; set; }

        public int QuestionId { get; set; }

        public int OptionId { get; set; }

        public int TextAnswer { get; set; }

        public virtual Evaluation Evaluation { get; set; }

        public virtual Question Question { get; set; }

        public virtual Option Option { get; set; }
    }
}