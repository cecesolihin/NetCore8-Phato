using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePickUp.Service;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Commands
{
    public class SubmitEmployeePickUpCommandHandler : IRequestHandler<SubmitEmployeePickUpCommand, ApiResponse>
    {
        private readonly IEmployeePickUpService Service;

        public SubmitEmployeePickUpCommandHandler(IEmployeePickUpService _employeepickupService)
        {
            Service = _employeepickupService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeePickUpCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeePickUp(request);
        }
    }
}

