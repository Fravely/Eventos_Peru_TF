using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class RolRepository(EventosPeruIaContext context) : IRolRepository
{
    public async Task<IEnumerable<Rol>> GetAll() =>
        await context.Rol.AsNoTracking().OrderBy(e => e.IdRol).ToListAsync();
    public Task<Rol?> GetById(int idRol) =>
        context.Rol.AsNoTracking().FirstOrDefaultAsync(e => e.IdRol == idRol);
}
