using Microsoft.EntityFrameworkCore;
using basic_crud.model;

namespace basic_crud.data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        { }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}