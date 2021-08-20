using MediatR;

namespace Relatorio_Mensal_API.Application.Notifications.Error
{
    public class ErrorNotification : INotification
    {
        public string Error { get; set; }
        public string StackError { get; set; }
    }
}
