using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace AspNetIdentityVocationExam.Api.Services
{
    public interface IMailService
    {

        Task SendEmailAsync(string toEmail, string result, string content);
    }

    public class SendGridMailService : IMailService
    {
        private IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string result, string content)
        {
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@authdemo.com", "JWT Auth Demo");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, result, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
