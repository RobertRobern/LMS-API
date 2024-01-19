using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityVocationExam.Api.Models
{
    public class UserAudioFiles
    {
        public int Id { get; set; }
        [Timestamp]
        public DateTime CreatedAt { get; set; }
    }
}
