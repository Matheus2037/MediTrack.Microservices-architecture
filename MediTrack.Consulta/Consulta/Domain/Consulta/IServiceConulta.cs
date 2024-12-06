namespace Consulta.Domain.Consulta
{
    public interface IServiceConulta
    {
        Task Inserir(Consulta consulta);
        Task Editar(Consulta consulta);
        Task Deletar(Guid idConsulta);
        Task<IQueryable<Consulta>> GetAll();
        Task<IQueryable<Consulta>> GetById(Guid idConsulta);
    }
}
