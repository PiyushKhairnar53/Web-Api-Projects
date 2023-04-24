using LexiconApi.Services.DTOs;
using LexiconApi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/<AttorneyController>
        [HttpGet]
        public IActionResult GetAllClients()
        {
            try
            {
                return Ok(_clientService.GetAllClients());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // POST api/<AttorneyController>
        [HttpPost]
        public IActionResult AddClient([FromBody] ClientDTO client)
        {
            client.Id = 0;
            if (!string.IsNullOrEmpty(client.Name) && client.Age > 18 && !string.IsNullOrEmpty(client.Email))
            {
                return Ok(_clientService.AddClient(client));
            }
            return BadRequest("You have entered wrong credentials");
        }
    }
}
