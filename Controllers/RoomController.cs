using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RoomController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllRooms()
    {
        var rooms = _context.Rooms.Include(r => r.Movies).ToList();
        return Ok(rooms);
    }

    // Implement other CRUD actions
}
