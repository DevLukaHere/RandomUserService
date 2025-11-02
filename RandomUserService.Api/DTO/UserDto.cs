namespace RandomUserService.Api.DTO;

public class UserDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Gender { get; set; } = "";
    public string Email { get; set; } = "";
    public string ExternalId { get; set; } = "";
    public DateTime Timestamp { get; set; }
}