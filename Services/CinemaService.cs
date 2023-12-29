// Services/CinemaService.cs
public class CinemaService
{
    private readonly CinemaRepository _repository;

    public CinemaService(CinemaRepository repository)
    {
        _repository = repository;
    }

    public List<Room> GetAllRooms()
    {
        return _repository.GetAllRooms();
    }

    // Implement other business logic methods
}
