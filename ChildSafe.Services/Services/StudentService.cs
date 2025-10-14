using ChildSafe.Application.Dtos;
using ChildSafe.Application.Interfaces;
using ChildSafe.Domain.Entities;
using ChildSafe.Domain.Interfaces;

namespace ChildSafe.Application.Services
{
    public class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        public async Task AddAsync(StudentDto student)
        {
            await studentRepository.AddAsync(new Student
            {
                Name = student.Name,
                ParentId = student.ParentId,
                IsActive = student.IsActive
            });
        }

        public async Task DeleteAsync(int id)
        {
            await studentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            return await studentRepository.GetAllAsync().ContinueWith(task =>
                task.Result.Select(student => new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    ParentId = student.ParentId,
                    IsActive = student.IsActive
                }));
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await studentRepository.GetByIdAsync(id);

            if (student is null)
                return null;

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                ParentId = student.ParentId,
                IsActive = student.IsActive
            };
        }


        public async Task UpdateAsync(StudentDto student)
        {
            await studentRepository.UpdateAsync(new Student
            {
                Id = student.Id,
                Name = student.Name,
                ParentId = student.ParentId,
                IsActive = student.IsActive
            });
        }
    }
}
