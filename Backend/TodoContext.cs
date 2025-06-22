using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options){}
            public DbSet<Todo> Todo { get; set; }
    }
}