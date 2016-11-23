using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.Eval
{
    [Table("Eval_Evaluations")]
    public class Evaluation
    {
        [Key]
        public int Id { get; set; }

        public string EvaluatorId { get; set; }

        public string EvaluateeId { get; set; }

        public int PeerId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        public virtual ApplicationUser Evaluator { get; set; }

        public virtual ApplicationUser Evaluatee { get; set; }

        public virtual Peer Peer { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}