using Application.Abstraction;
using Application.Abstraction.AbsAppointment;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAllAppointments
{
    public class GetAllAppointmentsHandler : IRequestHandler<GetAllAppointmentsRequest, Appointment>
    {
        readonly IAppointmentReadRepository _readrepository;

        public GetAllAppointmentsHandler(IAppointmentReadRepository readrepository)
        {
            _readrepository = readrepository;
        }

        public async Task<Appointment> Handle(GetAllAppointmentsRequest request, CancellationToken cancellationToken)
        {
            var response =  _readrepository.GetAll(false);

            return  new();
            
        }
    }
}
