using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetJobCategoryDdlCommand : IRequest<JobCategoryItemDto>
    {
        [JsonPropertyName("filter_JobCategoryCode")]
        public string? FilterJobCategoryCode { get; set; }

    }
}
