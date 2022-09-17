using Domain.Emtities;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoriesController
{
    private CategoriesServices _contactService;
    public CategoriesController()
    {
        _contactService = new CategoriesServices();
    }
    [HttpGet]
    public async Task< List<Categories>> GetCategories()
    {
        return await _contactService.GetCategories();
    }
    [HttpPost]
    public async Task<int> AddCategories(Categories categorie)
    {
        return await _contactService.AddCategories(categorie);
    }
    [HttpPut]
    public async Task<int> UpdateCategories(Categories categorie)
    {
        return await _contactService.UpdateCategories(categorie);
    }
    [HttpDelete]
    public async Task<int> DeleteCategories(int id)
    {
        return await _contactService.DeleteCategories(id);
    }
}
