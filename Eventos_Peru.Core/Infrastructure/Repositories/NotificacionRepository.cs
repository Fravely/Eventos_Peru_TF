using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class NotificacionRepository(EventosPeruIaContext context) : INotificacionRepository
{
    public async Task<IEnumerable<Notificacion>> GetAll() =>
        await context.Notificacion.AsNoTracking().OrderBy(e => e.IdNotificacion).ToListAsync();
    public Task<Notificacion?> GetById(int idNotificacion) =>
        context.Notificacion.AsNoTracking().FirstOrDefaultAsync(e => e.IdNotificacion == idNotificacion);
}
