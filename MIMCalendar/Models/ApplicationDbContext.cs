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


        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>()
                .HasRequired(e => e.Game)
                .WithMany(e => e.Teams)
                .HasForeignKey(e => e.GameId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Teams)
                .WithMany(e => e.Users)
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("TeamId");
                    m.ToTable("UserTeams");
                });

            modelBuilder.Entity<EmailMessage>()
                .HasRequired(e => e.EmailTemplate)
                .WithMany(e => e.EmailMessages)
                .HasForeignKey(e => e.EmailTemplateId);

            modelBuilder.Entity<EmailMessage>()
                .HasOptional(e => e.Game)
                .WithMany(e => e.EmailMessages)
                .HasForeignKey(e => e.GameId);

            modelBuilder.Entity<EmailMessage>()
                .HasOptional(e => e.Team)
                .WithMany(e => e.EmailMessages)
                .HasForeignKey(e => e.TeamId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.EmailMessages)
                .WithMany(e => e.Users)
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("EmailMessageId");
                    m.ToTable("UserEmailMessages");
                });

        }
    }
}