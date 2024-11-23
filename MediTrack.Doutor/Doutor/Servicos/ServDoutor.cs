using MediTrack;

namespace Doutor.Servicos
{
    public class ServDoutor
    {
        private readonly DataContext _context;

        public ServDoutor(DataContext context)
        {
            _context = context;
        }

        public void Inserir(DoutorModel doutor)
        {
            ValidarDadosDoutor(doutor);
            _context.Doutor.Add(doutor);
            _context.SaveChanges();
        }

        public void Editar(DoutorModel doutor)
        {
            ValidarDadosDoutor(doutor);
            var doutorExistente = _context.Doutor.FirstOrDefault(c => c.Id == doutor.Id);
            if (doutorExistente == null)
                throw new Exception("Doutor não encontrado.");

            doutorExistente.Nome = doutor.Nome;
            doutorExistente.Cpf = doutor.Cpf;
            doutorExistente.Email = doutor.Email;
            doutorExistente.Telefone = doutor.Telefone;
            doutorExistente.Endereco = doutor.Endereco;
            doutorExistente.Ativo = doutor.Ativo;

            _context.SaveChanges();
        }

        public DoutorModel BuscarDoutor(int id)
        {
            return _context.Doutor.FirstOrDefault(c => c.Id == id);
        }

        public List<DoutorModel> BuscarTodos()
        {
            return _context.Doutor.ToList();
        }

        private void ValidarDadosDoutor(DoutorModel doutor)
        {
            if (string.IsNullOrEmpty(doutor.Nome) || doutor.Nome.Length < 3)
                throw new Exception("O nome do doutor deve ter pelo menos 3 caracteres.");

            if (string.IsNullOrEmpty(doutor.Cpf) || doutor.Cpf.Length != 11)
                throw new Exception("CPF inválido. Deve conter 11 dígitos.");
        }
    }
}