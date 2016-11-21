using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MIMCalendar.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>()
                .HasRequired(e => e.Game)
                .WithMany(e => e.Teams)
                .HasForeignKey(e => e.GameId);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(e => e.Team)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.TeamId);
        }
    }
}