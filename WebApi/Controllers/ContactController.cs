using Domain.Emtities;
using Microsoft.AspNetCore.Mvc;
using Services.Services; 
namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
    public class ContactController
    {
        private ContactServices _contactService;
        public ContactController()
        {
            _contactService = new ContactServices();
        }
    [HttpGet]
    public async Task < List<Contact>> GetContact()
    {
        return await _contactService.GetContact();
    }
        [HttpPost]
        public async Task<int> AddContact(Contact contact)
        {
            return await _contactService.AddContact(contact);
        }
    [HttpPut]
    public async Task<int> UpdateContact(Contact contact)
    {
        return await _contactService.UpdateContact(contact);
    }
    [HttpDelete]
    public async Task<int> DeleteContact(int id)
    {
        return await _contactService.DeleteContact(id);
    }
   }

