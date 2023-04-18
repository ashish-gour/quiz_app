namespace API.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public string? ExamName { get; set; }
        public bool isGiven { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<Question>? Questions { get; set; }
    }
}
