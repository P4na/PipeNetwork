using dbAPI.Data;
using dbAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dbAPI.Controllers
{

    public class UserData
    {
        public String email { get; set; }
        public String pwd { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class ResponsabileController : ControllerBase
    {

        private GcmaucfjContext _context;

        public ResponsabileController(GcmaucfjContext context)
        {
            _context = context;
        }



        // GET: api/<ResponsabileController>
        [HttpGet]
        public async Task<ActionResult<List<Responsabile>>> Get()
        {
            return Ok(await _context.Responsabiles.ToListAsync());
        }

        // GET api/<ResponsabileController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Responsabile>> Get(long id)
        {
            var User = await _context.Responsabiles.FindAsync(id);
            if (User == null) { return BadRequest("Responsabile not found"); }

            return Ok(User);
        }

        // POST api/<ResponsabileController>
        [HttpPost]
        public async Task<ActionResult<UserData>> Post(Responsabile responsabile)
        {
            _context.Responsabiles.Add(responsabile);
            await _context.SaveChangesAsync();
            return Ok(await _context.Responsabiles.ToListAsync());
        }

        // POST api/<ResponsabileController>
        [HttpPost("login")]
        public async Task<ActionResult<List<Responsabile>>> Login(UserData user)
        {   
            var listUsers = await _context.Responsabiles.ToListAsync();

            for(int i = 0; i < listUsers.Count; i++)
            {
                if(listUsers[i].Email.Equals(user.email))
                {
                    if (listUsers[i].Password.Equals(user.pwd))
                    {
                        return Ok(listUsers[i]);
                    }
                    return BadRequest("Uncorrect password");
                }
            } 
            return  BadRequest("Responsabile not found");
        }

        // PUT api/<ResponsabileController>/5
        [HttpPut]
        public async Task<ActionResult<List<Responsabile>>> Put(Responsabile request)
        {
            var responsabile = await _context.Responsabiles.FindAsync(request.Id);
            if (responsabile == null) { return BadRequest("Responsabile not found"); }

            responsabile.Nome = request.Nome;
            responsabile.Cognome = request.Cognome;
            responsabile.Email = request.Email;
            responsabile.Cellulare = request.Cellulare;
            responsabile.Indirizzo = request.Indirizzo;
            responsabile.Password = request.Password;
            responsabile.Nascita = request.Nascita;


            await _context.SaveChangesAsync();
            return Ok(await _context.Responsabiles.ToListAsync());

        }

        // DELETE api/<ResponsabileController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Responsabile>>> Delete(long id)
        {
            var dbResponsabile = await _context.Responsabiles.FindAsync(id);
            if (dbResponsabile == null)
            {
                return BadRequest("Responsabile not Found");
            }
            _context.Responsabiles.Remove(dbResponsabile);
            await _context.SaveChangesAsync();
            return Ok(await _context.Responsabiles.ToListAsync());
        }
    }
}
