using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.Calendar
{
    [Table("Calendar_Courses")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Teachers { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}