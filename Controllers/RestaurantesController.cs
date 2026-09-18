using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjemploDeApi.Data;
using EjemploDeApi.Models;

namespace EjemploDeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly RestaurantesDbContext _context;

        public RestaurantesController(RestaurantesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Restaurante>> GetRestaurante(int id)
        {
            var restaurante = await _context.Restaurantes.FindAsync(id); 
            if (restaurante == null) 
            { 
                return NotFound(); 
            } 

            return restaurante;
        }


        [HttpPost] 
        public async Task<ActionResult<Restaurante>> PostRestaurante(Restaurante restaurante) 
        { 
            _context.Restaurantes.Add(restaurante); 
            await _context.SaveChangesAsync(); 
            
            return CreatedAtAction( 
                nameof(GetRestaurante), 
                new { id = restaurante.Id }, 
                restaurante 
            ); 
        }


        [HttpPut("{id}")] 
        public async Task<IActionResult> PutRestaurante( 
            int id, 
            Restaurante restaurante) 
        { 
            if (id != restaurante.Id) 
            { 
                return BadRequest(); 
            } 
            _context.Entry(restaurante).State = EntityState.Modified; 
            
            try 
            { 
                await _context.SaveChangesAsync(); 
            } 
            catch (DbUpdateConcurrencyException) 
            { 
                if (!RestauranteExists(id)) 
                { 
                    return NotFound(); 
                } 
                throw;
            } 
            
            return NoContent(); 
        }
        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteRestaurante(int id) 
        { 
            var restaurante = await _context.Restaurantes.FindAsync(id); 
            if (restaurante == null) 
            { 
                return NotFound(); 
            } 
            _context.Restaurantes.Remove(restaurante); 
            await _context.SaveChangesAsync(); 

            return NoContent(); 
        } 
        
        private bool RestauranteExists(int id) 
        { 
            return _context.Restaurantes.Any(e => e.Id == id); 
        }
    }
        
}