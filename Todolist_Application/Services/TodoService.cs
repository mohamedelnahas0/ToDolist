using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist_Core.Entities;
using Todolist_Core.Interfaces;

namespace Todolist_Application.Services
{
    public class TodoService : ITodoServices
    {
        private readonly IRepository<TodoItem> _repository;

        public TodoService(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoAsync() => await _repository.GetAllAsync();
        

        public async Task<TodoItem> GetTodoById(int id) => await _repository.GetbyIdAsync(id);


        public async Task CreateToDoAsync(TodoItem todo) => await _repository.AddAsync(todo);
       

        public async Task UpdateToDoAsync(TodoItem todo) => await _repository.UpdateAsync(todo);


        public async Task DeleteToDoAsync(int id) => await _repository.DeleteAsync(id);

    }
}
