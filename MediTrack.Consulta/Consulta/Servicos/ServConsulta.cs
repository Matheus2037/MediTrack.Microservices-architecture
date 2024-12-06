using Consulta.DataBase.EF;
using Consulta.Domain.Consulta;
using Consulta.DTO;
using Hangfire;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Consulta.Servicos
{
    public class ServConsulta : IServiceConulta
    {
        private readonly DataContext _context;
        
        private static HttpClient _doutorClient = new()
        {
            BaseAddress = new Uri("https://localhost:7192"),
        };
        
        private static HttpClient _clinteClient = new()
        {
            BaseAddress = new Uri("https://localhost:7184"),
        };
        
        public ServConsulta(DataContext context) { 
            _context = context; 
        }

        public async Task Deletar(Guid idConsulta)
        {
            var c = _context.Consultas.FirstOrDefault(f => f.Id == idConsulta);
            if (c == null) return;

            BackgroundJob.Delete(idConsulta.ToString());
            _context.Consultas.Remove(c);
        }

        public async Task Editar(Domain.Consulta.Consulta consulta)
        {

            var c = _context.Consultas.FirstOrDefault(f => f.Id == consulta.Id);
            if (c == null) throw new Exception("Não existe registro da consulta solicitada!");

            await ValidarInformacoes(consulta.Data, consulta.IdDoutor, consulta.IdClient);
            consulta.Id = Guid.NewGuid();

            BackgroundJob.Schedule(
                () => LembrarCliente(consulta.IdClient, consulta.Data),
                (consulta.Data - DateTime.Now) - TimeSpan.FromDays(1));

            c.Data = consulta.Data;
            c.IdDoutor = consulta.IdDoutor;
            c.IdClient = consulta.IdClient;
            c.DataAgendamento = DateTime.Now;
            c.Descricao = consulta.Descricao;
            c.Lembrar = consulta.Lembrar;
            c.MeioAgendamento = consulta.MeioAgendamento;

            _context.SaveChanges();
        }

        public async Task<IQueryable<Domain.Consulta.Consulta>> GetAll()
        {
            return _context.Consultas;
        }

        public async Task<IQueryable<Domain.Consulta.Consulta>> GetById(Guid idConsulta)
        {
            return _context.Consultas.Where(w => w.Id == idConsulta);
        }

        public async Task Inserir(Domain.Consulta.Consulta consulta)
        {
            await ValidarInformacoes(consulta.Data, consulta.IdDoutor, consulta.IdClient);
            consulta.Id = Guid.NewGuid();

            BackgroundJob.Schedule(
                () => LembrarCliente(consulta.IdClient, consulta.Data),
                (consulta.Data - DateTime.Now) - TimeSpan.FromDays(1));

            await _context.Consultas.AddAsync(consulta);
            _context.SaveChanges();
        }

        public async Task LembrarCliente(int idCliente, DateTime data)
        {
            using HttpResponseMessage clienteResponse = await _doutorClient.GetAsync($"api/Cliente/{idCliente}");
            clienteResponse.EnsureSuccessStatusCode();
            var cliente = JsonConvert.DeserializeObject<ClienteDTO>(await clienteResponse.Content.ReadAsStringAsync());
            var msg = $"Sr.(a) {cliente.Nome}, lembre-se da sua consulta amanhã as {data.ToShortTimeString()}!";
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        private async Task ValidarInformacoes(DateTime DataConsulta, int idDoutor, int idCliente)
        {
            if (_context.Consultas.Any(a => a.Data == DataConsulta && (a.IdDoutor == idDoutor || a.IdClient == idCliente)))
                throw new Exception("Horario indisponivel para o Doutor ou Cliente!");

            using HttpResponseMessage doctorResponse = await _doutorClient.GetAsync($"api/Doutor/{idDoutor}");
            doctorResponse.EnsureSuccessStatusCode();
            
            using HttpResponseMessage ClienteResponse = await _doutorClient.GetAsync($"api/Cliente/{idCliente}");
            ClienteResponse.EnsureSuccessStatusCode();

        }

    }
}
