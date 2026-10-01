using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IRolRepository
{
    Task<IEnumerable<Rol>> GetAll();
    Task<Rol?> GetById(int idRol);
}
