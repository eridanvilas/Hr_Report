using MediatR;
using Relatorio_Mensal_API.Application.Notifications.Error;
using Relatorio_Mensal_API.Application.Notifications.FileReader;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Application.EventHandlers
{
    public class LogEventHandler : INotificationHandler<FileReaderNotification>,
                                   INotificationHandler<ErrorNotification>
    {
        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                Console.WriteLine($"Error: " + notification.Error +" \n " + notification.StackError);
            });
        }

        public Task Handle(FileReaderNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                Console.WriteLine($"FileReader: " + notification.Usuario + " \n " + notification.Date);
            });
        }
    }
}
