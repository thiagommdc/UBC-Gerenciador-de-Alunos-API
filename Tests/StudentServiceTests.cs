using Microsoft.EntityFrameworkCore;
using UBC_Gerenciador_de_Alunos_API.Data;
using UBC_Gerenciador_de_Alunos_API.Models;
using UBC_Gerenciador_de_Alunos_API.Services;
using Tests;

public class StudentServiceTests
{
    private readonly ApplicationDbContext _context;
    private readonly StudentService _studentService;
    private readonly List<Student> _student;

    public StudentServiceTests()
    {
        _context = TestHelper.GetInMemoryDbContext();
        _studentService = new StudentService(_context);
        _student = new List<Student>
        {
            new Student { Id = 1, Nome = "Student 1", Endereco = "Rua A", NomePai = "Pai 1", NomeMae = "Mãe 1" },
            new Student { Id = 2, Nome = "Student 2", Endereco = "Rua B", NomePai = "Pai 2", NomeMae = "Mãe 2" }
        };
    }

    [Fact]
    public async Task GetAllStudents_ReturnsAllStudents()
    {
        var students = _student;
        await _context.Students.AddRangeAsync(students);
        await _context.SaveChangesAsync();

        var result = await _studentService.GetAllStudents();

        Assert.Equal(_student.Count(), result.Count);
    }

    [Fact]
    public async Task GetStudentById_ReturnsCorrectStudent()
    {
        var student = _student.First();
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        var result = await _studentService.GetStudentById(_student.First().Id);
        Assert.Equal(_student.First().Nome, result.Nome);
    }

    [Fact]
    public async Task CreateStudent_AddsStudent()
    {
        var student = _student.First();
        await _studentService.CreateStudent(student);
        var students = await _context.Students.ToListAsync();
        Assert.Single(students);
        Assert.Equal(_student.First().Nome, students[0].Nome);
    }

    [Fact]
    public async Task UpdateStudent_UpdatesStudent()
    {
        var student = _student.First();
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        student.Nome = "Updated Student 1";

        await _studentService.UpdateStudent(student);

        var updatedStudent = await _context.Students.FindAsync(1);
        Assert.Equal("Updated Student 1", updatedStudent.Nome);
    }

    [Fact]
    public async Task DeleteStudent_DeletesStudent()
    {
        var student = _student.First();
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        await _studentService.DeleteStudent(_student.First().Id);

        var students = await _context.Students.ToListAsync();
        Assert.Empty(students);
    }
}
