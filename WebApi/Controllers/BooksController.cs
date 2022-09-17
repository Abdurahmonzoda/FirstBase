using Domain.Dtos;
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
    public async Task<List<Books>> GetBooks()
    {
        return await _contactService.GetBooks();
    }

    [HttpGet("bookwithauthor")]
    public async Task<List<BookDto>> GetBookWithAuthor()
    {
        return await _contactService.GetBooksDto();
    }
    [HttpPost]
    public async Task <int> AddBooks(Books book)
    {
        return await _contactService.AddBooks(book);
    }
    [HttpPut]
    public async Task<int> UpdateBooks(Books book)
    {
        return await _contactService.UpdateBooks(book);
    }
    [HttpDelete]
    public async Task<int> DeleteBooks(int id)
    {
        return await _contactService.DeleteBooks(id);
    }
}
