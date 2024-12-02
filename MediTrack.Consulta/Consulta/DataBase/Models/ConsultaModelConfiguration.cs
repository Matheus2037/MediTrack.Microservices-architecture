using System.Data.Entity.ModelConfiguration;

namespace Consulta.DataBase.Models
{
    public class ConsultaModelConfiguration : EntityTypeConfiguration<Domain.Consulta.Consulta>
    {
        public ConsultaModelConfiguration()
        {
            ToTable("Consulta");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired()
                .HasColumnType("varchar(max)")
                .HasColumnName("ID");
            
            Property(x => x.IdDoutor)
                .IsRequired()
                .HasColumnType("INTEGER")
                .HasColumnName("ID_DUTOR");
            
            Property(x => x.IdClient)
                .IsRequired()
                .HasColumnType("INTEGER")
                .HasColumnName("ID_CLINTE");
            
            Property(x => x.Descricao)
                .IsOptional()
                .HasColumnType("TEXT")
                .HasColumnName("DESCRICAO");
            
            Property(x => x.Data)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasColumnName("DATA_CONSULTA");
            
            Property(x => x.Lembrar)
                .IsRequired()
                .HasColumnType("BIT")
                .HasColumnName("LEMBRAR");
            
            Property(x => x.DataAgendamento)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasColumnName("DATA_AGENDAMENTO");
            
            Property(x => x.MeioAgendamento)
                .IsRequired()
                .HasColumnType("INTEGER")
                .HasColumnName("MEIO_AGENDAMENTO");
        }
    }
}
