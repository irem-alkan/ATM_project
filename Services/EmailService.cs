using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ATM_project.Services
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _port;
        private readonly string _from;
        private readonly string _secretKey;

        public EmailService(string smtpServer, int port, string from, string secretKey)
        {
            _smtpServer = smtpServer;
            _port = port;
            _from = from;
            _secretKey = secretKey;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            
            if (string.IsNullOrEmpty(toEmail))
            {
                throw new ArgumentException("Recipient email cannot be null or empty", nameof(toEmail));
            }

            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentException("Subject cannot be null or empty", nameof(subject));
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message cannot be null or empty", nameof(message));
            }

            try
            {
                using (var smtpClient = new SmtpClient(_smtpServer, _port))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential(_from, _secretKey);
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_from),
                        Subject = subject,
                        Body = message,
                        IsBodyHtml = false
                    };

                    mailMessage.To.Add(toEmail);
                  
                    await smtpClient.SendMailAsync(mailMessage);
                   
                    Console.WriteLine($"Email successfully sent to {toEmail}.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to send email to {toEmail}. Error: {ex.Message}");
                throw new InvalidOperationException("Email sending failed", ex);
            }
        }
    }
}
