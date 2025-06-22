using Backend.Contracts.IServices;
using Backend.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetTodoList()
        {
            List<TodoDto> todoList = _todoService.GetTodoList();
            return Ok(todoList);
        }

        [HttpPost]
        public IActionResult AddTodo([FromBody] TodoDto todo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _todoService.AddTodo(todo);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTodo(Guid id, [FromBody] TodoDto todoDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _todoService.UpdateTodo(id, todoDto);
            return Ok(new { success = true, message = "Todo updated successfully." });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(Guid id)
        {
            _todoService.DeleteTodo(id);
           return Ok(new { success = true, message = "Todo deleted successfully." });
        }
    }
}