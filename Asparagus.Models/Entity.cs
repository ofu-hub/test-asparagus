using System.ComponentModel.DataAnnotations;

namespace Asparagus.Models;

/// <summary>
/// Модель сущности
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Идентификатор модели
    /// </summary>
    public int Id { get; set; }
}