using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class County
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }

    }
}
