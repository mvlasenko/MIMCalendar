using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.Calendar
{
    [Table("Calendar_Lesson")]
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int RoomId { get; set; }

        public string TeacherId { get; set; }

        public int GameId { get; set; }

        //todo
    }
}