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
    public List<Students> GetStudents()
    {
        return _contactService.GetStudents();
    }
    [HttpPost]
    public int AddStudents(Students student)
    {
        return _contactService.AddStudents(student);
    }
    [HttpPut]
    public int UpdateStudents(Students student)
    {
        return _contactService.UpdateStudents(student);
    }
    [HttpDelete]
    public int DeleteStudents(int id)
    {
        return _contactService.DeleteStudents(id);
    }
}
