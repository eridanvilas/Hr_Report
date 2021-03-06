using Newtonsoft.Json;
using System;

namespace Relatorio_Mensal_API.Models
{
    public class HoursWorked
    {

        public HoursWorked() { }
        public HoursWorked(string usuario, DateTime data, string horaEntrada, string horaSaida, string totalHoras, string projeto, string descricao)
        {
            Usuario = usuario;
            Data = data;
            HoraEntrada = horaEntrada;
            HoraSaida = horaSaida;
            TotalHoras = totalHoras;
            Projeto = projeto; 
            Descricao = descricao;
        }

        [JsonProperty("usuario")]
        public string Usuario { get; set; }
        [JsonProperty("data")]
        public DateTime Data { get; set; }
        [JsonProperty("horaEntrada")]
        public string HoraEntrada { get; set; }
        [JsonProperty("horaSaida")]
        public string HoraSaida { get; set; }
        [JsonProperty("totalHoras")]
        public string TotalHoras { get; set; }
        [JsonProperty("projeto")]
        public string Projeto { get; set; }
        [JsonProperty("descricao")]
        public string Descricao { get; set; }
    }
}
