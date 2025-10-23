using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeFamily.Service;
using ThePatho.Features.PersonalInformation.EmployeeFamily.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class GetSingleEmployeeFamilyCommandHandler : IRequestHandler<GetSingleEmployeeFamilyCommand, ApiResponse<EmployeeFamilyDto>>
    {
        private readonly IEmployeeFamilyService Service;

        public GetSingleEmployeeFamilyCommandHandler(IEmployeeFamilyService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeFamilyDto>> Handle(GetSingleEmployeeFamilyCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeFamily(request);
        }
    }
}
