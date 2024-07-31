using ApiCrud.Data;
using ApiCrud.Students;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Student
{
    public static class StudentRote
    {
        public static void addStudentRote(this WebApplication app)
        {
            var StudentsRoute = app.MapGroup("estudantes");

            //CRIA
            StudentsRoute.MapPost("", async (AddStudentRequest request, AppDbContext context, CancellationToken ct) =>
            {
                var newStudent = new Student(request.name);
                await context.Students.AddAsync(newStudent, ct);
                await context.SaveChangesAsync(ct);
                var returnStudent = new StudentDTO(newStudent.Id, newStudent.Name);
                return Results.Ok(returnStudent);
            });

            //LER
            StudentsRoute.MapGet("", async (AppDbContext context, CancellationToken ct) =>
            {
                var students = await context
                .Students
                .Where(student => student.Active)
                .Select(student => new StudentDTO(student.Id, student.Name))
                .ToListAsync(ct);
                return students;
            });

            //ATUALIZA
            StudentsRoute.MapPut("{id}", async (Guid id, UpdateStudentRequest request, AppDbContext context, CancellationToken ct) =>
            {
                var student = await context.Students.SingleOrDefaultAsync(student => student.Id == id, ct);
                
                if (student == null)
                    return Results.NotFound();

                student.UpdateName(request.name);
                await context.SaveChangesAsync(ct);
                return Results.Ok(new StudentDTO(student.Id, student.Name));
            });

            //DELETAR
            StudentsRoute.MapDelete("{id}", async (Guid id, AppDbContext context, CancellationToken ct) =>
            {
                var student = await context.Students.SingleOrDefaultAsync(student => student.Id == id, ct);

                if (student == null)
                    return Results.NotFound();

                student.StatusActive();
                await context.SaveChangesAsync(ct);
                return Results.Ok();
            });
        }
    }
}
