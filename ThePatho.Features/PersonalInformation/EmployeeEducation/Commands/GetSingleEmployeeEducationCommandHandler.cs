using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeEducation.Service;
using ThePatho.Features.PersonalInformation.EmployeeEducation.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class GetSingleEmployeeEducationCommandHandler : IRequestHandler<GetSingleEmployeeEducationCommand, ApiResponse<EmployeeEducationDto>>
    {
        private readonly IEmployeeEducationService Service;

        public GetSingleEmployeeEducationCommandHandler(IEmployeeEducationService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeEducationDto>> Handle(GetSingleEmployeeEducationCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeEducation(request);
        }
    }
}
