using AspNetIdentityVocationExam.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityVocationExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly VocationDbContext _vocationDbContext;

        public QuestionController(VocationDbContext vocationDbContext)
        {
            _vocationDbContext = vocationDbContext;
        }

        //Questions
        // GET api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questions>>> GetQuestions()
        {
            if (_vocationDbContext.Questions == null)
            {
                return NotFound();
            }
            return await _vocationDbContext.Questions.ToListAsync();
        }

        // GET api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Questions>> GetQuestion(int id)
        {
            if (_vocationDbContext.Questions == null)
            {
                return NotFound();
            }

            var question = await _vocationDbContext.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return question;
        }

        // POST api/Questions
        [HttpPost]
        public async Task<ActionResult<Questions>> PostQuestion(Questions question)
        {
            _vocationDbContext.Questions.Add(question);
            await _vocationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
        }

        // PUT api/Questions/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutQuestion(int id, Questions question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            _vocationDbContext.Entry(question).State = EntityState.Modified;
            try
            {
                await _vocationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();

        }

        // DELETE api/County/5
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteQuestion(int id)
        {
            if (_vocationDbContext.Questions == null)
            {
                return NotFound();
            }

            var question = await _vocationDbContext.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _vocationDbContext.Questions.Remove(question);
            await _vocationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
