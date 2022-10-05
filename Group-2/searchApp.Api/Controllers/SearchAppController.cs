using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using searchApp.Service;

namespace searchApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAppController : ControllerBase
    {
        private readonly ISearchService _service;

        public SearchAppController(ISearchService service)
        {
            _service = service;
        }

        [HttpGet("{text}")]
        public async Task<IActionResult> GetSearch(string text)
        {
            var result = await _service.GetSearch(text);
            if (result == null)
                return NotFound();
            return Ok(result);

        }
    }
}
