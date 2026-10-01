using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IUsuarioInteresRepository
{
    Task<IEnumerable<UsuarioInteres>> GetAll();
    Task<UsuarioInteres?> GetById(int idUsuario, int idInteres);
}
