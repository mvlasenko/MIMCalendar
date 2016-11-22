using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MIMCalendar.Models.MG;

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

        //email management
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        //management game
        public virtual DbSet<Period> Periods { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Market> Markets { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<InputType> InputTypes { get; set; }

        public virtual DbSet<InputSubType> InputSubTypes { get; set; }

        public virtual DbSet<InputDefinition> InputDefinitions { get; set; }

        public virtual DbSet<InputStatus> InputStatus { get; set; }

        public virtual DbSet<Input> Inputs { get; set; }

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

            //email management

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

            //management game

            modelBuilder.Entity<Period>()
                .HasOptional(e => e.Game)
                .WithMany(e => e.Periods)
                .HasForeignKey(e => e.GameId);

            modelBuilder.Entity<InputDefinition>()
                .HasRequired(e => e.InputType)
                .WithMany(e => e.InputDefinitions)
                .HasForeignKey(e => e.InputTypeId);

            modelBuilder.Entity<InputDefinition>()
                .HasRequired(e => e.InputSubType)
                .WithMany(e => e.InputDefinitions)
                .HasForeignKey(e => e.InputSubTypeId);

            modelBuilder.Entity<InputDefinition>()
                .HasOptional(e => e.Product)
                .WithMany(e => e.InputDefinitions)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<InputDefinition>()
                .HasOptional(e => e.Market)
                .WithMany(e => e.InputDefinitions)
                .HasForeignKey(e => e.MarketId);

            modelBuilder.Entity<InputDefinition>()
                .HasOptional(e => e.Unit)
                .WithMany(e => e.InputDefinitions)
                .HasForeignKey(e => e.UnitId);

            modelBuilder.Entity<InputStatus>()
                .HasRequired(e => e.InputType)
                .WithMany(e => e.InputStatus)
                .HasForeignKey(e => e.InputTypeId);

            modelBuilder.Entity<InputStatus>()
                .HasRequired(e => e.User)
                .WithMany(e => e.InputStatus)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<InputStatus>()
                .HasRequired(e => e.Team)
                .WithMany(e => e.InputStatus)
                .HasForeignKey(e => e.TeamId);

            modelBuilder.Entity<Input>()
                .HasRequired(e => e.Period)
                .WithMany(e => e.Inputs)
                .HasForeignKey(e => e.PeriodId);

            modelBuilder.Entity<Input>()
                .HasRequired(e => e.InputDefinition)
                .WithMany(e => e.Inputs)
                .HasForeignKey(e => e.InputDefinitionId);

            modelBuilder.Entity<Input>()
                .HasRequired(e => e.Team)
                .WithMany(e => e.Inputs)
                .HasForeignKey(e => e.TeamId);
        }
    }
}