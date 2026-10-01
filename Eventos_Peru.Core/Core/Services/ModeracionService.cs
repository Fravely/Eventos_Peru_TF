using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class ModeracionService(IModeracionRepository repository) : IModeracionService
{
    private static ModeracionDTO Map(Moderacion e) => new()
    {
        IdModeracion = e.IdModeracion,
        IdAdministrador = e.IdAdministrador,
        IdUsuarioAfectado = e.IdUsuarioAfectado,
        IdEventoAfectado = e.IdEventoAfectado,
        Accion = e.Accion,
        Motivo = e.Motivo,
        FechaAccion = e.FechaAccion
    };
    public async Task<IEnumerable<ModeracionDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<ModeracionDTO?> GetById(int idModeracion)
    {
        var entity = await repository.GetById(idModeracion);
        return entity == null ? null : Map(entity);
    }
}
