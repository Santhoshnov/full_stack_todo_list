using Backend.Contracts.IRepositories;
using Backend;
using Backend.Models;

namespace Backend.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _todoContext;
        public TodoRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public IQueryable<Todo> GetTodoList()
        {
            return _todoContext.Todo.AsQueryable();
        }

        public Todo GetTodo(Guid id)
        {
            return _todoContext.Todo.Find(id);
        }

        public void AddTodo(Todo todo)
        {
            _todoContext.Add(todo);
        }

        public void UpdateTodo(Todo todo)
        {
            _todoContext.Update(todo);
        }

        public void DeleteTodo(Todo todo)
        {
            _todoContext.Remove(todo);
        }

        public void SaveChanges()
        { 
            _todoContext.SaveChanges();
        }



    }
}