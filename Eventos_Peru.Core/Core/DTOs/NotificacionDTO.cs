namespace Eventos_Peru.Core.Core.DTOs;
public class NotificacionDTO
{
    public int IdNotificacion { get; set; }
    public int IdUsuario { get; set; }
    public int? IdEvento { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public string Mensaje { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public bool Leida { get; set; }
    public DateTime? FechaLectura { get; set; }
}
