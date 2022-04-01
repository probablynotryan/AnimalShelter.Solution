using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterApiContext: DbContext
  {
    public DbSet<Animal> Animals {get; set;}

    public AnimalShelterApiContext(DbContextOptions<AnimalShelterApiContext> options)
      : base(options)
      {
      }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>();
    }
  }
}