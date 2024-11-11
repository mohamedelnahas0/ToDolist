using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todolist_Core.Entities;
using Todolist_Core.Interfaces;

namespace ToDolist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoServices _todoService;

        public TodoController(ITodoServices todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos() => Ok(await _todoService.GetAllTodoAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var todo = await _todoService.GetTodoById(id);
            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoItem todo)
        {
            await _todoService.CreateToDoAsync(todo);
            return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoItem todo)
        {
            if (id != todo.Id) return BadRequest();
            await _todoService.UpdateToDoAsync(todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _todoService.DeleteToDoAsync(id);
            return NoContent();
        }
    }
}
