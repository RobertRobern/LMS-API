using AspNetIdentityVocationExam.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityVocationExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly VocationDbContext _vocationDbContext;

        public ClassesController(VocationDbContext vocationDbContext)
        {
            _vocationDbContext = vocationDbContext;
        }

        //Classes
        // GET api/Classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classes>>> GetClasses()
        {
            if (_vocationDbContext.Classes == null)
            {
                return NotFound();
            }
            return await _vocationDbContext.Classes.ToListAsync();
        }

        // GET api/Score/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classes>> GetClass(int id)
        {
            if (_vocationDbContext.Classes == null)
            {
                return NotFound();
            }

            var classes = await _vocationDbContext.Classes.FindAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
            return classes;
        }

        // POST api/Score
        [HttpPost]
        public async Task<ActionResult<Classes>> PostClasses(Classes classes)
        {
            _vocationDbContext.Classes.Add(classes);
            await _vocationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClass), new { id = classes.Id }, classes);
        }

        // PUT api/Score/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutClasses(int id, Classes classes)
        {
            if (id != classes.Id)
            {
                return BadRequest();
            }

            _vocationDbContext.Entry(classes).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteClasses(int id)
        {
            if (_vocationDbContext.Classes == null)
            {
                return NotFound();
            }

            var classes = await _vocationDbContext.Classes.FindAsync(id);
            if (classes == null)
            {
                return NotFound();
            }

            _vocationDbContext.Classes.Remove(classes);
            await _vocationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
