using api.Models.Domain;
using api.Models.DTO;
using api.Repository.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace api.Controllers
{
    [Authorize(Roles = "admin")]

    [Route("api/[controller]")]
    [ApiController]

    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly UserManager<User> _userManager;


        public EventsController(IEventRepository eventRepository ,UserManager<User> userManager)
        {
            _eventRepository = eventRepository;
            _userManager = userManager;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            var events = await _eventRepository.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var eventObj = await _eventRepository.GetEventByIdAsync(id);
            if (eventObj == null)
            {
                return NotFound();
            }
            return Ok(eventObj);
        }

        [HttpPost]

        public async Task<ActionResult<Event>> CreateEvent(EventCreateDto eventDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);


            var eventObj = new Event
            {
                Name = eventDto.Name,
                Description = eventDto.Description,
                Date = eventDto.Date,
                NumberOfTickets = eventDto.NumberOfTickets,
                RemainTickets = eventDto.NumberOfTickets,
                Price = eventDto.Price,
                User=user,
            };

            await _eventRepository.CreateEventAsync(eventObj);
            return eventObj;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> UpdateEvent( EventUpdateDto eventDto)
        {
            //    if (id != eventDto.Id)
            //    {
            //        return BadRequest();
            //    }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var eventObj = new Event
            {
                Id = eventDto.Id,
                Name = eventDto.Name,
                Description = eventDto.Description,
                Date = eventDto.Date,
                NumberOfTickets = eventDto.NumberOfTickets,
                RemainTickets = eventDto.NumberOfTickets, // You may want to handle this differently
                Price = eventDto.Price,
                User=user
            };

            try
            {
                await _eventRepository.UpdateEventAsync(eventObj);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (await _eventRepository.GetEventByIdAsync(id) == null)
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> DeleteEvent(int id)
        {
            var result = await _eventRepository.DeleteEventAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
