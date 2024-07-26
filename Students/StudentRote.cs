using ApiCrud.Data;
using ApiCrud.Students;

namespace ApiCrud.Student
{
    public static class StudentRote
    {
        public static void addStudentRote(this WebApplication app)
        {
            var StudentsRoute = app.MapGroup("estudantes");

            StudentsRoute.MapPost("", async(AddStudentRequest request, AppDbContext context) => 
            {
                var newStudent = new Student(request.name);
                await context.students.AddAsync(newStudent);
                await context.SaveChangesAsync();
            });
        }
    }
}
