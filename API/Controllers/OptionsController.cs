using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IOptionService OptionService;

        public OptionsController(IOptionService _OptionService)
        {
            OptionService = _OptionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var Options = await OptionService.GetOptions();
            return Options is null ? NotFound("No Options found!") : Ok(Options);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Option = await OptionService.GetOption(id);
            return Option is null ? NotFound("Option not found!") : Ok(Option);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Option quetion)
        {
            var result = await OptionService.AddOption(quetion);
            return result ? Ok("Option Added!") : Problem("Problem in adding the Option!");
        }

        [HttpPut]
        public async Task<IActionResult> PutExam(Option quetion, int id)
        {
            quetion.Id= id;    
            var result = await OptionService.UpdateOption(quetion);
            return result ? Ok("Option Updated!") : Problem("Problem in updating the Option!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var result = await OptionService.DeleteOption(id);
            return result ? Ok("Option deleted!") : Problem("Problem in deleting the Option!");
        }
    }
}
