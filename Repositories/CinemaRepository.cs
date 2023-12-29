using Microsoft.EntityFrameworkCore;  // Add this using directive

public class CinemaRepository
{
    private readonly ApplicationDbContext _context;

    public CinemaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Room> GetAllRooms()
    {
        return _context.Rooms.Include(r => r.Movies).ToList();
    }

    // Implement other CRUD operations for Room and Movie
}
