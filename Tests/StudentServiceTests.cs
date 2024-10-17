using Microsoft.EntityFrameworkCore;
using UBC_Gerenciador_de_Alunos_API.Data;
using UBC_Gerenciador_de_Alunos_API.Models;
using UBC_Gerenciador_de_Alunos_API.Services;
using Tests;
using Moq;

public class StudentServiceTests
{
    private readonly Mock<IStudentRepository> _studentRepositoryMock;
    private readonly StudentService _studentService;
    private readonly List<Student> _students;

    public StudentServiceTests()
    {
        _studentRepositoryMock = new Mock<IStudentRepository>();
        _studentService = new StudentService(_studentRepositoryMock.Object);

        _students = new List<Student>
        {
            new Student { Id = 1, Nome = "Student 1", Endereco = "Rua A", NomePai = "Pai 1", NomeMae = "Mãe 1" },
            new Student { Id = 2, Nome = "Student 2", Endereco = "Rua B", NomePai = "Pai 2", NomeMae = "Mãe 2" }
        };
    }

    [Fact]
    public async Task GetAllStudents_ReturnsAllStudents()
    {
        _studentRepositoryMock.Setup(repo => repo.GetAllStudents()).ReturnsAsync(_students);

        var result = await _studentService.GetAllStudents();

        Assert.Equal(_students.Count, result.Count);
    }

    [Fact]
    public async Task GetStudentById_ReturnsCorrectStudent()
    {
        var student = _students.First();
        _studentRepositoryMock.Setup(repo => repo.GetStudentById(student.Id)).ReturnsAsync(student);

        var result = await _studentService.GetStudentById(student.Id);

        Assert.Equal(student.Nome, result.Nome);
    }

    [Fact]
    public async Task CreateStudent_AddsStudent()
    {
        var student = _students.First();
        await _studentService.CreateStudent(student);

        _studentRepositoryMock.Verify(repo => repo.CreateStudent(student), Times.Once);
    }

    [Fact]
    public async Task UpdateStudent_UpdatesStudent()
    {
        var student = _students.First();
        student.Nome = "Updated Student 1";

        await _studentService.UpdateStudent(student);

        _studentRepositoryMock.Verify(repo => repo.UpdateStudent(student), Times.Once);
    }

    [Fact]
    public async Task DeleteStudent_DeletesStudent()
    {
        var student = _students.First();

        await _studentService.DeleteStudent(student.Id);

        _studentRepositoryMock.Verify(repo => repo.DeleteStudent(student.Id), Times.Once);
    }
}