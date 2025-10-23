using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Service;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class GetSingleEmployeeCareerHistoryCommandHandler : IRequestHandler<GetSingleEmployeeCareerHistoryCommand, ApiResponse<EmployeeCareerHistoryDto>>
    {
        private readonly IEmployeeCareerHistoryService Service;

        public GetSingleEmployeeCareerHistoryCommandHandler(IEmployeeCareerHistoryService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeCareerHistoryDto>> Handle(GetSingleEmployeeCareerHistoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeCareerHistory(request);
        }
    }
}
