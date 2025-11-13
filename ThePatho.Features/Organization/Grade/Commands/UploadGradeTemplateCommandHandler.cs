using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ThePatho.Features.Organization.Grade.DTO;
using ThePatho.Features.Organization.Grade.Service;
using ThePatho.Provider.ApiResponse;


namespace ThePatho.Features.Organization.Grade.Commands;

public class UploadGradeTemplateCommandHandler : IRequestHandler<UploadGradeTemplateCommand, ApiResponse<GradeUploadResultDto>>
{
    private readonly IGradeService _gradeService;

    public UploadGradeTemplateCommandHandler(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    public async Task<ApiResponse<GradeUploadResultDto>> Handle(UploadGradeTemplateCommand request, CancellationToken cancellationToken)
    {
        return await _gradeService.UploadGradeTemplate(request);
    }
}