using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class UsuarioInteresRepository(EventosPeruIaContext context) : IUsuarioInteresRepository
{
    public async Task<IEnumerable<UsuarioInteres>> GetAll() =>
        await context.UsuarioInteres.AsNoTracking().OrderBy(e => e.IdUsuario).ThenBy(e => e.IdInteres).ToListAsync();
    public Task<UsuarioInteres?> GetById(int idUsuario, int idInteres) =>
        context.UsuarioInteres.AsNoTracking().FirstOrDefaultAsync(e => e.IdUsuario == idUsuario && e.IdInteres == idInteres);
}
