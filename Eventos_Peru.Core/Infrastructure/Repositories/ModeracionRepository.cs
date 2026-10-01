using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class ModeracionRepository(EventosPeruIaContext context) : IModeracionRepository
{
    public async Task<IEnumerable<Moderacion>> GetAll() =>
        await context.Moderacion.AsNoTracking().OrderBy(e => e.IdModeracion).ToListAsync();
    public Task<Moderacion?> GetById(int idModeracion) =>
        context.Moderacion.AsNoTracking().FirstOrDefaultAsync(e => e.IdModeracion == idModeracion);
}
