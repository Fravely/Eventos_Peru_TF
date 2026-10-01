using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class UsuarioRolService(IUsuarioRolRepository repository) : IUsuarioRolService
{
    private static UsuarioRolDTO Map(UsuarioRol e) => new()
    {
        IdUsuario = e.IdUsuario,
        IdRol = e.IdRol,
        FechaAsignacion = e.FechaAsignacion
    };
    public async Task<IEnumerable<UsuarioRolDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<UsuarioRolDTO?> GetById(int idUsuario, int idRol)
    {
        var entity = await repository.GetById(idUsuario, idRol);
        return entity == null ? null : Map(entity);
    }
}
