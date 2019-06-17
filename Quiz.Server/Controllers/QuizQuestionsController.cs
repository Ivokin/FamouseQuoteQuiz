using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Server.Constants;
using Quiz.Server.Data;

namespace Quiz.Server.Controllers
{
    [Route(RouteConstants.ApiController)]
    [ApiController]
    public class QuizQuestionsController : ControllerBase
    {
        private readonly QuizContext context;

        public QuizQuestionsController(QuizContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<QuizQuestions> GetQuizQuestionsModel()
        {
            return context.QuizQuestions;
        }

        [HttpGet(RouteConstants.Id)]
        public async Task<IActionResult> GetQuizQuestionsModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quizQuestionsModel = await context.QuizQuestions.FindAsync(id);

            if (quizQuestionsModel == null)
            {
                return NotFound();
            }

            return Ok(quizQuestionsModel);
        }

        [HttpPut(RouteConstants.Id)]
        public async Task<IActionResult> PutQuizQuestionsModel([FromRoute] int id, [FromBody] QuizQuestions quizQuestionsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quizQuestionsModel.Id)
            {
                return BadRequest();
            }

            context.Entry(quizQuestionsModel).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizQuestionsModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostQuizQuestionsModel([FromBody] QuizQuestions quizQuestionsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.QuizQuestions.Add(quizQuestionsModel);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetQuizQuestions", new { id = quizQuestionsModel.Id }, quizQuestionsModel);
        }

        [HttpDelete(RouteConstants.Id)]
        public async Task<IActionResult> DeleteQuizQuestionsModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quizQuestionsModel = await context.QuizQuestions.FindAsync(id);
            if (quizQuestionsModel == null)
            {
                return NotFound();
            }

            context.QuizQuestions.Remove(quizQuestionsModel);
            await context.SaveChangesAsync();

            return Ok(quizQuestionsModel);
        }

        private bool QuizQuestionsModelExists(int id)
        {
            return context.QuizQuestions.Any(e => e.Id == id);
        }
    }
}