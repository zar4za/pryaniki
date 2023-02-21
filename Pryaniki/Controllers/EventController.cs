using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pryaniki.Models;
using Pryaniki.Services;
using Pryaniki.Utility;

namespace Pryaniki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private static readonly StorageService _storage = new();

        [HttpPost]
        public IActionResult Post(Event action) 
        {
            _storage.AddEvent(action);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var time = DateTime.UtcNow.RoundToMinutes();
            var sum = _storage.Events
                .Where(e => e.DateTime >= time)
                .Sum(e => e.Value);

            return Ok(new
            {
                time = time.ToString("dd.MM.yyyy HH:mm:ss"),
                sum
            });
        }
    }
}
