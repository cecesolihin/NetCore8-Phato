using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePickUp.Service;
using ThePatho.Features.PersonalInformation.EmployeePickUp.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Commands
{
    public class GetSingleEmployeePickUpCommandHandler : IRequestHandler<GetSingleEmployeePickUpCommand, ApiResponse<EmployeePickUpDto>>
    {
        private readonly IEmployeePickUpService Service;

        public GetSingleEmployeePickUpCommandHandler(IEmployeePickUpService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeePickUpDto>> Handle(GetSingleEmployeePickUpCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeePickUp(request);
        }
    }
}
