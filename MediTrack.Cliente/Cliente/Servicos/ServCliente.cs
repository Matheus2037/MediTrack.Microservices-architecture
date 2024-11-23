using MediTrack;

namespace Cliente.Servicos
{
    public class ServCliente
    {
        private readonly DataContext _context;

        public ServCliente(DataContext context)
        {
            _context = context;
        }

        public void Inserir(ClienteModel cliente)
        {
            ValidarDadosCliente(cliente);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Editar(ClienteModel cliente)
        {
            ValidarDadosCliente(cliente);
            var clienteExistente = _context.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (clienteExistente == null)
                throw new Exception("Cliente não encontrado.");

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Cpf = cliente.Cpf;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefone = cliente.Telefone;
            clienteExistente.Endereco = cliente.Endereco;
            clienteExistente.Ativo = cliente.Ativo;

            _context.SaveChanges();
        }

        public ClienteModel BuscarCliente(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _context.Clientes.ToList();
        }

        private void ValidarDadosCliente(ClienteModel cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome) || cliente.Nome.Length < 3)
                throw new Exception("O nome do cliente deve ter pelo menos 3 caracteres.");

            if (string.IsNullOrEmpty(cliente.Cpf) || cliente.Cpf.Length != 11)
                throw new Exception("CPF inválido. Deve conter 11 dígitos.");
        }
    }
}