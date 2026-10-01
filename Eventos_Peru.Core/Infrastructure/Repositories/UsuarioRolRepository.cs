using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class UsuarioRolRepository(EventosPeruIaContext context) : IUsuarioRolRepository
{
    public async Task<IEnumerable<UsuarioRol>> GetAll() =>
        await context.UsuarioRol.AsNoTracking().OrderBy(e => e.IdUsuario).ThenBy(e => e.IdRol).ToListAsync();
    public Task<UsuarioRol?> GetById(int idUsuario, int idRol) =>
        context.UsuarioRol.AsNoTracking().FirstOrDefaultAsync(e => e.IdUsuario == idUsuario && e.IdRol == idRol);
}
