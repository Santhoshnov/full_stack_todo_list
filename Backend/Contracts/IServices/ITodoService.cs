using Backend.Dtos;
using Backend.Models;

namespace Backend.Contracts.IServices
{
    public interface ITodoService
    {
        List<TodoDto> GetTodoList();
        void AddTodo(TodoDto todoDto);
        void UpdateTodo(Guid id, TodoDto todoDto);
        void DeleteTodo(Guid id);
    }
}