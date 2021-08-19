using MediatR;
using System;

namespace Relatorio_Mensal_API.Application.Notifications.FileReader
{
    public class FileReaderNotification : INotification
    {

        public string Usuario { get; set; }
        public DateTime? Date { get; set; }
    }
}
