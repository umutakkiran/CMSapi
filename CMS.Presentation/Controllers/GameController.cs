using Application.Abstraction.AbsGame;
using Application.Abstraction.AbsTeam;
using Application.ViewModel;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameReadRepository _readrepository;
        private readonly IGameWriteRepository _writerepository;

        public GameController(IGameReadRepository readrepository, IGameWriteRepository writerepository)
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
               p.Date,
               p.HomeTeam,
               p.AwayTeam,
               p.HomeTeamScore,
               p.AwayTeamScore,
               p.Stadium,
               p.Week,
               p.WeekId
                

            }
            ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return Ok(await _readrepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateGameModel model)
        {
            await _writerepository.AddAsync(new Game()
            {
               
               Date= model.Date,
               homeTeamId = model.homeTeamId,
               awayTeamId = model.awayTeamId,
               HomeTeamScore = model.HomeTeamScore,
               AwayTeamScore = model.AwayTeamScore,
               Stadium = model.Stadium,
               WeekId = model.WeekId

            });

            await _writerepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Game model)
        {
            Game p = await _readrepository.GetByIdAsync(model.Id.ToString());

            p.Date = model.Date;
            p.homeTeamId = model.homeTeamId;
            p.awayTeamId = model.awayTeamId;
            p.HomeTeamScore = model.HomeTeamScore;
            p.AwayTeamScore = model.AwayTeamScore;
            p.Stadium = model.Stadium;
            p.WeekId = model.WeekId;

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
