using DGFWebApp.Data;
using DGFWebApp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGFWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public EventsController(ApplicationDbContext db) => _db = db;

        [HttpGet("allactiveevents")]
        public IEnumerable<EventViewModel> Get()
        {
            var events = _db.Events.Where(x => x.EventDate > DateTime.Today).Select(e => new EventViewModel()
            {
                EventDate = e.EventDate.ToString("dd-MMM-yyyy hh:mm tt"),
                EventType = e.EventType,
                ID = e.ID,
                Location = e.Location,
                Title = e.Title
            }).ToList();


            return events;
        }
    }
}
