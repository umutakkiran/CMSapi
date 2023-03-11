using Application.Abstraction.AbsDoctor;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommandRequest, CreateDoctorCommandResponse>
    {
        readonly IDoctorWriteRepository _repository;

        public CreateDoctorCommandHandler(IDoctorWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateDoctorCommandResponse> Handle(CreateDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new Doctor()
            {
                Name = request.Name,
                Surname = request.Surname,
            });

            await _repository.SaveAsync();

            return new();
        }
    }
}
