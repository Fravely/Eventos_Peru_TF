namespace Eventos_Peru.Core.Core.DTOs;
public class CompraDTO
{
    public int IdCompra { get; set; }
    public int IdUsuario { get; set; }
    public Guid CodigoOperacion { get; set; }
    public DateTime FechaCompra { get; set; }
    public decimal MontoTotal { get; set; }
    public string Estado { get; set; } = string.Empty;
}
