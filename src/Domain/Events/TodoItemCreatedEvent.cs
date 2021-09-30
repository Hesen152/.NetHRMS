using dotnethrmsmy.Domain.Common;
using dotnethrmsmy.Domain.Entities;

namespace dotnethrmsmy.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
