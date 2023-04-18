namespace API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Organization { get; set; }
        public string? Role { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public ICollection<Exam>? Exams { get; set; }
    }
}
