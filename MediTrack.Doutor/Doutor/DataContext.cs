using Doutor.Servicos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MediTrack
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<DoutorModel> Doutor { get; set; }
    }
}