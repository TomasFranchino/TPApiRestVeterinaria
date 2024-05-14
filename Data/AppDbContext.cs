using Microsoft.EntityFrameworkCore;
using WebAppVeterinaria.Models;

namespace WebAppVeterinaria.Data

{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }  
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Dueño> Dueño { get; set; }
        public DbSet<Atencion> Atenciones {  get; set; }  
    }
}
