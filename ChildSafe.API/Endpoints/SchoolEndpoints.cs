using ChildSafe.Application.Dtos;
using ChildSafe.Application.Interfaces;
using System.Security.Claims;

namespace ChildSafe.API.Endpoints
{
    public static class SchoolEndpoints
    {
        private const string endpointGroup = "School";
        public static void MapSchoolEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/schools", async (ISchoolService schoolService) =>
            {
                var schools = await schoolService.GetAllAsync();
                return Results.Ok(schools);
            })
            .WithTags(endpointGroup);
            //.RequireAuthorization();

            app.MapGet("/school/{id}", async (int id, ISchoolService schoolService) =>
            {
                var school = await schoolService.GetByIdAsync(id);
                return school is not null ? Results.Ok(school) : Results.NotFound("Student not found.");
            })
            .WithTags(endpointGroup)
            .RequireAuthorization();

            app.MapPost("/school", async (SchoolDto school, ISchoolService schoolService, ClaimsPrincipal user) =>
            {
                var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                if(userId is null && school.AdminId is null)
                    return Results.BadRequest("AdminId is required.");
                school.AdminId = userId is not null ? userId : school.AdminId;
                await schoolService.AddAsync(school);
                return Results.Created($"/school/{school.Id}", school);
            })
            .WithTags(endpointGroup);
            //.RequireAuthorization("AdminOnly");

            app.MapPut("/school/{id}", async (int id, SchoolDto updatedSchool, ISchoolService schoolService) =>
            {
                var existingSchool = await schoolService.GetByIdAsync(id);
                if (existingSchool is null)
                    return Results.NotFound("School not found.");
                existingSchool.Name = updatedSchool.Name;
                existingSchool.AdminId = updatedSchool.AdminId;
                existingSchool.IsActive = updatedSchool.IsActive;
                await schoolService.UpdateAsync(existingSchool);
                return Results.NoContent();
            })
            .WithTags(endpointGroup)

            .RequireAuthorization("AdminOnly");
            app.MapDelete("/school/{id}", async (int id, ISchoolService schoolService) =>
            {
                var existingSchool = await schoolService.GetByIdAsync(id);
                if (existingSchool is null)
                    return Results.NotFound("School not found.");
                await schoolService.DeleteAsync(existingSchool.Id);
                return Results.NoContent();
            })
            .WithTags(endpointGroup);
            //.RequireAuthorization("AdminOnly");
        }
    }

}
