using System;

namespace Relatorio_Mensal_API.Models
{
    public class HoursWorked
    {
        public HoursWorked(string usuario, DateTime date, TimeSpan horaEntrada, TimeSpan horaSaida, TimeSpan horaRetorno, TimeSpan horaFinal, TimeSpan totalHoras, string descri��o)
        {
            Usuario = usuario;
            Date = date;
            HoraEntrada = horaEntrada;
            HoraSaida = horaSaida;
            HoraRetorno = horaRetorno;
            HoraFinal = horaFinal;
            TotalHoras = totalHoras;
            Descri��o = descri��o;
        }

        public string Usuario { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraSaida { get; set; }
        public TimeSpan? HoraRetorno { get; set; }
        public TimeSpan? HoraFinal { get; set; }
        public TimeSpan? TotalHoras { get; set; }
        public string Descri��o { get; set; }
    }
}
