namespace JobPortalAPI.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}