using AnimalShelterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
    public class AnimalsController : ControllerBase
    {
      private AnimalShelterApiContext _db;

      public AnimalsController(AnimalShelterApiContext db)
      {
        _db = db;
      }

      private bool AnimalExists(int id)
      {
        return _db.Animals.Any(e => e.AnimalId == id);
      }

      [HttpGet]
      public async Task<List<Animal>> Get(string species, int age, string name, string description)
      {
        IQueryable<Animal> query = _db.Animals.AsQueryable();

        if (species != null)
        {
            query = query.Where(entry => entry.Species == species);
        }

        if (name != null)
        {
            query = query.Where(entry => entry.Name == name);
        }

        if (description != null)
        {
            query = query.Where(entry => entry.Description == description);
        }

            return await query.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
          var animal = await _db.Animals.FindAsync(id);

          if (animal == null)
          {
            return NotFound();
          }

          return animal;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Animal animal)
        {
          if (id != animal.AnimalId)
          {
            return BadRequest();
          }

          _db.Entry(animal).State = EntityState.Modified;

          try
          {
            await _db.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!AnimalExists(id))
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
    }
}