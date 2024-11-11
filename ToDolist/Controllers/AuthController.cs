using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todolist_Application.Services;
using Todolist_Core.Entities;
using Todolist_Infrastructure.Data;

namespace ToDolist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(ApplicationDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            var user = _context.User.SingleOrDefault(u => u.Name == request.Username && u.Password == request.Password);
            if (user == null) return Unauthorized();

            var token = _jwtService.GenerateToken(user.Id);
            return Ok(new { Token = token });
        }
    }
}
