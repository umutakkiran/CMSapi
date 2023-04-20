using Application.Abstraction.AbsGameMembership;
using Application.Abstraction.AbsPlayer;
using Application.Abstraction.AbsTeam;
using Application.ViewModel;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameMembershipController : ControllerBase
    {
        private readonly IGameMembershipReadRepository _readrepository;
        private readonly IGameMembershipWriteRepository _writerepository;

        public GameMembershipController(IGameMembershipReadRepository readrepository, IGameMembershipWriteRepository writerepository)
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
                p.TeamId,
                p.Team,
                p.Team.Name,
                p.IsHomeTeam,
                p.GameId,
                p.Game

            }
            ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_readrepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateGameMembershipModel model)
        {
            await _writerepository.AddAsync(new GameMembership()
            {
                TeamId = model.TeamId,
                GameId = model.GameId,
                IsHomeTeam = model.IsHomeTeam,  
                
            });

            await _writerepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(GameMembership model)
        {
            GameMembership p = await _readrepository.GetByIdAsync(model.Id.ToString());

            p.TeamId = model.TeamId;
            p.GameId = model.GameId;
            p.IsHomeTeam = model.IsHomeTeam;


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
