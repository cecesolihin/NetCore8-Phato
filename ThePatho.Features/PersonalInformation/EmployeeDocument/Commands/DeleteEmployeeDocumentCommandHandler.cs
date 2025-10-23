using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeDocument.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class DeleteEmployeeDocumentCommandHandler : IRequestHandler<DeleteEmployeeDocumentCommand, ApiResponse>
    {
        private readonly IEmployeeDocumentService Service;

        public DeleteEmployeeDocumentCommandHandler(IEmployeeDocumentService _employeedocumentService)
        {
            Service = _employeedocumentService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeDocumentCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeDocument(request);
        }
    }
}

