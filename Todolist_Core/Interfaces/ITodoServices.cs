using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist_Core.Entities;

namespace Todolist_Core.Interfaces
{
    public interface ITodoServices
    {
        Task<IEnumerable<TodoItem>> GetAllTodoAsync();
        Task<TodoItem> GetTodoById (int id);    
        Task CreateToDoAsync(TodoItem todo);
        Task UpdateToDoAsync(TodoItem todo);
        Task DeleteToDoAsync(int id);
    }
}
