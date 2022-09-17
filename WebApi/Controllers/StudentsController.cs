using Domain.Emtities;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentsController
{
    private StudentsServices _contactService;
    public StudentsController()
    {
        _contactService = new StudentsServices();
    }
    [HttpGet]
    public async Task <List<Students>> GetStudents()
    {
        return await _contactService.GetStudents();
    }
    [HttpPost]
    public async Task<int> AddStudents(Students student)
    {
        return await _contactService.AddStudents(student);
    }
    [HttpPut]
    public async Task<int> UpdateStudents(Students student)
    {
        return await _contactService.UpdateStudents(student);
    }
    [HttpDelete]
    public async Task<int> DeleteStudents(int id)
    {
        return await _contactService.DeleteStudents(id);

    }
}
