using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; } = 0;
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        public string ExamsId { get; set; }
        public Exams Exams { get; set; }
        public ICollection<Subjects> Results { get; set; }
    }
}
