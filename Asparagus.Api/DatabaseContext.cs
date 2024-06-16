using Asparagus.Models;
using Microsoft.EntityFrameworkCore;

namespace Asparagus.Api;

public sealed class DatabaseContext : DbContext
{
    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public DatabaseContext() { }
    
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="options">Параметры</param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
    {
        if (Database.GetPendingMigrations().Any())
            Database.Migrate();
    }
    
    /// <summary>
    /// Таблица пользователей
    /// </summary>
    public DbSet<User> Users { get; set; }
    
    /// <summary>
    /// Таблица отправок
    /// </summary>
    public DbSet<Submission> Submissions { get; set; }
}