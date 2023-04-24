using LexiconApi.Data.Models;
using LexiconApi.Models;
using LexiconApi.Services.DTOs;
using LexiconApi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttorneyController : ControllerBase
    {

        private readonly IAttorneyService _attorneyService;

        public AttorneyController(IAttorneyService attorneyService)
        {
            _attorneyService = attorneyService;
        }

        // GET: api/<AttorneyController>
        [HttpGet]
        public IActionResult GetAllAttorneys()
        {
            Response response;

            try
            {
                IEnumerable<AttorneyDTO> attorneys = _attorneyService.GetAllAttorneys();
                response = new Response(StatusCodes.Status200OK, "Attorneys retreived successfully", attorneys);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new Response(StatusCodes.Status400BadRequest,"Somethng went wrong"+ex.Message, null);
                return BadRequest(response);
            }
        }


        // POST api/<AttorneyController>
        [HttpPost]
        public IActionResult AddAttorney([FromBody] AttorneyDTO attorney)
        {
            Response response;

            attorney.Id = 0;
            if (!string.IsNullOrEmpty(attorney.Name) && attorney.Age > 18 && !string.IsNullOrEmpty(attorney.Email))
            {
                Attorney newAttorney = _attorneyService.AddAttorney(attorney);
                response = new Response(StatusCodes.Status200OK, "Invoice added successfully", newAttorney);
                return Ok(response);
            }
            response = new Response(StatusCodes.Status400BadRequest, "Somethng went wrong", null);
            return BadRequest(response);
        }

    }
}
