namespace ThePatho.Provider.Email
{
    /// <summary>
    /// Interface for email service functionality
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends a single email
        /// </summary>
        /// <param name="to">Recipient email address</param>
        /// <param name="subject">Email subject</param>
        /// <param name="body">Email body content</param>
        /// <param name="isHtml">Whether the body is HTML (default: true)</param>
        /// <returns>True if email was sent successfully, false otherwise</returns>
        Task<bool> SendEmailAsync(string to, string subject, string body, bool isHtml = true);

        /// <summary>
        /// Sends an email with attachment
        /// </summary>
        /// <param name="to">Recipient email address</param>
        /// <param name="subject">Email subject</param>
        /// <param name="body">Email body content</param>
        /// <param name="attachmentData">Attachment file data as byte array</param>
        /// <param name="attachmentName">Attachment file name</param>
        /// <param name="isHtml">Whether the body is HTML (default: true)</param>
        /// <returns>True if email was sent successfully, false otherwise</returns>
        Task<bool> SendEmailWithAttachmentAsync(string to, string subject, string body, byte[] attachmentData, string attachmentName, bool isHtml = true);

        /// <summary>
        /// Sends bulk emails to multiple recipients
        /// </summary>
        /// <param name="recipients">List of recipient email addresses</param>
        /// <param name="subject">Email subject</param>
        /// <param name="body">Email body content</param>
        /// <param name="isHtml">Whether the body is HTML (default: true)</param>
        /// <returns>True if all emails were sent successfully, false otherwise</returns>
        Task<bool> SendBulkEmailAsync(List<string> recipients, string subject, string body, bool isHtml = true);
    }
}