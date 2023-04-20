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
    public class PlayerController : ControllerBase
    { 
        private readonly IPlayerReadRepository _readrepository;
        private readonly IPlayerWriteRepository _writerepository;

         public PlayerController(IPlayerReadRepository readrepository, IPlayerWriteRepository writerepository)
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
                p.Name,
                p.Surname,
                p.height,
                p.weight,
                p.age,
                p.Photo,
                p.Team

            }
            ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_readrepository.GetByIdAsync(id, false));
        }

        [HttpGet("{action}/{id}")]
        public async Task<IActionResult> GetPlayersByTeam(string id)
        {
            return Ok( _readrepository.GetPlayerByTeam(p => p.TeamId == Guid.Parse( id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePlayerModel model)
        {
            await _writerepository.AddAsync(new Player()
            {
                TeamId = model.TeamId,
                Name = model.Name,
                Surname = model.Surname,
                height = model.height,  
                weight = model.weight,    
                age = model.age,
                Photo = model.photo
            });

            await _writerepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Player model)
        {
            Player p = await _readrepository.GetByIdAsync(model.Id.ToString());

            p.Name = model.Name;
            p.Surname = model.Surname;
            p.height = model.height;
            p.weight = model.weight;
            p.age = model.age;
            p.Photo = model.Photo;


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
