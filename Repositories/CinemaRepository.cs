using Microsoft.EntityFrameworkCore;

public class CinemaRepository
{
    private readonly ApplicationDbContext _context;

    public CinemaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Room> GetAllRooms()
    {
        var rooms = _context.Rooms.Include(r => r.Movies).ToList();
    
        return rooms ?? new List<Room>();
    }


    public Room? GetRoomById(int roomId)
    {
        var room = _context.Rooms.Include(r => r.Movies).FirstOrDefault(r => r.RoomId == roomId);

        return room;
    }


    public void CreateRoom(Room room)
    {
        _context.Rooms.Add(room);
        _context.SaveChanges();
    }

    public void UpdateRoom(Room updatedRoom)
    {
        var existingRoom = _context.Rooms.FirstOrDefault(r => r.RoomId == updatedRoom.RoomId);

        if (existingRoom != null)
        {
            existingRoom.RoomNumber = updatedRoom.RoomNumber;
            existingRoom.Description = updatedRoom.Description;

            _context.SaveChanges();
        }
    }

    public void DeleteRoom(int roomId)
    {
        var roomToDelete = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);

        if (roomToDelete != null)
        {
            _context.Rooms.Remove(roomToDelete);
            _context.SaveChanges();
        }
    }

    public void CreateMovie(int roomId, Movie movie)
    {
        var room = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);

        if (room != null)
        {
            room.Movies.Add(movie);
            _context.SaveChanges();
        }
    }

    public void UpdateMovie(int roomId, Movie updatedMovie)
    {
        var room = _context.Rooms.Include(r => r.Movies).FirstOrDefault(r => r.RoomId == roomId);

        if (room != null)
        {
            var existingMovie = room.Movies.FirstOrDefault(m => m.MovieId == updatedMovie.MovieId);

            if (existingMovie != null)
            {
                existingMovie.Name = updatedMovie.Name;
                existingMovie.Director = updatedMovie.Director;

                _context.SaveChanges();
            }
        }
    }

    public void DeleteMovie(int roomId, int movieId)
    {
        var room = _context.Rooms.Include(r => r.Movies).FirstOrDefault(r => r.RoomId == roomId);

        if (room != null)
        {
            var movieToDelete = room.Movies.FirstOrDefault(m => m.MovieId == movieId);

            if (movieToDelete != null)
            {
                room.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }
        }
    }
}
