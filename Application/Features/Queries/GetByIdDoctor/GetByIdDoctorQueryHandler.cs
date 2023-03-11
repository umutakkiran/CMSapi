using Application.Abstraction.AbsDoctor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetByIdDoctor
{
    public class GetByIdDoctorQueryHandler : IRequestHandler<GetByIdDoctorQueryRequest, GetByIdDoctorQueryResponse>
    {
        readonly IDoctorReadRepository _readrepository;

        public GetByIdDoctorQueryHandler(IDoctorReadRepository readrepository)
        {
            _readrepository = readrepository;
        }

        public async Task<GetByIdDoctorQueryResponse> Handle(GetByIdDoctorQueryRequest request, CancellationToken cancellationToken)
        {
            var Doctor = await _readrepository.GetByIdAsync(request.Id, false);

            return new()
            {
                doctor = Doctor,
            };
        }

      
     }
}
