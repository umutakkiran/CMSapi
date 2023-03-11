using Application.Abstraction;
using Application.Abstraction.AbsPatient;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAllPatients
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQueryRequest, GetAllPatientsQueryResponse>
    {
        readonly IPatientReadRepository _readrepository;

        public GetAllPatientsQueryHandler(IPatientReadRepository readrepository)
        {
            _readrepository = readrepository;
        }

        public async Task<GetAllPatientsQueryResponse> Handle(GetAllPatientsQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCounts = _readrepository.GetAll(false).Count();
            var patients = _readrepository.GetAll(false).Select(p => new
            {
              p.Name,
              p.Surname,
              p.updatedTime,
              p.createdTime,

            }).ToList();

            return new()
            {
                patients = patients,
                totalCount = totalCounts
            };
        }
    }
}
