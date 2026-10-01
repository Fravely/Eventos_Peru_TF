using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IDetalleCompraService
{
    Task<IEnumerable<DetalleCompraDTO>> GetAll();
    Task<DetalleCompraDTO?> GetById(int idDetalleCompra);
}
