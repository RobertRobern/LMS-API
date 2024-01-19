using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class Genders
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
