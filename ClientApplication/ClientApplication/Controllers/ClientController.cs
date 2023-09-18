using ClientApplication.Core.Entities;
using ClientApplication.Core.Interfaces;
using ClientApplication.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ClientApplication.Controllers
{
    [ApiController]
    [Route("clients")]

    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository; 
        public ClientController(IClientRepository clientRepository) => _clientRepository = clientRepository;

        [HttpGet]
        public Task<List<Client>> GetClients() => _clientRepository.GetClients();


        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            _clientRepository.Add(client);
            return Ok();
        }

        [HttpPost("UploadFile")]
        public ActionResult UploadFile(IFormFile file)
        {
            var serializer = new XmlSerializer(typeof(Client));

            XmlReader reader = XmlReader.Create(file.OpenReadStream());
            Client client = (Client)serializer.Deserialize(reader);
            _clientRepository.Add(client);

            return Ok();
        }
    }
}
