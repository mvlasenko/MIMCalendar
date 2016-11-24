using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.Calendar
{
    [Table("Calendar_Lesson")]
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string TeacherId { get; set; }

        public int RoomId { get; set; }

        public int GroupId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Course Course { get; set; }

        public ApplicationUser Teacher { get; set; }

        public Room Room { get; set; }

        public Group Group { get; set; }
    }
}