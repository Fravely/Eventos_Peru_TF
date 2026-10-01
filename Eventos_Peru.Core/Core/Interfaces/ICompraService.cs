using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface ICompraService
{
    Task<IEnumerable<CompraDTO>> GetAll();
    Task<CompraDTO?> GetById(int idCompra);
}
