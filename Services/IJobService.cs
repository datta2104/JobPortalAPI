using JobPortalAPI.DTOs;

namespace JobPortalAPI.Services
{
    public interface IJobService
    {
        Task<int> CreateJobAsync(JobCreateDto dto);
        Task<bool> UpdateJobAsync(int id, JobUpdateDto dto);
        Task<JobListResponseDto> GetJobsAsync(JobListRequestDto dto);
        Task<JobDetailsDto?> GetJobByIdAsync(int id);
    }
}