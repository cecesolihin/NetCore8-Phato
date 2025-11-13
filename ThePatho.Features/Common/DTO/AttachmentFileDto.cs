using System;

namespace ThePatho.Features.Common.DTO
{
    public class AttachmentFileDto
    {
        public byte[] FileBytes { get; set; } = Array.Empty<byte>();
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}