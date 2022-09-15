using Domain.Emtities;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class BooksController
{
    private BooksServices _contactService;
    public BooksController()
    {
        _contactService = new BooksServices();
    }
    [HttpGet]
    public List<Books> GetBooks()
    {
        return _contactService.GetBooks();
    }
    [HttpPost]
    public int AddBooks(Books book)
    {
        return _contactService.AddBooks(book);
    }
    [HttpPut]
    public int UpdateBooks(Books book)
    {
        return _contactService.UpdateBooks(book);
    }
    [HttpDelete]
    public int DeleteBooks(int id)
    {
        return _contactService.DeleteBooks(id);
    }
}
