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
    public List<Categories> GetCategories()
    {
        return _contactService.GetCategories();
    }
    [HttpPost]
    public int AddCategories(Categories categorie)
    {
        return _contactService.AddCategories(categorie);
    }
    [HttpPut]
    public int UpdateCategories(Categories categorie)
    {
        return _contactService.UpdateCategories(categorie);
    }
    [HttpDelete]
    public int DeleteCategories(int id)
    {
        return _contactService.DeleteCategories(id);
    }
}
