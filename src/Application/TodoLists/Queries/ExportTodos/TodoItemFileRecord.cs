using dotnethrmsmy.Application.Common.Mappings;
using dotnethrmsmy.Domain.Entities;

namespace dotnethrmsmy.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
