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
        public List<Authors> GetAuthors()
        {
            return _contactService.GetAuthors();
        }
        [HttpPost]
        public int AddAuthors(Authors author)
        {
            return _contactService.AddAuthors(author);
        }
        [HttpPut]
        public int UpdateAuthors(Authors author)
        {
            return _contactService.UpdateAuthors(author);
        }
        [HttpDelete]
        public int DeleteAuthors(int id)
        {
            return _contactService.DeleteAuthors(id);
        }
    }
