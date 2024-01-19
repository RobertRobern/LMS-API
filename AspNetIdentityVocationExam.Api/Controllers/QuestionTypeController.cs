using AspNetIdentityVocationExam.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityVocationExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        private readonly VocationDbContext _vocationDbContext;

        public QuestionTypeController(VocationDbContext vocationDbContext)
        {
            _vocationDbContext = vocationDbContext;
        }


        // QuestionTypes
        // GET api/QuestionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionTypes>>> GetQuestionTypes()
        {
            if (_vocationDbContext.QuestionTypes == null)
            {
                return NotFound();
            }
            return await _vocationDbContext.QuestionTypes.ToListAsync();
        }

        // GET api/QuestionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionTypes>> GetQuestionType(int id)
        {
            if (_vocationDbContext.QuestionTypes == null)
            {
                return NotFound();
            }

            var questionType = await _vocationDbContext.QuestionTypes.FindAsync(id);
            if (questionType == null)
            {
                return NotFound();
            }
            return questionType;
        }

        // POST api/QuestionTypes
        [HttpPost]
        public async Task<ActionResult<QuestionTypes>> PostQuestionType(QuestionTypes questionType)
        {
            _vocationDbContext.QuestionTypes.Add(questionType);
            await _vocationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestionType), new { id = questionType.Id }, questionType);
        }

        // PUT api/QuestionTypes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutQuestionType(int id, QuestionTypes questionType)
        {
            if (id != questionType.Id)
            {
                return BadRequest();
            }

            _vocationDbContext.Entry(questionType).State = EntityState.Modified;
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

        // DELETE api/QuestionTypes/5
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteQuestionType(int id)
        {
            if (_vocationDbContext.QuestionTypes == null)
            {
                return NotFound();
            }

            var questionType = await _vocationDbContext.QuestionTypes.FindAsync(id);
            if (questionType == null)
            {
                return NotFound();
            }

            _vocationDbContext.QuestionTypes.Remove(questionType);
            await _vocationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
