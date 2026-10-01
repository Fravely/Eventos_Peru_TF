using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IInteresRepository
{
    Task<IEnumerable<Interes>> GetAll();
    Task<Interes?> GetById(int idInteres);
}
