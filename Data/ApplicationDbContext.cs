namespace ToDoListCodeFirst.Data
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using ToDoListCodeFirst.Model;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<ToDo> Tasks { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDo>().ToTable("Tasks");
            modelBuilder.Entity<ToDoList>().ToTable("ToDoList");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
