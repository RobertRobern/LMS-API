using AspNetIdentityVocationExam.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityVocationExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly VocationDbContext _vocationDbContext;

        public SubjectsController(VocationDbContext vocationDbContext)
        {
            _vocationDbContext = vocationDbContext;
        }

        //Subjects
        // GET api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subjects>>> GetSubjects()
        {
            if (_vocationDbContext.Subjects == null)
            {
                return NotFound();
            }
            return await _vocationDbContext.Subjects.ToListAsync();
        }

        // GET api/Score/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subjects>> GetSubject(int id)
        {
            if (_vocationDbContext.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _vocationDbContext.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return subject;
        }

        // POST api/Score
        [HttpPost]
        public async Task<ActionResult<Subjects>> PostSubject(Subjects subject)
        {
            _vocationDbContext.Subjects.Add(subject);
            await _vocationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubject), new { id = subject.Id }, subject);
        }

        // PUT api/Score/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutSubject(int id, Subjects subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            _vocationDbContext.Entry(subject).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteSubject(int id)
        {
            if (_vocationDbContext.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _vocationDbContext.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _vocationDbContext.Subjects.Remove(subject);
            await _vocationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
