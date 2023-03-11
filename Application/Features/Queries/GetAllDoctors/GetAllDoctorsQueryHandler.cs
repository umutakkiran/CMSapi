using Application.Abstraction.AbsDoctor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQueryRequest, GetAllDoctorsQueryResponse>
    {
        readonly IDoctorReadRepository _repository;

        public GetAllDoctorsQueryHandler(IDoctorReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllDoctorsQueryResponse> Handle(GetAllDoctorsQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _repository.GetAll(false).Count();
            var response = _repository.GetAll(false).Select(p => new
            {
                p.Id,
                p.Name,
                p.Surname,
                p.createdTime,
                p.updatedTime,

            }).ToList();

            return new()
            {
                doctors = response,
                totalCount = totalCount,
            };
        }
    }
}
