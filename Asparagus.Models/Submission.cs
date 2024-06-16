namespace Asparagus.Models;

/// <summary>
/// Модель отправки
/// </summary>
public class Submission : Entity
{
    /// <summary>
    /// Дата отправки
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public virtual User User { get; set; } = null!;
}