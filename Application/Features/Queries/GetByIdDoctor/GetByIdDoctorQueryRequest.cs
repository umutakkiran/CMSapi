using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetByIdDoctor
{
    public class GetByIdDoctorQueryRequest : IRequest<GetByIdDoctorQueryResponse>
    {
        public string Id { get; set; }
    }
}
