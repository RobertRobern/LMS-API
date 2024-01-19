using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class QuestionTypes
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Timestamp]
        public DateTime CreatedAt { get; set; }
    }
}
