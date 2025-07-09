using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using JobPortalAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Xunit;

namespace JobPortalAPI.Tests
{
    public class JobServiceTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new AppDbContext(options);

            //Send data
            dbContext.Departments.Add(new Department { Id = 1, Title = "Engineering" });
            dbContext.Locations.Add(new Location { Id = 1, Title = "Head Office", City = "Margao", State = "Goa", Country = "India", Zip = 403709 });
            dbContext.SaveChanges();
            return dbContext;
        }

        [Fact]
        public async Task CreateJob_ShouldReturnNewId()
        {
            //Arrange
            var db = GetDbContext();
            var service = new JobService(db);
            var dto = new JobCreateDto
            {
                Title = "Backend Developer",
                Description = "Test job",
                DepartmentId = 1,
                LocationId = 1,
                ClosingDate = DateTime.UtcNow.AddDays(30)
            };

            //Act
            var id = await service.CreateJobAsync(dto);

            //Assert
            Assert.True(id > 0);
            Assert.NotNull(await db.Jobs.FindAsync(id));
        }
    }
}