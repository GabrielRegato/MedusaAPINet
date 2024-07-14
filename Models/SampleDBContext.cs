using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models
{
    public partial class SampleDBContext : DbContext
    {
        public SampleDBContext(DbContextOptions<SampleDBContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<PaymentMethod> Payment_Methods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace <YOUR_DB_NAME>, <USER>, <YOUR_PASSWORD> with your information to creates a connection
            optionsBuilder.UseSqlServer(
                @"Server=tcp:localhost,1433;Database=<YOUR_DB_NAME>;User ID=<USER>;Password=<YOUR_PASSWORD>;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(k => k.employee_id);
            });
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(k => k.department_id);
            });
            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(k => k.salary_id);
            });
            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(k => k.payment_method_id);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
