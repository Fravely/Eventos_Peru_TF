using System.ComponentModel.DataAnnotations;
namespace Eventos_Peru.Core.Core.DTOs;

public class EventoCreateDTO : IValidatableObject
{
    [Range(1, int.MaxValue)] public int IdOrganizador { get; set; }
    [Range(1, int.MaxValue)] public int IdCategoria { get; set; }
    [Required, StringLength(150)] public string Nombre { get; set; } = string.Empty;
    [StringLength(1000)] public string? Descripcion { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public DateTime FechaHoraFin { get; set; }
    [Required, StringLength(250)] public string Ubicacion { get; set; } = string.Empty;
    [Range(1, int.MaxValue)] public int AforoMaximo { get; set; }
    [Range(typeof(decimal), "0", "99999999.99")] public decimal Precio { get; set; }
    [Required, RegularExpression("^(Borrador|Publicado)$")]
    public string Estado { get; set; } = "Borrador";

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (FechaHoraInicio == default)
            yield return new ValidationResult("La fecha de inicio es obligatoria.", [nameof(FechaHoraInicio)]);
        if (FechaHoraFin <= FechaHoraInicio)
            yield return new ValidationResult("La fecha final debe ser posterior al inicio.", [nameof(FechaHoraFin)]);
        if (decimal.Round(Precio, 2) != Precio)
            yield return new ValidationResult("El precio admite como máximo dos decimales.", [nameof(Precio)]);
    }
}
public class EventoUpdateDTO : EventoCreateDTO
{
    [Range(1, int.MaxValue)] public int IdEvento { get; set; }
}
public class EventoDTO
{
    public int IdEvento { get; set; }
    public int IdOrganizador { get; set; }
    public int IdCategoria { get; set; }
    public string Organizador { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public DateTime FechaHoraFin { get; set; }
    public string Ubicacion { get; set; } = string.Empty;
    public int AforoMaximo { get; set; }
    public decimal Precio { get; set; }
    public string Estado { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
}
public class EventoFiltroDTO : IValidatableObject
{
    [Range(1, int.MaxValue)] public int? IdCategoria { get; set; }
    public DateTime? Desde { get; set; }
    public DateTime? Hasta { get; set; }
    [StringLength(250)] public string? Ubicacion { get; set; }
    [RegularExpression("^(Borrador|Publicado|Finalizado|Cancelado|Suspendido|Retirado)$")]
    public string? Estado { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (Desde.HasValue && Hasta.HasValue && Hasta < Desde)
            yield return new ValidationResult("Hasta debe ser mayor o igual a Desde.", [nameof(Hasta)]);
    }
}
