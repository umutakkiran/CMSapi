using Application.Abstraction.AbsDoctor;
using Application.Features.Commands.CreateDoctor;
using Application.Features.GetAllDoctors;
using Application.Features.Queries.GetByIdDoctor;
using CMS.Persistence.Concrete.ConDoctor;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorReadRepository _doctorReadRepository;
        private readonly IDoctorWriteRepository _doctorWriteRepository;

        readonly IMediator _mediator;

       

        public DoctorController(IDoctorReadRepository doctorReadRepository, IDoctorWriteRepository doctorWriteRepository, IMediator mediator)
        {
            this._doctorReadRepository = doctorReadRepository;
            this._doctorWriteRepository = doctorWriteRepository;
            this._mediator = mediator;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDoctorsQueryRequest getAllDoctorsQueryRequest)
        {
           GetAllDoctorsQueryResponse response = await _mediator.Send(getAllDoctorsQueryRequest);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromHeader]GetByIdDoctorQueryRequest getByIdDoctorQueryRequest)
        {
            GetByIdDoctorQueryResponse response = await _mediator.Send(getByIdDoctorQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDoctorCommandRequest createDoctorCommandRequest)
        {
           await _mediator.Send(createDoctorCommandRequest); 
            return Ok();    
        }

        [HttpPut]
        public async Task<IActionResult> Put(Doctor model)
        {
            Doctor p = await _doctorReadRepository.GetByIdAsync(model.Id.ToString());

            p.Name = model.Name;
            p.Surname = model.Surname;

            await _doctorWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _doctorWriteRepository.RemoveAsync(id.ToString());
            await _doctorWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
