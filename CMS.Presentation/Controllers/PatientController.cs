using Application.Abstraction.AbsDoctor;
using Application.Abstraction.AbsPatient;
using Application.Features.Queries.GetAllPatients;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        readonly private IPatientReadRepository _patientReadRepository;
        readonly private IPatientWriteRepository _patientWriteRepository;

        readonly IMediator _mediator;
        public PatientController(IPatientReadRepository patientReadRepository, IPatientWriteRepository patientWriteRepository, IMediator mediator)
        {
            _patientReadRepository = patientReadRepository;
            _patientWriteRepository = patientWriteRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllPatientsQueryRequest getAllPatientsQueryRequest)
        {
            var response = await _mediator.Send(getAllPatientsQueryRequest);
            return Ok(response);    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok( _patientReadRepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post (Patient model)
        {
            await _patientWriteRepository.AddAsync(new Patient()
            {
                Name = model.Name,
                Surname = model.Surname,
            });
            
            await _patientWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Patient model)
        {
            Patient p = await _patientReadRepository.GetByIdAsync(model.Id.ToString());

            p.Name = model.Name;
            p.Surname = model.Surname;

            await _patientWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
           await _patientWriteRepository.RemoveAsync(id.ToString());
           await _patientWriteRepository.SaveAsync();
           return Ok();
        }
    }
}
