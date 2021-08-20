using System;

namespace Relatorio_Mensal_API.Models
{
    public class HoursWorked
    {
        public HoursWorked(string usuario, DateTime data, string horaEntrada, string horaSaida, string totalHoras, string projeto, string descricao)
        {
            Usuario = usuario;
            Data = data;
            HoraEntrada = horaEntrada;
            HoraSaida = horaSaida;
            //HoraRetorno = horaRetorno;
            //HoraFinal = horaFinal;
            TotalHoras = totalHoras;
            Projeto = projeto; 
            Descricao = descricao;
        }

        public string Usuario { get; set; }
        public DateTime? Data { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSaida { get; set; }
        //public string HoraRetorno { get; set; }
        //public string HoraFinal { get; set; }
        public string TotalHoras { get; set; }
        public string Projeto { get; set; }
        public string Descricao { get; set; }
    }
}
