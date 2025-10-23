using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.Service;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands
{
    public class GetSingleEmployeeCapColorCommandHandler : IRequestHandler<GetSingleEmployeeCapColorCommand, ApiResponse<EmployeeCapColorDto>>
    {
        private readonly IEmployeeCapColorService Service;

        public GetSingleEmployeeCapColorCommandHandler(IEmployeeCapColorService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeCapColorDto>> Handle(GetSingleEmployeeCapColorCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeCapColor(request);
        }
    }
}
