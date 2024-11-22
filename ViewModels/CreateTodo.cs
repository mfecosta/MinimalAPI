using Flunt.Notifications;
using Flunt.Validations;

namespace MinimalApi.Models.ViewModels
{
    public class CreateTodo() : Notifiable<Notification> //Flunt ocm notificação Generica
    {        
         public string Title { get; set; }

         public Todo MapTo()
         { 
            var contract = new Contract<Notification>()                      
            .Requires()
            .IsNotNull(Title,"Informe o nome da tarefa")
            .IsGreaterThan(Title,5,"O texto deve ter mais de 5 caracteres");
            AddNotifications(contract);

            return new Todo(Guid.NewGuid(),Title,false);

         }
    }
}