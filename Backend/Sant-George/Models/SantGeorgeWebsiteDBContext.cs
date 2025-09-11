using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SantGeorgeWebsite.Models
{
    public class SantGeorgeWebsiteDBContext : IdentityDbContext<ApplicationUser>
    {
        public SantGeorgeWebsiteDBContext(DbContextOptions<SantGeorgeWebsiteDBContext> options) : base(options) { }
            
        public DbSet<Answer>Answers{ get; set; }
        public DbSet<Exam >Exams { get; set; }
        public DbSet<Question >Questions { get; set; }
        public DbSet<StudentAnswerChoose >StudentAnswerChoose { get; set; }
        public DbSet<StudentAnswerText >StudentAnswerText { get; set; }
        public DbSet<StudentAssignedExam >StudentAssignedExam { get; set; }
        public DbSet<TeacherMarkExam >TeacherMarkExam { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StudentAssignedExam>()
                .HasOne(se => se.Exam)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StudentAssignedExam>()
                .HasOne(se => se.Student)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<TeacherMarkExam>()
                .HasOne(se => se.Teacher)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TeacherMarkExam>()
                .HasOne(se => se.Exam)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<StudentAnswerText>()
                .HasOne(se => se.Student)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StudentAnswerText>()
                .HasOne(se => se.Question)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<StudentAnswerChoose>()
                .HasOne(se => se.Student)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StudentAnswerChoose>()
                .HasOne(se => se.Answer)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            #region Data Seeder
            //builder.Entity<ApplicationUser>().HasData(
            //new ApplicationUser { Id = "11111111-1111-1111-1111-111111111111",  Address ="102 El-Qubai St. El-Zaher", Email="markmagdyamin@gmail.com", Gender=Gender.Male, Class=2000, EmailConfirmed=true, PasswordHash="123A", PhoneNumber="01284417081", ConcurrencyStamp="123", UserName="MarkMagdy"});
            var userId = "11111111-1111-1111-1111-111111111111";
            var hasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser
            {
                Id = userId,
                UserName = "MarkMagdy",
                NormalizedUserName = "MARKMAGDY",
                Email = "markmagdy@gmail.com",
                NormalizedEmail = "MARKMAGDY@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = "c0f5028c-0e82-419c-9593-68e9255e2b9d",
                ConcurrencyStamp = "123",
                Address = "Cairo",
                Location="",
                Gender = Gender.Male, // Use your enum value
                Class = 2000,
                PasswordHash = "AQAAAAIAAYagAAAAEPcrEYTAjgSZAVIsmv+n5O2GXtUfnEF1OdR2LFZBKP3nVhlwnvj/MkZt/cbLTZlDPA==" // original password = 123
            };

            builder.Entity<ApplicationUser>().HasData(user);

            #endregion
        }

    }
}
