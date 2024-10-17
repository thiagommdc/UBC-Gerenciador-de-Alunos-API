using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UBC_Gerenciador_de_Alunos_API.Models;
using UBC_Gerenciador_de_Alunos_API.Services;

namespace UBC_Gerenciador_de_Alunos_API.Controllers
{
    [ApiController]
    [Route("api/students")]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var students = await _studentService.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao recuperar os estudantes.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var student = await _studentService.GetStudentById(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao recuperar os dados do estudante");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                await _studentService.CreateStudent(student);
                return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao criar o cadastro de estudante");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            try
            {
                await _studentService.UpdateStudent(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o cadastro do estudante");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar deletar o estudante");
            }
        }
    }
}
