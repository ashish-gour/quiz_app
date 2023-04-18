using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly DataContext context;

        public QuestionService(DataContext _context)
        {
            context = _context;
        }

        public async Task<bool> AddQuestion(Question question)
        {
            var result = false;
            try
            {
                if (question is not null)
                {
                    await context.Questions!.AddAsync(question);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            var result = false;
            try
            {
                var delete = await context.Questions!.FirstOrDefaultAsync(q => q.Id == id);
                if (delete is not null)
                {
                    context.Questions!.Remove(delete);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<Question> GetQuestion(int id)
        {
            var question = new Question();
            try
            {
                question = await context.Questions!.Include(q => q.Options).Include(q => q.Exam).FirstOrDefaultAsync(q => q.Id == id);
            }
            catch (Exception)
            {
                question = null!;
            }
            return question!;
        }

        public async Task<List<Question>> GetQuestions()
        {
            var questions = new List<Question>();
            try
            {
                questions = await context.Questions!.Include(q => q.Options).ToListAsync();
            }
            catch (Exception)
            {
                questions = null!;
            }
            return questions!;
        }

        public async Task<List<Question>> GetQuestionsByExamId(int examId)
        {
            var questions = new List<Question>();
            try
            {
                questions = await context.Questions!.Include(q => q.Options).Where(q => q.ExamId == examId).ToListAsync();
            }
            catch (Exception)
            {
                questions = null!;
            }
            return questions!;
        }

        public async Task<bool> UpdateQuestion(Question question)
        {
            var result = false;
            try
            {
                var update = await context.Questions!.FirstOrDefaultAsync(q => q.Id == question.Id);
                if (update is not null)
                {
                    update.QuestionValue = question.QuestionValue;
                    update.Marks = question.Marks;
                    update.QuestionType = question.QuestionType;
                    await context.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
