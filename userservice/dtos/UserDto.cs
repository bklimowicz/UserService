namespace userservice.dtos
{
    public class UserDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime Birthday { get; set; }
        public string? PhoneNumber { get; set; }
    }
}