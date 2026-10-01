using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class RolService(IRolRepository repository) : IRolService
{
    private static RolDTO Map(Rol e) => new()
    {
        IdRol = e.IdRol,
        Nombre = e.Nombre
    };
    public async Task<IEnumerable<RolDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<RolDTO?> GetById(int idRol)
    {
        var entity = await repository.GetById(idRol);
        return entity == null ? null : Map(entity);
    }
}
