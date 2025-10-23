using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeDocument.Service;
using ThePatho.Features.PersonalInformation.EmployeeDocument.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class GetSingleEmployeeDocumentCommandHandler : IRequestHandler<GetSingleEmployeeDocumentCommand, ApiResponse<EmployeeDocumentDto>>
    {
        private readonly IEmployeeDocumentService Service;

        public GetSingleEmployeeDocumentCommandHandler(IEmployeeDocumentService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeDocumentDto>> Handle(GetSingleEmployeeDocumentCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeDocument(request);
        }
    }
}
