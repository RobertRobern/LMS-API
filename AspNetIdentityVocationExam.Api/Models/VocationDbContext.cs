using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class VocationDbContext:IdentityDbContext<ApplicationUser>
    {
        public VocationDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Exams> Exams { get; set; }
        public DbSet<Genders> Genders { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<QuestionTypes> QuestionTypes { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        //public DbSet<UserAudioFiles> UserAudioFiles { get; set; }
        //public DbSet<AudioFiles> AudioFiles { get; set; }
    }
}
