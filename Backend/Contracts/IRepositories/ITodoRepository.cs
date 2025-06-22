using Backend.Models;

namespace Backend.Contracts.IRepositories
{
    public interface ITodoRepository
    {
        IQueryable<Todo> GetTodoList();
        Todo GetTodo(Guid id);
        void AddTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteTodo(Todo todo);
        void SaveChanges();

    }
}