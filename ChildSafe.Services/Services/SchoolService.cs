using ChildSafe.Application.Dtos;
using ChildSafe.Application.Interfaces;
using ChildSafe.Domain.Entities;
using ChildSafe.Domain.Interfaces;

namespace ChildSafe.Application.Services
{
    public class SchoolService(ISchoolRepository schoolRepository) : ISchoolService
    {
        public async Task AddAsync(SchoolDto school)
        {
            await schoolRepository.AddAsync(new School
            {
                Name = school.Name,
                AdminId = school.AdminId,
                IsActive = school.IsActive,
                Address = school.Address,
                Email   = school.Email,
                Id = school.Id,
                IsDeleted = school.IsDeleted,
                PhoneNumber = school.PhoneNumber,
            });
        }

        public async Task DeleteAsync(int id)
        {
            await schoolRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SchoolDto>> GetAllAsync()
        {
            return await schoolRepository.GetAllAsync().ContinueWith(task =>
                task.Result.Select(school => new SchoolDto
                {
                    Id = school.Id,
                    Name = school.Name,
                    AdminId = school.AdminId,
                    IsActive = school.IsActive
                }));
        }

        public async Task<SchoolDto?> GetByIdAsync(int id)
        {
            var school = await schoolRepository.GetByIdAsync(id);

            if (school is null)
                return null;

            return new SchoolDto
            {
                Id = school.Id,
                Name = school.Name,
                AdminId = school.AdminId,
                IsActive = school.IsActive
            };
        }


        public async Task UpdateAsync(SchoolDto school)
        {
            await schoolRepository.UpdateAsync(new School
            {
                Id = school.Id,
                Name = school.Name,
                AdminId = school.AdminId,
                IsActive = school.IsActive
            });
        }
    }
}
