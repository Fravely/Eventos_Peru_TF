using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class UsuarioService(IUsuarioRepository repository) : IUsuarioService
{
    private static UsuarioDTO Map(Usuario e) => new()
    {
        IdUsuario = e.IdUsuario,
        Nombre = e.Nombre,
        Apellido = e.Apellido,
        Correo = e.Correo,
        FechaRegistro = e.FechaRegistro,
        Estado = e.Estado
    };
    public async Task<IEnumerable<UsuarioDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<UsuarioDTO?> GetById(int idUsuario)
    {
        var entity = await repository.GetById(idUsuario);
        return entity == null ? null : Map(entity);
    }
}
