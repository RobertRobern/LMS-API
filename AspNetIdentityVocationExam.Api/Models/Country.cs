using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<County> Counties { get; set; }

    }
}
