using System.Reflection.Metadata.Ecma335;
using JobPortalAPI.DTOs;
using JobPortalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class MastersController : ControllerBase
    {
        private readonly IMasterService _service;
        public MastersController(IMasterService service)
        {
            _service = service;
        }

        //Departments
        [HttpGet("departments")]
        public async Task<IActionResult> GetDepartments() =>
            Ok(await _service.GetDepartmentsAsync());

        [HttpPost("departments")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentsDto dto)
        {
            await _service.AddDepartmentAsync(dto);
            return Ok();
        }

        [HttpPut("departments/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentsDto dto)
        {
            await _service.UpdateDepartmentAsync(id, dto);
            return Ok();
        }

        //Locations
        [HttpGet("locations")]
        public async Task<IActionResult> GetLocations() =>
            Ok(await _service.GetLocationsAsync());

        [HttpPost("locations")]
        public async Task<IActionResult> CreateLocation([FromBody] LocationsDto dto)
        {
            await _service.AddLocationAsync(dto);
            return Ok();
        }

        [HttpPut("locations/{id}")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationsDto dto)
        {
            await _service.UpdateLocationAsync(id, dto);
            return Ok();
        }        
    }
}