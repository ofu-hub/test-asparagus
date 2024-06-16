namespace Asparagus.Models;

/// <summary>
/// Модель пользователя
/// </summary>
public class User : Entity
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Электронный адрес
    /// </summary>
    public string Email { get; set; } = string.Empty;
    
    /// <summary>
    /// Количество отправок
    /// </summary>
    public int SubmissionCount { get; set; }

    /// <summary>
    /// Список 
    /// </summary>
    public virtual ICollection<Submission> Submissions { get; set; } = null!;
}