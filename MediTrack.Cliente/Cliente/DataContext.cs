using Cliente.Servicos;
using Microsoft.EntityFrameworkCore;

namespace MediTrack
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
    }
}