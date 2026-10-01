using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class InteresRepository(EventosPeruIaContext context) : IInteresRepository
{
    public async Task<IEnumerable<Interes>> GetAll() =>
        await context.Interes.AsNoTracking().OrderBy(e => e.IdInteres).ToListAsync();
    public Task<Interes?> GetById(int idInteres) =>
        context.Interes.AsNoTracking().FirstOrDefaultAsync(e => e.IdInteres == idInteres);
}
