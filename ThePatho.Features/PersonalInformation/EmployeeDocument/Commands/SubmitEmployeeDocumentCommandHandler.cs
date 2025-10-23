using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeDocument.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class SubmitEmployeeDocumentCommandHandler : IRequestHandler<SubmitEmployeeDocumentCommand, ApiResponse>
    {
        private readonly IEmployeeDocumentService Service;

        public SubmitEmployeeDocumentCommandHandler(IEmployeeDocumentService _employeedocumentService)
        {
            Service = _employeedocumentService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeDocumentCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeDocument(request);
        }
    }
}

