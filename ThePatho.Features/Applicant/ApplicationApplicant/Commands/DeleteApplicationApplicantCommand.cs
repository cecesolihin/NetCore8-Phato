using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class DeleteApplicationApplicantCommand : IRequest<bool>
    {
        public int RecApplicationId { get; set; }
    }
}
