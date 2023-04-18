using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService examService;

        public ExamsController(IExamService _examService)
        {
            examService = _examService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExams() 
        {
            var examList = await examService.GetExams();
            return examList is null ? NotFound("No exams found!") : Ok(examList);
        }

        [HttpGet("upcoming-exams")]
        public async Task<IActionResult> GetUpcomingExams()
        {
            var examList = await examService.GetUpcomingExams();
            return examList is null ? NotFound("No exams found!") : Ok(examList);
        }

        [HttpGet("past-exams")]
        public async Task<IActionResult> GetPastExams()
        {
            var examList = await examService.GetPastExams();
            return examList is null ? NotFound("No exams found!") : Ok(examList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExam(int id)
        {
            var exam = await examService.GetExam(id);
            return exam is null ? NotFound("exam not found!") : Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> PostExam(Exam exam)
        {
            var result = await examService.AddExam(exam);
            return result ? Ok("Exam Added!") : Problem("Problem in adding the exam!");
        }

        [HttpPut]
        public async Task<IActionResult> PutExam(Exam exam, int id)
        {
            exam.Id= id;    
            var result = await examService.UpdateExam(exam);
            return result ? Ok("Exam Updated!") : Problem("Problem in updating the exam!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var result = await examService.DeleteExam(id);
            return result ? Ok("Exam deleted!") : Problem("Problem in deleting the exam!");
        }
    }
}
