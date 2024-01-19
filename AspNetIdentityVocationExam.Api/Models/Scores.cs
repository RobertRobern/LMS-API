using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class Scores
    {
        public int Id { get; set; }
        public int? Total { get; set; }
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
