using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class Exams
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Time { get; set; } = 0; // time in minutes
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string? QuestionPattern { get; set; }
        public int Status { get; set; } = 0;
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Classes> Classes { get; set; }
    }
}
