using System;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace CCFS
{
    public class MailSender
    {

        public async Task<bool> SendsmtpMail(string texter, string header)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Cinnamon Guest Feedback App", "administrator@cinnamonhotels.com"));
            message.To.Add(new MailboxAddress("Thimira", "thimira@cinnamonhotels.com"));
            message.Subject = "CGFS APP";

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = "<html>" +
                        "<h1>Cinnamon Guest Feedback App</h1>" +
                        "<h2>"+header+"</h2>" +
                        "<p>" + texter + "</p>" +
                        "</html>"
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync("smtp.office365.com", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync("cin_amd@jkintranet.com", "hp##2009");

                await client.SendAsync(message);

                Console.WriteLine("E mail Sent");

                return true;


                /*
                MailMessage objeto_mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.office365.com";
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("cin_amd@jkintranet.com", "hp##2009");
                objeto_mail.From = new MailAddress("administrator@cinnamonhotels.com", "CGFS");
                objeto_mail.To.Add(new MailAddress("thimira@cinnamonhotels.com"));
                objeto_mail.Subject = "CGFS APP";
                objeto_mail.Body = "Message";
                client.Send(objeto_mail);

                */

            }
        }
    }

}
