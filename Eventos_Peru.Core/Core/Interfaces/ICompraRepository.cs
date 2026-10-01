using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface ICompraRepository
{
    Task<IEnumerable<Compra>> GetAll();
    Task<Compra?> GetById(int idCompra);
}
