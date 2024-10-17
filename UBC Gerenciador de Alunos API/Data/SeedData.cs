using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using UBC_Gerenciador_de_Alunos_API.Models;

namespace UBC_Gerenciador_de_Alunos_API.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (!context.Students.Any())
            {
                var basePath = AppContext.BaseDirectory;
                var studentFilePath = Path.Combine(basePath, "students.csv");
                var students = LoadStudentsFromCsv(studentFilePath);
                context.Students.AddRange(students);
            }

            if (!context.Users.Any())
            {
                var basePath = AppContext.BaseDirectory;
                var userFilePath = Path.Combine(basePath, "users.csv");
                var users = LoadUsersFromCsv(userFilePath);
                context.Users.AddRange(users);
            }

            context.SaveChanges();
        }

        private static List<Student> LoadStudentsFromCsv(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Student>().ToList();
        }

        private static List<User> LoadUsersFromCsv(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<User>().ToList();
        }
    }
}
