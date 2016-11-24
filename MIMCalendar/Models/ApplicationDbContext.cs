using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MIMCalendar.Models.Calendar;
using MIMCalendar.Models.Eval;
using MIMCalendar.Models.Gallery;
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

        public virtual DbSet<Group> Groups { get; set; }

        //email management
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        //management game

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Period> Periods { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Market> Markets { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<InputType> InputTypes { get; set; }

        public virtual DbSet<InputSubType> InputSubTypes { get; set; }

        public virtual DbSet<InputDefinition> InputDefinitions { get; set; }

        public virtual DbSet<InputStatus> InputStatus { get; set; }

        public virtual DbSet<Input> Inputs { get; set; }

        //peer evaluation

        public virtual DbSet<Peer> Peers { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Option> Options { get; set; }

        public virtual DbSet<Evaluation> Evaluations { get; set; }

        public virtual DbSet<Answer> Answers { get; set; }

        //articles

        public virtual DbSet<Article> Articles { get; set; }

        //gallery

        public virtual DbSet<Slide> Slides { get; set; }

        public virtual DbSet<Slideshow> Slideshows { get; set; }

        //calendar

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>()
                .HasRequired(e => e.Game)
                .WithMany(e => e.Teams)
                .HasForeignKey(e => e.GameId)
                .WillCascadeOnDelete(false);

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
                .HasOptional(e => e.Group)
                .WithMany(e => e.EmailMessages)
                .HasForeignKey(e => e.GroupId);

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

            modelBuilder.Entity<Game>()
                .HasRequired(e => e.Group)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.GroupId);

            modelBuilder.Entity<Period>()
                .HasRequired(e => e.Game)
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

            //peer evaluation

            modelBuilder.Entity<Peer>()
                .HasRequired(e => e.Group)
                .WithMany(e => e.Peers)
                .HasForeignKey(e => e.GroupId);

            modelBuilder.Entity<Peer>()
                .HasMany(e => e.Questions)
                .WithMany(e => e.Peers)
                .Map(m =>
                {
                    m.MapLeftKey("PeerId");
                    m.MapRightKey("QuestionId");
                    m.ToTable("Eval_PeerQuestions");
                });

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Options)
                .WithMany(e => e.Questions)
                .Map(m =>
                {
                    m.MapLeftKey("QuestionId");
                    m.MapRightKey("OptionId");
                    m.ToTable("Eval_QuestionOptions");
                });

            modelBuilder.Entity<Evaluation>()
                .HasRequired(e => e.Evaluator)
                .WithMany(e => e.EvaluationsMadeByThisUser)
                .HasForeignKey(e => e.EvaluatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evaluation>()
                .HasRequired(e => e.Evaluatee)
                .WithMany(e => e.EvaluationsMadeForThisUser)
                .HasForeignKey(e => e.EvaluateeId);

            modelBuilder.Entity<Evaluation>()
                .HasRequired(e => e.Peer)
                .WithMany(e => e.Evaluations)
                .HasForeignKey(e => e.PeerId);

            modelBuilder.Entity<Answer>()
                .HasRequired(e => e.Evaluation)
                .WithMany(e => e.Answers)
                .HasForeignKey(e => e.EvaluationId);

            modelBuilder.Entity<Answer>()
                .HasRequired(e => e.Question)
                .WithMany(e => e.Answers)
                .HasForeignKey(e => e.QuestionId);

            modelBuilder.Entity<Answer>()
                .HasRequired(e => e.Option)
                .WithMany(e => e.Answers)
                .HasForeignKey(e => e.OptionId);

            //gallery

            modelBuilder.Entity<Slide>()
                .HasRequired(e => e.Slideshow)
                .WithMany(e => e.Slides)
                .HasForeignKey(e => e.SlideshowId);

            //calendar

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Teachers)
                .WithMany(e => e.Courses)
                .Map(m =>
                {
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TeacherId");
                    m.ToTable("Calendar_CourseTeachers");
                });

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Groups)
                .WithMany(e => e.Courses)
                .Map(m =>
                {
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("GroupId");
                    m.ToTable("Calendar_CourseGroups");
                });

            modelBuilder.Entity<Lesson>()
                .HasRequired(e => e.Course)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Lesson>()
                .HasRequired(e => e.Teacher)
                .WithMany(e => e.TaughtLessons)
                .HasForeignKey(e => e.TeacherId);

            modelBuilder.Entity<Lesson>()
                .HasRequired(e => e.Room)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.RoomId);

            modelBuilder.Entity<Lesson>()
                .HasRequired(e => e.Group)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.GroupId);
        }
    }
}