using UBC_Gerenciador_de_Alunos_API.Models;

namespace UBC_Gerenciador_de_Alunos_API.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task CreateStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}
