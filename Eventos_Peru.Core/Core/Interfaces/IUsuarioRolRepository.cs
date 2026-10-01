using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IUsuarioRolRepository
{
    Task<IEnumerable<UsuarioRol>> GetAll();
    Task<UsuarioRol?> GetById(int idUsuario, int idRol);
}
