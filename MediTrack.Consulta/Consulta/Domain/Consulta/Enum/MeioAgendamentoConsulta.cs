using System.ComponentModel;

namespace Consulta.Domain.Consulta.Enum
{
    public enum MeioAgendamentoConsulta
    {
        [Description("Presencial")]
        Presencial = 0,
        [Description("Telefone")]
        Telefone = 1,
        [Description("WhatsApp")]
        WhatsApp = 2,
        [Description("Telegram")]
        Telegram = 3
    }
}
