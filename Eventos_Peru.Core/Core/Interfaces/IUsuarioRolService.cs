using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IUsuarioRolService
{
    Task<IEnumerable<UsuarioRolDTO>> GetAll();
    Task<UsuarioRolDTO?> GetById(int idUsuario, int idRol);
}
