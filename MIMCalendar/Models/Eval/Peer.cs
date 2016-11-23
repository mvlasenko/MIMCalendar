using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.Eval
{
    [Table("Eval_Peers")]
    public class Peer
    {
        public Peer()
        {
            this.Questions = new List<Question>();
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

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}