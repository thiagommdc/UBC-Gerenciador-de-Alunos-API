using Microsoft.EntityFrameworkCore;
using UBC_Gerenciador_de_Alunos_API.Data;
using UBC_Gerenciador_de_Alunos_API.Models;

namespace UBC_Gerenciador_de_Alunos_API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _repository.GetAllStudents();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _repository.GetStudentById(id);
        }

        public async Task CreateStudent(Student student)
        {
            await _repository.CreateStudent(student);
        }

        public async Task UpdateStudent(Student student)
        {
            await _repository.UpdateStudent(student);
        }

        public async Task DeleteStudent(int id)
        {
            await _repository.DeleteStudent(id);
        }
    }
}
