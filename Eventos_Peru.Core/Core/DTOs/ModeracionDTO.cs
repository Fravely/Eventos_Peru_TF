namespace Eventos_Peru.Core.Core.DTOs;
public class ModeracionDTO
{
    public int IdModeracion { get; set; }
    public int IdAdministrador { get; set; }
    public int? IdUsuarioAfectado { get; set; }
    public int? IdEventoAfectado { get; set; }
    public string Accion { get; set; } = string.Empty;
    public string Motivo { get; set; } = string.Empty;
    public DateTime FechaAccion { get; set; }
}
