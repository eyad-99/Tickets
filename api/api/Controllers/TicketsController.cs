using api.Models.Domain;
using api.Models.DTO;
using api.Repository.impl;
using api.Repository.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly UserManager<User> _userManager;

        public TicketsController(ITicketRepository ticketRepository, UserManager<User> userManager)
        {
            _ticketRepository = ticketRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAllTickets()
        {
            var tickets = await _ticketRepository.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpGet("user-tickets")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetUserTickets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
                var tickets = await _ticketRepository.GetTicketsByUserIdAsync(userId);
                return Ok(tickets);
            

            return BadRequest("Invalid user ID");
        }

        [HttpGet("not-assigned")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsNotAssignedToUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
                var events = await _ticketRepository.GetEventsNotAssignedToUserAsync(userId);
                return Ok(events);
            

            return BadRequest("Invalid user ID");
        }

        [HttpGet("create/{id}")]
        public async Task<ActionResult<Ticket>> CreateTicket(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var ticket = new Ticket
            {
                EventId =id,
                ReserveDate = DateTime.Now,
                User = user
            };

            await _ticketRepository.CreateTicketAsync(ticket);
            //return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
            return Ok(ticket);
        }

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var result = await _ticketRepository.DeleteTicketAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
