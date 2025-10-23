using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeDocument.Service;
using ThePatho.Features.PersonalInformation.EmployeeDocument.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class GetEmployeeDocumentCommandHandler : IRequestHandler<GetEmployeeDocumentCommand, ApiResponse<EmployeeDocumentItemDto>>
    {
        private readonly IEmployeeDocumentService Service;

        public GetEmployeeDocumentCommandHandler(IEmployeeDocumentService _employeedocumentService)
        {
            Service = _employeedocumentService;
        }

        public async Task<ApiResponse<EmployeeDocumentItemDto>> Handle(GetEmployeeDocumentCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeDocument(request);
        }
    }
}

