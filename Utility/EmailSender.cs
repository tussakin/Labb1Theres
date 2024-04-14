using Microsoft.AspNetCore.Identity.UI.Services;

namespace Labb1Theres.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Emails kod 
            return Task.CompletedTask;
        }
    }
}
