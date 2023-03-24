using Microsoft.EntityFrameworkCore;

namespace Sithec2023.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>().HasKey(a => a.Id);
        }

        public DbSet<Alumno> Alumnos { get; set; }
    }
}
