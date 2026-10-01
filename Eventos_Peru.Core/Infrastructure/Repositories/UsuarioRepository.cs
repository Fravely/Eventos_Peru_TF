using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class UsuarioRepository(EventosPeruIaContext context) : IUsuarioRepository
{
    public async Task<IEnumerable<Usuario>> GetAll() =>
        await context.Usuario.AsNoTracking().OrderBy(e => e.IdUsuario).ToListAsync();
    public Task<Usuario?> GetById(int idUsuario) =>
        context.Usuario.AsNoTracking().FirstOrDefaultAsync(e => e.IdUsuario == idUsuario);
}
