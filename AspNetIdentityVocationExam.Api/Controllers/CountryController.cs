using AspNetIdentityVocationExam.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityVocationExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly VocationDbContext _vocationDbContext;

        public CountryController(VocationDbContext vocationDbContext)
        {
            _vocationDbContext = vocationDbContext;

        }

        // Country
        // GET api/Countrys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountrys()
        {
            if (_vocationDbContext.Countries == null)
            {
                return NotFound();
            }
            return await _vocationDbContext.Countries.ToListAsync();
        }

        // GET api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            if (_vocationDbContext.Countries == null)
            {
                return NotFound();
            }

            var countries = await _vocationDbContext.Countries.FindAsync(id);
            if (countries == null)
            {
                return NotFound();
            }
            return countries;
        }

        // POST api/Country
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _vocationDbContext.Countries.Add(country);
            await _vocationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }

        // PUT api/Country/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _vocationDbContext.Entry(country).State = EntityState.Modified;
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

        // DELETE api/Country/5
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteCountry(int id)
        {
            if (_vocationDbContext.Countries == null)
            {
                return NotFound();
            }

            var country = await _vocationDbContext.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _vocationDbContext.Countries.Remove(country);
            await _vocationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
