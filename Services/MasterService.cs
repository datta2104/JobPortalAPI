using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Services
{
    public class MasterService : IMasterService
    {
        private readonly AppDbContext _context;
        public MasterService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<DepartmentsDto>> GetDepartmentsAsync()
        {
            return await _context.Departments
                .Select(d => new DepartmentsDto { Id = d.Id, Title = d.Title })
                .ToListAsync();
        }
        public async Task AddDepartmentAsync(DepartmentsDto dto)
        {
            _context.Departments.Add(new Department { Title = dto.Title });
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDepartmentAsync(int id, DepartmentsDto dto)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept != null)
            {
                dept.Title = dto.Title;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<LocationsDto>> GetLocationsAsync()
        {
            return await _context.Locations
                .Select(l => new LocationsDto
                {
                    Id = l.Id,
                    Title = l.Title,
                    City = l.City,
                    State = l.State,
                    Country = l.Country,
                    Zip = l.Zip
                }).ToListAsync();
        }
        public async Task AddLocationAsync(LocationsDto dto)
        {
            _context.Locations.Add(new Location
            {
                Id = dto.Id,
                Title = dto.Title,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                Zip = dto.Zip
            });
            await _context.SaveChangesAsync();
        }
        public async Task UpdateLocationAsync(int id, LocationsDto dto)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                location.Title = dto.Title;
                location.City = dto.City;
                location.State = dto.State;
                location.Country = dto.Country;
                location.Zip = dto.Zip;
                await _context.SaveChangesAsync();
            }
        }
    }
}