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
    public List<Contact> GetContact()
    {
        return _contactService.GetContact();
    }
        [HttpPost]
        public int AddContact(Contact contact)
        {
            return _contactService.AddContact(contact);
        }
    [HttpPut]
    public int UpdateContact(Contact contact)
    {
        return _contactService.UpdateContact(contact);
    }
    [HttpDelete]
    public int DeleteContact(int id)
    {
        return _contactService.DeleteContact(id);
    }
   }

