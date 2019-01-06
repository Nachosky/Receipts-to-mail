using System.Collections.Generic;
using SimplerSettings;
using System.Net.Mail;

namespace Receipts
{
    public class SendMail
    {
        public void SendEmail(List<string> attachments)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
            mail.From = new MailAddress(AppSettings.Get("senderEmail"));
            mail.To.Add(AppSettings.Get("receiverEmail"));
            mail.Subject = "Auth0 Rachunki";
            mail.Body = "";

            System.Net.Mail.Attachment attachment;
            foreach (var attachedFile in attachments)
            {
                attachment = new System.Net.Mail.Attachment(attachedFile);
                mail.Attachments.Add(attachment);
            }

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(AppSettings.Get("senderEmail"), AppSettings.Get("senderPassword"));
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}