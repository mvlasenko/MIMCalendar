using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIMCalendar.Models.Gallery
{
    [Table("Gallery_Slideshows")]
    public class Slideshow
    {
        public Slideshow()
        {
            this.Slides = new List<Slide>();
        }

        [Key]
        public int Id { get; set; }

        public string Title_eng { get; set; }

        public string Title_ukr { get; set; }

        public string Title_rus { get; set; }

        public virtual ICollection<Slide> Slides { get; set; }
    }
}