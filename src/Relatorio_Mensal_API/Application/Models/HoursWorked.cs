using System;

namespace Relatorio_Mensal_API.Models
{
    public class HoursWorked
    {
        public HoursWorked(string usuario, DateTime date, string horaEntrada, string horaSaida, string horaRetorno, string horaFinal, string totalHoras, string descricao)
        {
            Usuario = usuario;
            Date = date;
            HoraEntrada = horaEntrada;
            HoraSaida = horaSaida;
            HoraRetorno = horaRetorno;
            HoraFinal = horaFinal;
            TotalHoras = totalHoras;
            Descricao = descricao;
        }

        public string Usuario { get; set; }
        public DateTime? Date { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSaida { get; set; }
        public string HoraRetorno { get; set; }
        public string HoraFinal { get; set; }
        public string TotalHoras { get; set; }
        public string Descricao { get; set; }
    }
}
