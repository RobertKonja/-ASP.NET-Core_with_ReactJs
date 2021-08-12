using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InterviewTask.Models;

namespace InterviewTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly TestIntervueContext _context;

        public DictionaryController(TestIntervueContext context)
        {
            _context = context;
        }

        // GET: api/Dictionaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dictionary>>> GetDictionary()
        {
            return await _context.Dictionary.ToListAsync();
        }

        // GET: api/Dictionaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dictionary>> GetDictionary(int id)
        {
            var dictionary = await _context.Dictionary.FindAsync(id);

            if (dictionary == null)
            {
                return NotFound();
            }

            return dictionary;
        }
        // GET: api/Dictionaries/word/E-mail
        [HttpGet("word/{word}")]
        public async Task<ActionResult<Dictionary>> GetByWord(string word)
        {
           
           

            var myEncodedString = System.Net.WebUtility.UrlDecode(word);

          
            var dictionary = await _context.Dictionary.Where(o => o.English.Equals(myEncodedString)).FirstOrDefaultAsync<Dictionary>();
            
            if (dictionary == null)
            {
                return NotFound();
            }


            return dictionary;
        }
        // PUT: api/Dictionaries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDictionary(int id, Dictionary dictionary)
        {
            if (id != dictionary.Id)
            {
                return BadRequest();
            }

            _context.Entry(dictionary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DictionaryExists(id))
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

        // POST: api/Dictionaries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dictionary>> PostDictionary(Dictionary dictionary)
        {
            _context.Dictionary.Add(dictionary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DictionaryExists(dictionary.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDictionary", new { id = dictionary.Id }, dictionary);
        }

        // DELETE: api/Dictionaries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dictionary>> DeleteDictionary(int id)
        {
            var dictionary = await _context.Dictionary.FindAsync(id);
            if (dictionary == null)
            {
                return NotFound();
            }

            _context.Dictionary.Remove(dictionary);
            await _context.SaveChangesAsync();

            return dictionary;
        }

        private bool DictionaryExists(int id)
        {
            return _context.Dictionary.Any(e => e.Id == id);
        }
    }
}
