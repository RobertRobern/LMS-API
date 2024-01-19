using AspNetIdentityVocationExam.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityVocationExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {

        private readonly VocationDbContext _vocationDbContext;

        public ScoresController(VocationDbContext vocationDbContext)
        {
            _vocationDbContext = vocationDbContext;
            
        }


        //Scores
        // GET api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scores>>> GetScores()
        {
            if (_vocationDbContext.Scores == null)
            {
                return NotFound();
            }
            return await _vocationDbContext.Scores.ToListAsync();
        }

        // GET api/Score/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scores>> GetScore(int id)
        {
            if (_vocationDbContext.Scores == null)
            {
                return NotFound();
            }

            var score = await _vocationDbContext.Scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            return score;
        }

        // POST api/Score
        [HttpPost]
        public async Task<ActionResult<Scores>> PostScore(Scores score)
        {
            _vocationDbContext.Scores.Add(score);
            await _vocationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetScore), new { id = score.Id }, score);
        }

        // PUT api/Score/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutScore(int id, Scores score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }

            _vocationDbContext.Entry(score).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteScore(int id)
        {
            if (_vocationDbContext.Scores == null)
            {
                return NotFound();
            }

            var score = await _vocationDbContext.Scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }

            _vocationDbContext.Scores.Remove(score);
            await _vocationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
