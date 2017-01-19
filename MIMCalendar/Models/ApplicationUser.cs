using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MIMCalendar.Models.Calendar;
using MIMCalendar.Models.Eval;
using MIMCalendar.Models.MG;

namespace MIMCalendar.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //todo: add more fields

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<EmailMessage> EmailMessages { get; set; }

        public virtual ICollection<InputStatus> InputStatus { get; set; }

        public virtual ICollection<Evaluation> EvaluationsMadeByThisUser { get; set; }

        public virtual ICollection<Evaluation> EvaluationsMadeForThisUser { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Lesson> TaughtLessons { get; set; }
    }
}