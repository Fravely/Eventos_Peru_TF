using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IModeracionRepository
{
    Task<IEnumerable<Moderacion>> GetAll();
    Task<Moderacion?> GetById(int idModeracion);
}
