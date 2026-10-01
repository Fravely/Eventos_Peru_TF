namespace Eventos_Peru.Core.Core.DTOs;
public class ResenaDTO
{
    public int IdResena { get; set; }
    public int IdUsuario { get; set; }
    public int IdEvento { get; set; }
    public byte Calificacion { get; set; }
    public string Comentario { get; set; } = string.Empty;
    public DateTime FechaPublicacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
}
