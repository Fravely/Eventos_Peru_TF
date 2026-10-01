namespace Eventos_Peru.Core.Core.DTOs;
public class DetalleCompraDTO
{
    public int IdDetalleCompra { get; set; }
    public int IdCompra { get; set; }
    public int IdEvento { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
}
