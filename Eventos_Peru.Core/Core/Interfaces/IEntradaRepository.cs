using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IEntradaRepository
{
    Task<IEnumerable<Entrada>> GetAll();
    Task<Entrada?> GetById(int idEntrada);
}
