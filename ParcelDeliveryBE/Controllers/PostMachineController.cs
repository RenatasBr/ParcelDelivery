using Microsoft.AspNetCore.Mvc;
using ParcelDeliveryBE.Dtos;
using ParcelDeliveryBE.Services;
using System.Threading.Tasks;

namespace ParcelDeliveryBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostMachineController : ControllerBase
    {
        private readonly PostMachineService _postMachineService;

        public PostMachineController(PostMachineService postMachineService)
        {
            _postMachineService = postMachineService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _postMachineService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var entity = await _postMachineService.GetByIdAsync(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostMachineUpdateDto entity)
        {
            await _postMachineService.CreateAsync(entity);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PostMachineUpdateDto entity)
        {
            await _postMachineService.UpdateAsync(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveById(int id)
        {
            await _postMachineService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/PostMachineAssignParcel")]
        public async Task<IActionResult> PostMachineAssignParcel(int id, PostMachineAssignParcelDto postMachineEntity)
        {
            await _postMachineService.PostMachineAssignParcelAsync(id, postMachineEntity);
            return NoContent();
        }

    }     
}
