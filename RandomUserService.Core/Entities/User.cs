namespace RandomUserService.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ExternalId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
