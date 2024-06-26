using MailKit.Net.Imap;
using MailKit;
using MailKit.Net.Pop3;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;

namespace WebHost.Areas.Administration.Pages.Email
{
    public class IndexModel : PageModel
    {
        public List<EmailDetails> List;
        public void OnGet()
        {
            List = EmailService.GetEmails();
        }
    }
}


public class InboxEmailDto
{
    public string Subject { get; set; }
    public string From { get; set; }
    public ToEmailDto To { get; set; }
    public string HtmlBody { get; set; }
    public DateTimeOffset Date { get; set; }
}

public class ToEmailDto
{
    public string Name { get; set; }
    public string Email { get; set; }
}
public class SenderEmailDto
{
    public string Name { get; set; }
    public string Email { get; set; }
}


public static class EmailService
{
    public static List<EmailDetails> GetEmails()
    {
        var username = "Info@afgou.org";
        var password = "#j5I8nw12";
        var host = "mail.afgou.org";
        var port = 993;

        var emails = new List<EmailDetails>();

        using (var emailClient = new ImapClient())
        {
            emailClient.Connect(host, port, SecureSocketOptions.Auto);

            emailClient.Authenticate(username, password);

            var inbox = emailClient.Inbox;
            inbox.Open(FolderAccess.ReadOnly);

            for (int i = 0; i < inbox.Count; i++)
            {
                var message = inbox.GetMessage(i);
                var sender = message.From.Mailboxes.FirstOrDefault();
                ;
                var emailDetails = new EmailDetails
                {
                    Name = sender?.Name??sender?.Address,
                    FromEmail = message.From.Mailboxes.FirstOrDefault()?.Address,
                    ToEmail = message.To.Mailboxes.FirstOrDefault()?.Address,
                    Subject = message.Subject,
                    Body = !string.IsNullOrEmpty(message.HtmlBody) ? message.HtmlBody : message.TextBody,
                    Date = message.Date.DateTime,
                    Attachments = message.Attachments.Select(a => a.ContentId).ToList(),
                };

                emails.Add(emailDetails);
            }
        }

        return emails;
    }
}

public class EmailDetails
{
    public string Name { get; set; }
    public string FromEmail { get; set; }
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; }
    public bool IsRead { get; set; }
    public List<string> Attachments { get; set; }
}
