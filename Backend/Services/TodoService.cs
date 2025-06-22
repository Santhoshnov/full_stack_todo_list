using Backend.Contracts.IRepositories;
using Backend.Contracts.IServices;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public List<TodoDto> GetTodoList()
        {
            return _todoRepository.GetTodoList()
                .Select(t => new TodoDto
                {
                    Name = t.Name!,
                    IsComplete = t.IsComplete
                }).ToList();
        }

        public void AddTodo(TodoDto todoDto)
        {
            Todo todo = new Todo
            {
                Id = Guid.NewGuid(),
                Name = todoDto.Name,
                IsComplete = todoDto.IsComplete
            };
            _todoRepository.AddTodo(todo);
            _todoRepository.SaveChanges();
        }

        public void UpdateTodo(Guid id, TodoDto todoDto)
        {
            Todo existingTodo = _todoRepository.GetTodo(id);
            if (existingTodo != null)
            {
                existingTodo.Name = todoDto.Name;
                existingTodo.IsComplete = todoDto.IsComplete;
                _todoRepository.UpdateTodo(existingTodo);
                _todoRepository.SaveChanges();
            }
        }

        public void DeleteTodo(Guid id)
        {
            Todo todoToDelete = _todoRepository.GetTodo(id);
            if (todoToDelete != null)
            {
                _todoRepository.DeleteTodo(todoToDelete);
                _todoRepository.SaveChanges();
            }
        }
    }
}