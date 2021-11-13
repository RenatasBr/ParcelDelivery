using Microsoft.AspNetCore.Mvc;
using ParcelDeliveryBE.Dtos;
using ParcelDeliveryBE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelService _parcelService;

        public ParcelController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _parcelService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var entity = await _parcelService.GetByIdAsync(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ParcelUpdateDto entity)
        {
            await _parcelService.CreateAsync(entity);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ParcelUpdateDto entity)
        {
            await _parcelService.UpdateAsync(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveById(int id)
        {
            await _parcelService.DeleteAsync(id);
            return NoContent();
        }
    }
}
