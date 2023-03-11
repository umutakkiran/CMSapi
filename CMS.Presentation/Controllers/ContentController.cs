using Application.Abstraction.AbsContent;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentReadRepository _readrepository;
        private readonly IContentWriteRepository _writerepository;

        public ContentController(IContentReadRepository readrepository, IContentWriteRepository writerepository)
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
                p.AnyText,
                p.Title,

            }
            ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_readrepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Content model)
        {
            await _writerepository.AddAsync(new Content()
            {
                AnyText = model.AnyText,
                Title = model.Title,
            });

            await _writerepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Content model)
        {
            Content p = await _readrepository.GetByIdAsync(model.Id.ToString());

            p.AnyText = model.AnyText;
            p.Title = model.Title;

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
