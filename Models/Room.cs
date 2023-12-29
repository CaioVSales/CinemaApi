public class Room
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; }
    public string Description { get; set; }
    public List<Movie> Movies { get; set; }

    public Room()
    {
        RoomNumber = string.Empty;
        Description = string.Empty;
        Movies = new List<Movie>();
    }
}
