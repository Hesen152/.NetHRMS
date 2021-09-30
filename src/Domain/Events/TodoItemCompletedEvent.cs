using dotnethrmsmy.Domain.Common;
using dotnethrmsmy.Domain.Entities;

namespace dotnethrmsmy.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
