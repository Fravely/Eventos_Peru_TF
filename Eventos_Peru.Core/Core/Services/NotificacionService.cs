using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class NotificacionService(INotificacionRepository repository) : INotificacionService
{
    private static NotificacionDTO Map(Notificacion e) => new()
    {
        IdNotificacion = e.IdNotificacion,
        IdUsuario = e.IdUsuario,
        IdEvento = e.IdEvento,
        Tipo = e.Tipo,
        Titulo = e.Titulo,
        Mensaje = e.Mensaje,
        FechaCreacion = e.FechaCreacion,
        Leida = e.Leida,
        FechaLectura = e.FechaLectura
    };
    public async Task<IEnumerable<NotificacionDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<NotificacionDTO?> GetById(int idNotificacion)
    {
        var entity = await repository.GetById(idNotificacion);
        return entity == null ? null : Map(entity);
    }
}
