namespace API.Dto
{
    public class UserDto
    {
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Organization { get; set; }
        public string? Role { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Token { get; set; }
    }
}
