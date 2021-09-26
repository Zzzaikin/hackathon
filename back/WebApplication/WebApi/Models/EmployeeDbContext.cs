using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    /// <summary>
    /// Подключение к базе данных.
    /// </summary>
    public class EmployeeDbContext : DbContext
    {
        /// <summary>
        /// Сотрудники.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// Семейное положение.
        /// </summary>
        public DbSet<FamilyStatus> FamilyStatuses { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public DbSet<Gender> Genders { get; set; }
        /// <summary>
        /// Города.
        /// </summary>
        public DbSet<City> Cities { get; set; }
        /// <summary>
        /// Должность.
        /// </summary>
        public DbSet<Position> Positions { get; set; }

        /// <summary>
        /// Создает объект и проверяет, создана ли база данных.
        /// </summary>
        public EmployeeDbContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Задает конфигурацию подключения к базе данных.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Analitics;Trusted_Connection=True;");
        }
    }
}
