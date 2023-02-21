using Microsoft.AspNetCore.Mvc;
using Pryaniki.Data;
using Pryaniki.Models;
using Pryaniki.Utility;

namespace Pryaniki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventStorage _storage;

        public EventController(IEventStorage storage)
        {
            _storage = storage;
        }

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
            var sum = _storage.GetEvents(time)
                .Sum(e => e.Value);

            return Ok(new
            {
                time = time.ToString("dd.MM.yyyy HH:mm:ss"),
                sum
            });
        }
    }
}
