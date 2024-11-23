using System.ComponentModel.DataAnnotations;

namespace Cliente.Servicos
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string Cpf { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public bool Ativo { get; set; }
    }
}
