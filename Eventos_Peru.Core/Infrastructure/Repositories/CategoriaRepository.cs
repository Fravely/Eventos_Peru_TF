using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class CategoriaRepository(EventosPeruIaContext context) : ICategoriaRepository
{
    public async Task<IEnumerable<Categoria>> GetCategorias() =>
        await context.Categoria.AsNoTracking().Where(c => c.Estado).OrderBy(c => c.Nombre).ToListAsync();
    public Task<Categoria?> GetCategoriaById(int id) => context.Categoria.FirstOrDefaultAsync(c => c.IdCategoria == id && c.Estado);
    public Task<bool> NombreExiste(string nombre, int? exceptoId = null) =>
        context.Categoria.AnyAsync(c => c.Nombre == nombre && (!exceptoId.HasValue || c.IdCategoria != exceptoId));
    public async Task CreateCategoria(Categoria entity)
    {
        context.Categoria.Add(entity);
        await context.SaveChangesAsync();
    }
    public async Task SaveChanges() => await context.SaveChangesAsync();
}
