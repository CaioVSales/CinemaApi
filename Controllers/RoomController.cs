using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("{id}")]
    public IActionResult GetRoomById(int id)
    {
        var room = _context.Rooms.Include(r => r.Movies).FirstOrDefault(r => r.RoomId == id);

        if (room == null)
        {
            return NotFound();
        }

        return Ok(room);
    }

    [HttpPost]
    public IActionResult CreateRoom(Room room)
    {
        _context.Rooms.Add(room);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetRoomById), new { id = room.RoomId }, room);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRoom(int id, Room updatedRoom)
    {
        var existingRoom = _context.Rooms.FirstOrDefault(r => r.RoomId == id);

        if (existingRoom == null)
        {
            return NotFound();
        }

        existingRoom.RoomNumber = updatedRoom.RoomNumber;
        existingRoom.Description = updatedRoom.Description;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRoom(int id)
    {
        var roomToDelete = _context.Rooms.FirstOrDefault(r => r.RoomId == id);

        if (roomToDelete == null)
        {
            return NotFound();
        }

        _context.Rooms.Remove(roomToDelete);
        _context.SaveChanges();

        return NoContent();
    }
}
