using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.Gallery
{
    [Table("Gallery_Slides")]
    public class Slide
    {
        [Key]
        public int Id { get; set; }

        public string Title_eng { get; set; }

        public string Title_ukr { get; set; }

        public string Title_rus { get; set; }

        public string ImagePath { get; set; }

        public int SlideshowId { get; set; }

        public virtual Slideshow Slideshow { get; set; }
    }
}