using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentsService _studentsService;

    public StudentsController(StudentsService studentsService) =>
        _studentsService = studentsService;

    // Método para consultar alumnos por grado
    [HttpGet("consultar-alumno/{grado}")]
    public async Task<ActionResult<List<Students>>> GetByGrado(string grado)
    {
        var students = await _studentsService.GetByGradoAsync(grado);

        if (students is null || students.Count == 0)
        {
            return NotFound("No se encontraron alumnos para el grado especificado.");
        }

        return students;
    }

    // Método para crear un nuevo alumno
    [HttpPost("crear-alumno")]
    public async Task<IActionResult> CreateAlumno([FromBody] Students newStudent)
    {
        if (newStudent is null)
        {
            return BadRequest("El cuerpo de la solicitud está vacío.");
        }

        await _studentsService.CreateAsync(newStudent);
        return CreatedAtAction(nameof(Get), new { id = newStudent.Id }, newStudent);
    }

    // Métodos existentes...
    [HttpGet]
    public async Task<List<Students>> Get() =>
        await _studentsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Students>> Get(string id)
    {
        var students = await _studentsService.GetAsync(id);

        if (students is null)
        {
            return NotFound();
        }

        return students;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Students updatedStudents)
    {
        var students = await _studentsService.GetAsync(id);

        if (students is null)
        {
            return NotFound();
        }

        updatedStudents.Id = students.Id;

        await _studentsService.UpdateAsync(id, updatedStudents);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var students = await _studentsService.GetAsync(id);

        if (students is null)
        {
            return NotFound();
        }

        await _studentsService.RemoveAsync(id);

        return NoContent();
    }
}
