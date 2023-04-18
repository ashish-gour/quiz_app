namespace API.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string? QuestionValue { get; set; }
        public string? QuestionType { get; set; }
        public int Marks { get; set; }
        public Exam? Exam { get; set; }
        public ICollection<Option>? Options { get; set; }
    }
}