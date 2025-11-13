using MediatR;
using ThePatho.Features.Organization.Grade.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Grade.Commands;

public class UploadGradeTemplateCommand : IRequest<ApiResponse<GradeUploadResultDto>>
{
    public byte[] FileBytes { get; set; } = [];
    public string FileName { get; set; } = string.Empty;
}