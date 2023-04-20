using Application.Abstraction.AbsContent;
using Application.Abstraction.AbsTeam;
using Application.ViewModel;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamReadRepository _readrepository;
        private readonly ITeamWriteRepository _writerepository;

        public TeamController(ITeamReadRepository readrepository, ITeamWriteRepository writerepository)
        {
            _readrepository = readrepository;
            _writerepository = writerepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_readrepository.GetAll(false).Select(p => new
            {
                p.Id,
                p.Name,
                p.Logo,
                p.Players,
                p.GameMemberships

            }
            ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]string id)
        {
            return Ok(await _readrepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTeamModel model)
        {
            await _writerepository.AddAsync(new Team()
            {
                Name = model.Name,
                Logo = model.Logo,
                
            });

            await _writerepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Team model)
        {
            Team p = await _readrepository.GetByIdAsync(model.Id.ToString());

            p.Name = model.Name;
            p.Logo = model.Logo;

            await _writerepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _writerepository.RemoveAsync(id.ToString());
            await _writerepository.SaveAsync();
            return Ok();
        }
    }
}
