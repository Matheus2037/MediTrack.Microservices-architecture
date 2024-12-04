using Consulta.DataBase.Models;
using Consulta.Domain.Consulta.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Consulta.Domain.Consulta
{
    [EntityTypeConfiguration(typeof(ConsultaModelConfiguration))]
    public class Consulta
    {
        public Consulta()
        {
            Lembrar = true;
        }

        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Doutor não informado.")]
        public int IdDoutor { get; set; }
        [Required(ErrorMessage = "Cliente não informado.")]
        public int IdClient { get; set; }
        [Required(ErrorMessage = "Data e hora da consulta não informda.")]
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "Erro interno do sistema, não foi possivel recuperara data de agendamento da consulta.")]
        public DateTime DataAgendamento { get; set; }
        [Required(ErrorMessage = "Meio de agendamento não informado.")]
        public MeioAgendamentoConsulta MeioAgendamento { get; set; }
        public Boolean Lembrar { get; set; }
    }
}
