using AspNetIdentityVocationExam.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityVocationExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly VocationDbContext _vocationDbContext;

        public GenderController(VocationDbContext vocationDbContext)
        {
            _vocationDbContext = vocationDbContext;
        }

        //Genders
        // GET api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genders>>> GetGenders()
        {
            if (_vocationDbContext.Genders == null)
            {
                return NotFound();
            }
            return await _vocationDbContext.Genders.ToListAsync();
        }

        // GET api/Genders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genders>> GetGender(int id)
        {
            if (_vocationDbContext.Genders == null)
            {
                return NotFound();
            }

            var gender = await _vocationDbContext.Genders.FindAsync(id);
            if (gender == null)
            {
                return NotFound();
            }
            return gender;
        }

        // POST api/Genders
        [HttpPost]
        public async Task<ActionResult<County>> PostGender(Genders gender)
        {
            _vocationDbContext.Genders.Add(gender);
            await _vocationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGender), new { id = gender.Id }, gender);
        }

        // PUT api/Genders/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutGender(int id, Genders gender)
        {
            if (id != gender.Id)
            {
                return BadRequest();
            }

            _vocationDbContext.Entry(gender).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteGender(int id)
        {
            if (_vocationDbContext.Genders == null)
            {
                return NotFound();
            }

            var gender = await _vocationDbContext.Genders.FindAsync(id);
            if (gender == null)
            {
                return NotFound();
            }

            _vocationDbContext.Genders.Remove(gender);
            await _vocationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
