using ChildSafe.Domain.Entities;
using ChildSafe.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChildSafe.Domain.Repositories
{
    public class AttendanceRepository(AppDbContext context) : IAttendanceRepository
    {
        public async Task AddAsync(Attendance attendance)
        {
            await context.Attendances.AddAsync(attendance);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync(int studentId)
        {
            return await context.Attendances.Where(x => x.StudentId == studentId).ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await context.Attendances.FindAsync(id);
        }

        public async Task UpdateAsync(Attendance attendance)
        {
            var existingRecord = await context.Attendances.FirstOrDefaultAsync(a => a.Id == attendance.Id);

            if (existingRecord is null)
                throw new Exception("Attendance record not found");
            
            existingRecord.WentFromHomeTime = attendance.WentFromHomeTime;
            existingRecord.ReachedSchoolTime = attendance.ReachedSchoolTime;
            existingRecord.WentFromSchoolTime = attendance.WentFromSchoolTime;
            existingRecord.ReachedHomeTime = attendance.ReachedHomeTime;
            existingRecord.LastUpdatedBy = attendance.LastUpdatedBy;
            existingRecord.LastUpdatedOn = attendance.LastUpdatedOn;
            existingRecord.Date = attendance.Date;
            context.Attendances.Update(existingRecord);
            await context.SaveChangesAsync();
        }
    }
}
