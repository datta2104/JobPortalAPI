using JobPortalAPI.DTOs;

namespace JobPortalAPI.Services
{
    public interface IMasterService
    {
        Task<List<DepartmentsDto>> GetDepartmentsAsync();
        Task AddDepartmentAsync(DepartmentsDto dto);
        Task UpdateDepartmentAsync(int id, DepartmentsDto dto);

        Task<List<LocationsDto>> GetLocationsAsync();
        Task AddLocationAsync(LocationsDto dto);
        Task UpdateLocationAsync(int id, LocationsDto dto);
    }
}