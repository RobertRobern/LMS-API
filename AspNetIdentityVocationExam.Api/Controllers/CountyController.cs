using AspNetIdentityVocationExam.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityVocationExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        private readonly VocationDbContext _vocationDbContext;

        public CountyController(VocationDbContext vocationDbContext)
        {
            _vocationDbContext = vocationDbContext;
        }


        //County
        // GET api/County
        [HttpGet]
        public async Task<ActionResult<IEnumerable<County>>> GetCountys()
        {
            if (_vocationDbContext.Counties == null)
            {
                return NotFound();
            }
            return await _vocationDbContext.Counties.ToListAsync();
        }

        // GET api/County/5
        [HttpGet("{id}")]
        public async Task<ActionResult<County>> GetCounty(int id)
        {
            if (_vocationDbContext.Counties == null)
            {
                return NotFound();
            }

            var counties = await _vocationDbContext.Counties.FindAsync(id);
            if (counties == null)
            {
                return NotFound();
            }
            return counties;
        }

        // POST api/County
        [HttpPost]
        public async Task<ActionResult<County>> PostCounty(County county)
        {
            _vocationDbContext.Counties.Add(county);
            await _vocationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCounty), new { id = county.Id }, county);
        }

        // PUT api/County/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCounty(int id, County county)
        {
            if (id != county.Id)
            {
                return BadRequest();
            }

            _vocationDbContext.Entry(county).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteCounty(int id)
        {
            if (_vocationDbContext.Counties == null)
            {
                return NotFound();
            }

            var county = await _vocationDbContext.Counties.FindAsync(id);
            if (county == null)
            {
                return NotFound();
            }

            _vocationDbContext.Counties.Remove(county);
            await _vocationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
