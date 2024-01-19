using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Option1 { get; set; }
        public string? Option2 { get; set; }
        public string? Option3 { get; set; }
        public string? Option4 { get; set; }
        public int? Answer { get; set; }
        public int? Score { get; set; }
        public int Status { get; set; } = 1;
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        public string SubjectsId { get; set; }
        public Subjects Results { get; set; }

    }
}
