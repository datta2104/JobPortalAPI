using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Services
{
    public class JobService : IJobService
    {
        private readonly AppDbContext _context;
        public JobService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateJobAsync(JobCreateDto dto)
        {
            var job = new Job
            {
                Title = dto.Title,
                Description = dto.Description,
                LocationId = dto.LocationId,
                DepartmentId = dto.DepartmentId,
                ClosingDate = dto.ClosingDate,
                PostedDate = DateTime.UtcNow,
                Code = "JOB-" + DateTime.UtcNow.Ticks.ToString().Substring(10)
            };
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return job.Id;
        }
        public async Task<bool> UpdateJobAsync(int id, JobUpdateDto dto)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return false;
            job.Title = dto.Title;
            job.Description = dto.Description;
            job.LocationId = dto.LocationId;
            job.DepartmentId = dto.DepartmentId;
            job.ClosingDate = dto.ClosingDate;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<JobListResponseDto> GetJobsAsync(JobListRequestDto dto)
        {
            var query = _context.Jobs
                .Include(j => j.Department)
                .Include(j => j.Location)
                .AsQueryable();

            if (!String.IsNullOrEmpty(dto.Q))
            {
                query = query.Where(j => j.Title.Contains(dto.Q) || j.Description.Contains(dto.Q));
            }
            if (dto.DepartmentId.HasValue)
            {
                query = query.Where(j => j.DepartmentId == dto.DepartmentId.Value);
            }
            if (dto.LocationId.HasValue)
            {
                query = query.Where(j => j.LocationId == dto.LocationId.Value);
            }
            var total = await query.CountAsync();
            var jobs = await query
                .OrderByDescending(j => j.PostedDate)
                .Skip((dto.PageNo - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .Select(j => new JobListItemDto
                {
                    Id = j.Id,
                    Code = j.Code,
                    Title = j.Title,
                    Location = j.Location.Title,
                    Department = j.Department.Title,
                    PostedDate = j.PostedDate,
                    ClosingDate = j.ClosingDate
                }).ToListAsync();
            return new JobListResponseDto
            {
                Total = total,
                Data = jobs
            };
        }
        public async Task<JobDetailsDto?> GetJobByIdAsync(int id)
        {
            var job = await _context.Jobs
                .Include(j => j.Department)
                .Include(j => j.Location)
                .FirstOrDefaultAsync(j => j.Id == id);

            if (job == null) return null;
            return new JobDetailsDto
            {
                Id = job.Id,
                Code = job.Code,
                Title = job.Title,
                Description = job.Description,
                PostedDate = job.PostedDate,
                ClosingDate = job.ClosingDate,
                Department = new DepartmentDto
                {
                    Id = job.Department.Id,
                    Title = job.Department.Title
                },
                Location = new LocationDto
                {
                    Id = job.Location.Id,
                    Title = job.Location.Title,
                    City = job.Location.City,
                    State = job.Location.State,
                    Country = job.Location.Country,
                    Zip = job.Location.Zip
                }
            };
        }
    }
}