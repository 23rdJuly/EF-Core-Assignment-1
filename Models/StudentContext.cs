using System;
using Microsoft.EntityFrameworkCore;
namespace EF_core.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {

        }
        private const string connectionString = "data source=DESKTOP-894K3QD\\SQLEXPRESS;database=Student;Integrated Security=SSPI;persist security info=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Student> Students { get; set; }
    }
}