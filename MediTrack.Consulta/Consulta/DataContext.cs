using Microsoft.EntityFrameworkCore;

namespace Consulta.DataBase.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<MovimentacaoCaixa> MovimentacoesCaixa { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovimentacaoCaixa>().HasKey(p => p.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
