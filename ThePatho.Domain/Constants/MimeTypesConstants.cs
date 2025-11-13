using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Constants
{
    public static class MimeTypesConstants
    {

        // 📘 Dokumen
        public const string PDF = "application/pdf";
        public const string MSWORD = "application/msword";
        public const string VND_OPENXML_WORD = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        public const string VND_MS_EXCEL = "application/vnd.ms-excel";
        public const string VND_OPENXML_EXCEL = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public const string VND_MS_POWERPOINT = "application/vnd.ms-powerpoint";
        public const string VND_OPENXML_POWERPOINT = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        public const string RTF = "application/rtf";
        public const string TEXT_PLAIN = "text/plain";
        public const string TEXT_CSV = "text/csv";
        public const string APPLICATION_OCTET_STREAM = "application/octet-stream";
        public const string APPLICATION_JSON = "application/json";
        public const string APPLICATION_XML = "application/xml";

        // 🖼️ Gambar
        public const string IMAGE_JPEG = "image/jpeg";
        public const string IMAGE_PNG = "image/png";
        public const string IMAGE_GIF = "image/gif";
        public const string IMAGE_BMP = "image/bmp";
        public const string IMAGE_SVG_XML = "image/svg+xml";
        public const string IMAGE_WEBP = "image/webp";
        public const string IMAGE_X_ICON = "image/x-icon";

        // 🎵 Audio
        public const string AUDIO_MPEG = "audio/mpeg";
        public const string AUDIO_WAV = "audio/wav";
        public const string AUDIO_OGG = "audio/ogg";
        public const string AUDIO_AAC = "audio/aac";
        public const string AUDIO_MIDI = "audio/midi";

        // 🎬 Video
        public const string VIDEO_MP4 = "video/mp4";
        public const string VIDEO_X_MSVIDEO = "video/x-msvideo";
        public const string VIDEO_MPEG = "video/mpeg";
        public const string VIDEO_WEBM = "video/webm";
        public const string VIDEO_3GPP = "video/3gpp";
    }
}
