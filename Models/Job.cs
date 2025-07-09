using Microsoft.AspNetCore.Components.Routing;

namespace JobPortalAPI.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        public DateTime ClosingDate { get; set; }
        public Location Location { get; set; }
        public Department Department { get; set; }
    }
}