using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> GetAll();
    Task<UsuarioDTO?> GetById(int idUsuario);
}
