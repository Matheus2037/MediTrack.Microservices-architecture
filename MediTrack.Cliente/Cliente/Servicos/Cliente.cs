using System.ComponentModel.DataAnnotations;

namespace Cliente.Servicos
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome � obrigat�rio.")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF � obrigat�rio.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 d�gitos.")]
        public string Cpf { get; set; }

        [EmailAddress(ErrorMessage = "Email inv�lido.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "N�mero de telefone inv�lido.")]
        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public bool Ativo { get; set; }
    }
}
