using API.Entities;

namespace API.Interfaces
{
    public interface IQuestionService
    {
        Task<Question> GetQuestion(int id);
        Task<List<Question>> GetQuestions();
        Task<List<Question>> GetQuestionsByExamId(int examId);
        Task<bool> AddQuestion(Question question);
        Task<bool> UpdateQuestion(Question question);
        Task<bool> DeleteQuestion(int id);
    }
}
