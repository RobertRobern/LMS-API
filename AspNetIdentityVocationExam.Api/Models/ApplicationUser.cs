using Microsoft.AspNetCore.Identity;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class ApplicationUser:IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? IdNumber { get; set; }
        public int Status { get; set; } = 0;
        public ICollection<Exams> Exams { get; set; }
        public ICollection<Scores> Scores { get; set; }
        public ICollection<Country> Countries { get; set; }
        public string? GendersId { get; set; }
        public Genders Genders { get; set; }
    }
}
