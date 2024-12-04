using Microsoft.EntityFrameworkCore;

namespace Consulta.DataBase.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<Domain.Consulta.Consulta> Consultas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Consulta.Consulta>().HasKey(p => p.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
