using Microsoft.AspNetCore.Mvc;
using Moq;
using Pryaniki.Controllers;
using Pryaniki.Data;
using Pryaniki.Models;
using Pryaniki.Utility;
using System.Text.Json;

namespace Pryaniki.Tests.Controllers
{
    public class EventControllerTests
    {
        [Fact]
        public void Post_ValidEvent_ShouldStore()
        {
            var action = new Event()
            {
                Name = "test",
                Value = 10
            };

            var mockStorage = new Mock<IEventStorage>();
            mockStorage
                .Setup(x => x.AddEvent(It.IsAny<Event>()));

            var controller = new EventController(mockStorage.Object);


            controller.Post(action);
            

            mockStorage.Verify(x => x.AddEvent(action));
        }

        [Fact]
        public void Get_HasEvents_ShouldReturnSame()
        {
            IEnumerable<Event> events = new List<Event>()
            {
                new Event() { Id = 1, Name = "test", Value = 10, DateTime = DateTime.UtcNow },
                new Event() { Id = 1, Name = "test2", Value = 12, DateTime = DateTime.UtcNow },
            };

            var mockStorage = new Mock<IEventStorage>();
            mockStorage
                .Setup(x => x.GetEvents(It.IsAny<DateTime>()))
                .Returns(events);

            var expectedTimeString = DateTime.UtcNow.RoundToMinutes().ToString("dd.MM.yyyy HH:mm:ss");
            var expectedSum = 22;
            var expected = new
            {
                time = expectedTimeString,
                sum = expectedSum
            };

            var controller = new EventController(mockStorage.Object);

            
            var result = controller.Get();


            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(((OkObjectResult)result).Value));
        }
    }
}
