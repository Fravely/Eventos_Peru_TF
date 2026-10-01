namespace Eventos_Peru.Core.Core.DTOs;
public class EntradaDTO
{
    public int IdEntrada { get; set; }
    public int IdDetalleCompra { get; set; }
    public Guid CodigoEntrada { get; set; }
    public string Estado { get; set; } = string.Empty;
    public DateTime FechaGeneracion { get; set; }
}
