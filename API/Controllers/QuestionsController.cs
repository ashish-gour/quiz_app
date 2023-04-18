using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService questionService;

        public QuestionsController(IQuestionService _questionService)
        {
            questionService = _questionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var questions = await questionService.GetQuestions();
            return questions is null ? NotFound("No Questions found!") : Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var question = await questionService.GetQuestion(id);
            return question is null ? NotFound("question not found!") : Ok(question);
        }

        [HttpGet("examId/{id}")]
        public async Task<IActionResult> GetByExamId(int id)
        {
            var question = await questionService.GetQuestionsByExamId(id);
            return question is null ? NotFound("question not found!") : Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Question quetion)
        {
            var result = await questionService.AddQuestion(quetion);
            return result ? Ok("Question Added!") : Problem("Problem in adding the question!");
        }

        [HttpPut]
        public async Task<IActionResult> PutExam(Question quetion, int id)
        {
            quetion.Id= id;    
            var result = await questionService.UpdateQuestion(quetion);
            return result ? Ok("Question Updated!") : Problem("Problem in updating the question!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var result = await questionService.DeleteQuestion(id);
            return result ? Ok("Question deleted!") : Problem("Problem in deleting the question!");
        }
    }
}
