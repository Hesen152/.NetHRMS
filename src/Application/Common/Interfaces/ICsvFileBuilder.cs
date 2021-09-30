using dotnethrmsmy.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace dotnethrmsmy.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
