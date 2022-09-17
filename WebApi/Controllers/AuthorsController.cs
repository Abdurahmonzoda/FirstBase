using Domain.Emtities;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace WebApi.Controllers; 
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController
    {
        private AuthorsServices _contactService;
        public AuthorsController()
        {
            _contactService = new AuthorsServices();
        }
        [HttpGet]
        public async Task< List<Authors>> GetAuthors()
        {
            return await _contactService.GetAuthors();
        }
        [HttpPost]
        public async Task<int> AddAuthors(Authors author)
        {
            return await _contactService.AddAuthors(author);
        }
        [HttpPut]
        public async Task<int> UpdateAuthors(Authors author)
        {
            return await _contactService.UpdateAuthors(author);
        }
        [HttpDelete]
        public async Task<int> DeleteAuthors(int id)
        {
            return await _contactService.DeleteAuthors(id);
        }
    }
