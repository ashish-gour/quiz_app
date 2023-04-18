using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ExamService : IExamService
    {
        private readonly DataContext context;

        public ExamService(DataContext _context)
        {
            context = _context;
        }

        public async Task<bool> AddExam(Exam exam)
        {
            var result = false;
            try
            {
                if (exam is not null)
                {
                    await context.Exams!.AddAsync(exam);
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

        public async Task<bool> DeleteExam(int id)
        {
            var result = false;
            try
            {
                var deleteExam = await context.Exams!.FirstOrDefaultAsync(u => u.Id == id);
                if (deleteExam is not null)
                {
                    context.Exams!.Remove(deleteExam);
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

        public async Task<Exam> GetExam(int id)
        {
            var exam = new Exam();
            try
            {
                exam = await context.Exams!.Include(e => e.Questions).FirstOrDefaultAsync(exam => exam.Id == id);
            }
            catch (Exception)
            {
                exam = null!;
            }
            return exam!;
        }

        public async Task<List<Exam>> GetExams()
        {
            var exams = new List<Exam>();
            try
            {
                exams = await context.Exams!.Include(e => e.Questions).ToListAsync();
            }
            catch (Exception)
            {
                exams = null!;
            }
            return exams!;
        }

        public async Task<bool> UpdateExam(Exam exam)
        {
            var result = false;
            try
            {
                var examToUdate = await context.Exams!.FirstOrDefaultAsync(e => e.Id == exam.Id);
                if (examToUdate is not null)
                {
                    examToUdate.ExamName = exam.ExamName;
                    examToUdate.isGiven = exam.isGiven;
                    examToUdate.StartDateTime = exam.StartDateTime;
                    examToUdate.EndDateTime = exam.EndDateTime;
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

        public async Task<List<Exam>> GetUpcomingExams()
        {
            var exams = new List<Exam>();
            try
            {
                exams = await context.Exams!.Include(e => e.Questions).Where(exam => !exam.isGiven).ToListAsync();
            }
            catch (Exception)
            {
                exams = null!;
            }
            return exams!;
        }

        public async Task<List<Exam>> GetPastExams()
        {
            var exams = new List<Exam>();
            try
            {
                exams = await context.Exams!.Include(e => e.Questions).Where(exam => exam.isGiven).ToListAsync();
            }
            catch (Exception)
            {
                exams = null!;
            }
            return exams!;
        }
    }
}
