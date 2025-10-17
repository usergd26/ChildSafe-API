using ChildSafe.Application.Dtos;
using ChildSafe.Application.Interfaces;

namespace ChildSafe.API.Endpoints
{
    public static class AttendanceEndpoints
    {
        public const string endpointGroup = "Attendance";
        public static void MapAttendanceEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/attendances", async (IAttendanceService attendanceService, int studentId) =>
            {
                var attendances = await attendanceService.GetAllAsync(studentId);
                return Results.Ok(attendances);
            }).WithTags(endpointGroup);

            app.MapPost("/attendance", async (IAttendanceService attendanceService, AttendanceDto attendance) =>
            {
                await attendanceService.AddAsync(attendance);
                return Results.Ok();
            }).WithTags(endpointGroup);
        }
    }
}
