using Application.Abstraction.AbsAppointment;
using Application.Features.Queries.GetAllAppointments;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentReadRepository _readRepository;
        private readonly IAppointmentWriteRepository _writeRepository;
        readonly IMediator _mediator;
        public AppointmentController(IAppointmentReadRepository readRepository, IAppointmentWriteRepository writeRepository, IMediator mediator)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get ([FromQuery]GetAllAppointmentsRequest getAllAppointmentsRequest)
        {

            var response = _readRepository.GetAll(false);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Domain.Entities.Appointment appointment)
        {
           await _writeRepository.AddAsync( new Domain.Entities.Appointment()
           {
               AppointmentType = appointment.AppointmentType,
               Date = appointment.Date,
               start = appointment.start,
               end = appointment.end,
               title = appointment.title,
               draggable = appointment.draggable,
           } );

           await _writeRepository.SaveAsync();
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> Put(Domain.Entities.Appointment model)
        {
            Domain.Entities.Appointment p = await _readRepository.GetByIdAsync(model.Id.ToString());

            p.AppointmentType = model.AppointmentType;

            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _writeRepository.RemoveAsync(id.ToString());
            await _writeRepository.SaveAsync();
            return Ok();
        }
    }
}
