using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string? Name { get; set; }        
        public int Status { get; set; } = 0;
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        public string ClassesId { get; set; }
        public Classes Classes { get; set; }
        public ICollection<Questions> Questions { get; set; }
    }
}
