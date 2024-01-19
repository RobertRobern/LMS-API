using AspNetIdentityVocationExam.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityVocationExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly VocationDbContext _vocationDbContext;

        public ExamsController(VocationDbContext vocationDbContext)
        {
            _vocationDbContext = vocationDbContext;
        }

        //Exams
        // GET api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exams>>> GetExams()
        {
            if (_vocationDbContext.Exams == null)
            {
                return NotFound();
            }
            return await _vocationDbContext.Exams.ToListAsync();
        }

        // GET api/Score/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exams>> GetExam(int id)
        {
            if (_vocationDbContext.Exams == null)
            {
                return NotFound();
            }

            var exam = await _vocationDbContext.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return exam;
        }

        // POST api/Score
        [HttpPost]
        public async Task<ActionResult<Exams>> PostExam(Exams exam)
        {
            _vocationDbContext.Exams.Add(exam);
            await _vocationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExam), new { id = exam.Id }, exam);
        }

        // PUT api/Score/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutExam(int id, Exams exam)
        {
            if (id != exam.Id)
            {
                return BadRequest();
            }

            _vocationDbContext.Entry(exam).State = EntityState.Modified;
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

        // DELETE api/Score/5
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteExam(int id)
        {
            if (_vocationDbContext.Exams == null)
            {
                return NotFound();
            }

            var exam = await _vocationDbContext.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _vocationDbContext.Exams.Remove(exam);
            await _vocationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
