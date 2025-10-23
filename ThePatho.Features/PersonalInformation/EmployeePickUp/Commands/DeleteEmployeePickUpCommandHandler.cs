using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePickUp.Service;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Commands
{
    public class DeleteEmployeePickUpCommandHandler : IRequestHandler<DeleteEmployeePickUpCommand, ApiResponse>
    {
        private readonly IEmployeePickUpService Service;

        public DeleteEmployeePickUpCommandHandler(IEmployeePickUpService _employeepickupService)
        {
            Service = _employeepickupService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeePickUpCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeePickUp(request);
        }
    }
}

