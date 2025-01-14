﻿using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class SubmitApplicantDocumentCommand : IRequest<string>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("document_type_code")]
        public string DocumentTypeCode { get; set; }

        [JsonPropertyName("file_path")]
        public string FilePath { get; set; }

        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
