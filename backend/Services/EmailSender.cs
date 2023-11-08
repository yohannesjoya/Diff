using System.Net;
using System.Net.Mail;

namespace Backend.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {

            var appEmail = "gebrutsehay10@gmail.com";
            var pw = "zwjmxsegnqeyoaqe";
            
            var client = new SmtpClient(
                "smtp.gmail.com", 587
                )
            { 
                EnableSsl = true,
                Credentials = new NetworkCredential(appEmail,pw)
            
            };


            MailMessage mail = new MailMessage(from: appEmail, to: email, subject, message);
            mail.IsBodyHtml = true;


            return client.SendMailAsync(mail);


           
        }
    }
}
