using APi.Data;
using APi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MembersController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetMembers()
        {
            var members = await _context.Users.ToListAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetMember(int id)
        {
            var member = await _context.Users.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return member;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateMember(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMember), new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _context.Users.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Users.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
