using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class ResenaService(IResenaRepository repository) : IResenaService
{
    private static ResenaDTO Map(Resena e) => new()
    {
        IdResena = e.IdResena,
        IdUsuario = e.IdUsuario,
        IdEvento = e.IdEvento,
        Calificacion = e.Calificacion,
        Comentario = e.Comentario,
        FechaPublicacion = e.FechaPublicacion,
        FechaModificacion = e.FechaModificacion
    };
    public async Task<IEnumerable<ResenaDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<ResenaDTO?> GetById(int idResena)
    {
        var entity = await repository.GetById(idResena);
        return entity == null ? null : Map(entity);
    }
}
