using LexiconApi.Data.Models;
using LexiconApi.Models;
using LexiconApi.Services.DTOs;
using LexiconApi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace LexiconApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JurisdictionController : ControllerBase
    {
        private readonly IJurisdictionService _jurisdictionService;
        public JurisdictionController(IJurisdictionService jurisdictionService)
        {
            _jurisdictionService = jurisdictionService;
        }

        // GET: api/<JurisdictionController>
        [HttpGet]
        public IActionResult GetAllJurisdictions()
        {
            Response response;
            try
            {
                response = new Response(StatusCodes.Status200OK, "Jurisdictions retreived successfully", _jurisdictionService.GetAllJurisdictions());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<JurisdictionController>
        [HttpPost]
        public IActionResult AddJurisdiction([FromBody] JurisdictionDTO jurisdiction)
        {
            Response response;

            jurisdiction.Id = 0;
            if (!string.IsNullOrEmpty(jurisdiction.Area))
            {
                Jurisdiction newJurisdiction = _jurisdictionService.AddJurisdiction(jurisdiction);
                response = new Response(StatusCodes.Status200OK, "Jurisdiction added successfully", newJurisdiction);
                return Ok(response);
            }
            response = new Response(StatusCodes.Status400BadRequest, "Somethng went wrong", null);
            return BadRequest(response);
        }
    }
}
