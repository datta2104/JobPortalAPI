namespace JobPortalAPI.DTOs
{
    public class JobListRequestDto
    {
        public string Q { get; set; } = "";
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
    }
}