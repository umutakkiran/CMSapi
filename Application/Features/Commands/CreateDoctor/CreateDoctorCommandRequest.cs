using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CreateDoctor
{
    public class CreateDoctorCommandRequest : IRequest<CreateDoctorCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
