using Domain.Emtities;
using Services.Services;

var contact = new Contact();
contact.Name = "ccdd";
contact.Id = 1;
contact.Messange = "fdfvsdfv";
contact.Phone = "+999393";
var contactService = new ContactServices();
var n = contactService.DeleteContact(1);
if( n == 1)
    Console.WriteLine("yes");
else
    Console.WriteLine("no");