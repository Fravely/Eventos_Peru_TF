using System.ComponentModel.DataAnnotations;
namespace Eventos_Peru.Core.Core.DTOs;

public class CategoriaCreateDTO
{
    [Required, StringLength(80)] public string Nombre { get; set; } = string.Empty;
    [StringLength(250)] public string? Descripcion { get; set; }
}
public class CategoriaUpdateDTO : CategoriaCreateDTO
{
    [Range(1, int.MaxValue)] public int IdCategoria { get; set; }
}
public class CategoriaDTO : CategoriaUpdateDTO
{
    public bool Estado { get; set; }
}
