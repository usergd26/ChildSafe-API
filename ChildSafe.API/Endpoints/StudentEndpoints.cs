using ChildSafe.Application.Dtos;
using ChildSafe.Application.Interfaces;
using System.Security.Claims;

namespace ChildSafe.API.Endpoints
{
    public static class StudentEndpoints
    {
        private const string endpointGroup = "Student";
        public static void MapStudentEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/students", async (IStudentService studentService) =>
            {
                var students = await studentService.GetAllAsync();
                return Results.Ok(students);
            })
            .WithTags(endpointGroup);
            //.RequireAuthorization();

            app.MapGet("/students/{id}", async (int id, IStudentService studentService) =>
            {
                var student = await studentService.GetByIdAsync(id);
                return student is not null ? Results.Ok(student) : Results.NotFound("Student not found.");
            })
            .WithTags(endpointGroup)
            .RequireAuthorization();

            app.MapPost("/students", async (StudentDto student, IStudentService studentService, ClaimsPrincipal user) =>
            {
                var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId is null && student.ParentId is null)
                    return Results.BadRequest("ParentId is required.");
                student.ParentId = userId is not null ? userId : student.ParentId;
                await studentService.AddAsync(student);
                return Results.Created($"/students/{student.Id}", student);
            })
            .WithTags(endpointGroup);
            //.RequireAuthorization("AdminOnly");

            app.MapPut("/students/{id}", async (int id, StudentDto updatedStudent, IStudentService studentService) =>
            {
                var existingStudent = await studentService.GetByIdAsync(id);
                if (existingStudent is null)
                    return Results.NotFound("Student not found.");
                existingStudent.Name = updatedStudent.Name;
                existingStudent.ParentId = updatedStudent.ParentId;
                existingStudent.IsActive = updatedStudent.IsActive;
                await studentService.UpdateAsync(existingStudent);
                return Results.NoContent();
            })
            .WithTags(endpointGroup)

            .RequireAuthorization("AdminOnly");
            app.MapDelete("/students/{id}", async (int id, IStudentService studentService) =>
            {
                var existingStudent = await studentService.GetByIdAsync(id);
                if (existingStudent is null)
                    return Results.NotFound("Student not found.");
                await studentService.DeleteAsync(existingStudent.Id);
                return Results.NoContent();
            })
            .WithTags(endpointGroup);
            //.RequireAuthorization("AdminOnly");
        }
    }
}
