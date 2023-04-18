namespace API.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string? OptionValue { get; set; }
        public bool IsAnswer { get; set; }
        public Question? Question { get; set;}
    }
}
