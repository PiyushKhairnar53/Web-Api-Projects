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

        // GET: api/<AttorneyController>
        [HttpGet]
        public IActionResult GetAllJurisdictions()
        {
            try
            {
                return Ok(_jurisdictionService.GetAllJurisdictions());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
