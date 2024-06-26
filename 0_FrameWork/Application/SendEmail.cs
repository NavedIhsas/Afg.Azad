using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace _0_FrameWork.Application
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body)
        {
            var mail = new MailMessage();
            var smtpServer = new SmtpClient("mail.afgou.org");
            mail.From = new MailAddress("Info@afgou.org", "پوهنتون آزاد افغانستان");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("Info@afgou.org", "#j5I8nw12");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
    }

    //public class GetEmail
    //{
    //    public void Get()
    //    {
    //        using (var emailClient = new Pop3Client())
    //        {
    //            emailClient.Connect(settings.HostMail, 110);
    //            emailClient.Authenticate(settings.UsernameEmail, settings.PasswordEmail);

    //            List<EmailMessageDTO> emails = new List<EmailMessageDTO>();
    //            for (int i = 0; i < emailClient.Count; i++)
    //            {
    //                var message = emailClient.GetMessage(i);
    //                var emailMessage = new EmailMessageDTO();


    //                emailMessage.MessageHtml = !string.IsNullOrEmpty(message.HtmlBody) ? message.HtmlBody : message.TextBody;
    //                emailMessage.Subject = message.Subject;

    //                emailMessage.To = new List<DTO.Address>();
    //                emailMessage.To.AddRange(message.To.Select(x => (MailboxAddress)x).Select(x => new DTO.Address { Email = x.Address, Name = x.Name }));
    //                var sender = message.From.Select(x => (MailboxAddress)x).Select(x => new DTO.Address { Email = x.Address, Name = x.Name }).FirstOrDefault();
    //                emailMessage.From = new DTO.Address { Email = sender.Email, Name = sender.Name };
    //                if (emailMessage.From.Name == "Ali")
    //                {
    //                    emails.Add(emailMessage);
    //                }

    //            }
    //        }
    //    }
    //}
}