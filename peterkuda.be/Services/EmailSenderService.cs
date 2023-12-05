
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace CurriculumVitae.Services;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        SmtpClient client = new SmtpClient
        {
            Port = 587,
            //Host = "host.docker.internal",
            Host = "smtp.peterkuda.be",
            EnableSsl= false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("svoabhubyr", "CXkzn9vP4odMPeSeA1a"),                        
        };
        MailAddressCollection reciepents = new MailAddressCollection();

        MailMessage msg = new MailMessage("noreply@peterkuda.be",email)
        {            
            Subject = subject,
            Body = htmlMessage,
            Sender = new MailAddress(email),
            From = new MailAddress("info@peterkuda.be"),
            IsBodyHtml = true,            
        };                
        client.Send(msg);
        return Task.CompletedTask;                
    }
}
