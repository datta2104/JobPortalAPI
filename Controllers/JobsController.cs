using JobPortalAPI.DTOs;
using JobPortalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobPortalAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        //POST: /api/v1/jobs
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new job.", Description = "Creates a job record and returns it's ID.")]
        [SwaggerResponse(201, "Job created")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobId = await _jobService.CreateJobAsync(dto);
            return Created($"api/v1/jobs/{jobId}", null);
        }
        //PUT: /api/v1/jobs/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a job record", Description = "Updates a specific job record based on it's ID.")]
        [SwaggerResponse(201, "Job updated")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] JobUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updated = await _jobService.UpdateJobAsync(id, dto);
            if (!updated)
            {
                return NotFound();
            }
            return Ok();
        }
        //POST: /api/v1/jobs/list
        [HttpPost("/api/v1/jobs/list")]
        [SwaggerOperation(Summary = "Get all jobs", Description = "Get a list of all the jobs posted.")]
        [SwaggerResponse(201, "Fetched all jobs")]
        public async Task<IActionResult> GetJobs([FromBody] JobListRequestDto dto)
        {
            var result = await _jobService.GetJobsAsync(dto);
            return Ok(result);
        }
        //GET: /api/v1/jobs/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null) return NotFound();
            return Ok(job);
        }
    }
}