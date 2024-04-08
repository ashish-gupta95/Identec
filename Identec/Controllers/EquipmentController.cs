using Identec.Model;
using Identec.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace Identec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        // GET: api/equipment
        [HttpGet("{equipmentId}")]
        public async Task<IActionResult> GetEquipmentByIdAsync(int equipmentId)
        {
            var equipment = await _equipmentService.GetEquipmentByIdAsync(equipmentId);
            if (equipment == null)
            {
                return NotFound();
            }
            return Ok(equipment);
        }

        [HttpPost()]
        public async Task<IActionResult> UpdateEquipmentAsync([FromBody] Equipment equipment) // we can another model for equipment
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _equipmentService.UpdateEquipmentAsync(equipment);
            return NoContent(); // Or return Ok(updatedEquipment) if you want to return the updated equipment
        }

        
    }

}
