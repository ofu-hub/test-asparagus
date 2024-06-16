namespace Asparagus.Contracts;

/// <summary>
/// Модель отправки формы
/// </summary>
public class UserSubmissionDto
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Электронный адрес
    /// </summary>
    public string Email { get; set; } = string.Empty;
}