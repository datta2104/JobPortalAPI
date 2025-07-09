namespace JobPortalAPI.DTOs
{
    public class JobListResponseDto
    {
        public int Total { get; set; }
        public List<JobListItemDto> Data { get; set; } = new();
    }
}