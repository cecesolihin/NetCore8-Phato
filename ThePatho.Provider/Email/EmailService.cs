using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ThePatho.Provider.Email
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly EmailConfiguration _emailConfig;

        public EmailService(ILogger<EmailService> logger, IOptions<EmailConfiguration> emailConfig)
        {
            _logger = logger;
            _emailConfig = emailConfig.Value;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            try
            {
                using var client = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.SmtpPort)
                {
                    Credentials = new NetworkCredential(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword),
                    EnableSsl = _emailConfig.EnableSsl
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailConfig.FromEmail, _emailConfig.FromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };

                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);
                _logger.LogInformation("Email sent successfully to {Email}", to);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email}", to);
                return false;
            }
        }

        public async Task<bool> SendEmailWithAttachmentAsync(string to, string subject, string body, byte[] attachmentData, string attachmentName, bool isHtml = true)
        {
            try
            {
                using var client = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.SmtpPort)
                {
                    Credentials = new NetworkCredential(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword),
                    EnableSsl = _emailConfig.EnableSsl
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailConfig.FromEmail, _emailConfig.FromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };

                mailMessage.To.Add(to);

                // Add attachment
                using var stream = new MemoryStream(attachmentData);
                var attachment = new Attachment(stream, attachmentName);
                mailMessage.Attachments.Add(attachment);

                await client.SendMailAsync(mailMessage);
                _logger.LogInformation("Email with attachment sent successfully to {Email}", to);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email with attachment to {Email}", to);
                return false;
            }
        }

        public async Task<bool> SendBulkEmailAsync(List<string> recipients, string subject, string body, bool isHtml = true)
        {
            try
            {
                using var client = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.SmtpPort)
                {
                    Credentials = new NetworkCredential(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword),
                    EnableSsl = _emailConfig.EnableSsl
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailConfig.FromEmail, _emailConfig.FromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };

                foreach (var recipient in recipients)
                {
                    mailMessage.To.Add(recipient);
                }

                await client.SendMailAsync(mailMessage);
                _logger.LogInformation("Bulk email sent successfully to {Count} recipients", recipients.Count);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send bulk email to {Count} recipients", recipients.Count);
                return false;
            }
        }
    }
}