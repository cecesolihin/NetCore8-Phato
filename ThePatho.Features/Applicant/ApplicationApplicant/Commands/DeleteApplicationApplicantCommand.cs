using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class DeleteApplicationApplicantCommand : IRequest<bool>
    {
        [JsonPropertyName("rec_application_id")]
        public int RecApplicationId { get; set; }
    }
}
