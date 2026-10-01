using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IDetalleCompraRepository
{
    Task<IEnumerable<DetalleCompra>> GetAll();
    Task<DetalleCompra?> GetById(int idDetalleCompra);
}
