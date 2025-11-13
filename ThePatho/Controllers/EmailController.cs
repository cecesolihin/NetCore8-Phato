using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.Email;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailController> _logger;

        public EmailController(IEmailService emailService, ILogger<EmailController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailRequest request)
        {
            try
            {
                var result = await _emailService.SendEmailAsync(request.To, request.Subject, request.Body, request.IsHtml);
                
                if (result)
                {
                    var response = new ApiResponse<string>(HttpStatusCode.OK, "Email sent successfully", "Email berhasil dikirim");
                    return new ApiResult<ApiResponse<string>>(response);
                }
                else
                {
                    var response = new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed to send email", "Gagal mengirim email");
                    return new ApiResult<ApiResponse<string>>(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                var response = new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal server error", "Terjadi kesalahan server");
                return new ApiResult<ApiResponse<string>>(response);
            }
        }

        [HttpPost("send-with-attachment")]
        public async Task<IActionResult> SendEmailWithAttachment([FromForm] SendEmailWithAttachmentRequest request)
        {
            try
            {
                if (request.Attachment == null || request.Attachment.Length == 0)
                {
                    var response = new ApiResponse<string>(HttpStatusCode.BadRequest, "Attachment is required", "File attachment diperlukan");
                    return new ApiResult<ApiResponse<string>>(response);
                }

                using var memoryStream = new MemoryStream();
                await request.Attachment.CopyToAsync(memoryStream);
                var attachmentData = memoryStream.ToArray();

                var result = await _emailService.SendEmailWithAttachmentAsync(
                    request.To, 
                    request.Subject, 
                    request.Body, 
                    attachmentData, 
                    request.Attachment.FileName, 
                    request.IsHtml
                );
                
                if (result)
                {
                    var response = new ApiResponse<string>(HttpStatusCode.OK, "Email with attachment sent successfully", "Email dengan attachment berhasil dikirim");
                    return new ApiResult<ApiResponse<string>>(response);
                }
                else
                {
                    var response = new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed to send email with attachment", "Gagal mengirim email dengan attachment");
                    return new ApiResult<ApiResponse<string>>(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email with attachment");
                var response = new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal server error", "Terjadi kesalahan server");
                return new ApiResult<ApiResponse<string>>(response);
            }
        }

        [HttpPost("send-bulk")]
        public async Task<IActionResult> SendBulkEmail([FromBody] SendBulkEmailRequest request)
        {
            try
            {
                var result = await _emailService.SendBulkEmailAsync(request.Recipients, request.Subject, request.Body, request.IsHtml);
                
                if (result)
                {
                    var response = new ApiResponse<string>(HttpStatusCode.OK, $"Bulk email sent successfully to {request.Recipients.Count} recipients", $"Email massal berhasil dikirim ke {request.Recipients.Count} penerima");
                    return new ApiResult<ApiResponse<string>>(response);
                }
                else
                {
                    var response = new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed to send bulk email", "Gagal mengirim email massal");
                    return new ApiResult<ApiResponse<string>>(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending bulk email");
                var response = new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal server error", "Terjadi kesalahan server");
                return new ApiResult<ApiResponse<string>>(response);
            }
        }
    }

    public class SendEmailRequest
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public bool IsHtml { get; set; } = true;
    }

    public class SendEmailWithAttachmentRequest
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public IFormFile Attachment { get; set; } = null!;
        public bool IsHtml { get; set; } = true;
    }

    public class SendBulkEmailRequest
    {
        public List<string> Recipients { get; set; } = new();
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public bool IsHtml { get; set; } = true;
    }
}