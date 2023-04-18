using API.Entities;

namespace API.Interfaces
{
    public interface IExamService
    {
        Task<List<Exam>> GetExams();
        Task<List<Exam>> GetUpcomingExams();
        Task<List<Exam>> GetPastExams();
        Task<Exam> GetExam(int id);
        Task<bool> DeleteExam(int id);
        Task<bool> AddExam(Exam exam);
        Task<bool> UpdateExam(Exam exam);
    }
}
