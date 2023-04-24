
using LexiconApi.Data.Models;
using LexiconApi.Models;
using LexiconApi.Services.DTOs;
using LexiconApi.Services.Mappers;
using LexiconApi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatterController : ControllerBase
    {
        private readonly IMatterService _matterService;

        public MatterController(IMatterService matterService)
        {
            _matterService = matterService;
        }

        // GET: api/<AttorneyController>
        [HttpGet]
        public IActionResult GetAllMatters()
        {
            try
            {
                IEnumerable<IGrouping<int, Matter>> matters = _matterService.GetAllMatters();
                Response response = new Response(StatusCodes.Status200OK, "Matters retreived successfully", matters);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // POST api/<AttorneyController>
        [HttpPost]
        public IActionResult AddMatter([FromBody] MatterDTO matter)
        {
            matter.Id = 0;
            if (!string.IsNullOrEmpty(matter.Title) && matter.JurisdictionId > 0 && matter.ClientId > 0)
            {
                Matter newMatter = _matterService.AddMatter(matter);
                if (newMatter != null)
                {
                    Response response = new Response(StatusCodes.Status200OK, "Matter added successfully", newMatter);
                    return Ok(response);
                }
                else
                {
                    Response response = new Response(StatusCodes.Status400BadRequest, "Invalid jurisdictionId enetered", newMatter);
                    return BadRequest(response);
                }
            }
            return BadRequest("You have entered wrong credentials");
        }

        [HttpGet("{id}")]
        public IActionResult GetMatterForClient(int id)
        {
            Response response;
            try
            {
                IEnumerable<MatterDTO> matters = _matterService.GetMattersForClient(id);

                if (matters.Any())
                {
                    response = new Response(StatusCodes.Status200OK, "Matters for client retreived successfully", matters);
                    return Ok(response);
                }
                response = new Response(StatusCodes.Status200OK, "This client has no matters", null);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                response = new Response(StatusCodes.Status200OK, "Something went wrong" + ex.Message, null);
                return BadRequest(response);
            }
        }

    }
}
