using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using MinimalApi.Models;


namespace MinimalApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db; Cache=Shared");
    }
}
