namespace API.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
        public int Marks { get; set; }
        public string? Status { get; set; }
        public Exam? Exam { get; set; }
        public User? User { get; set; }

    }
}
