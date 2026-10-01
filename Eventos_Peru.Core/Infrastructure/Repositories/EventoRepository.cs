using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class EventoRepository(EventosPeruIaContext context) : IEventoRepository
{
    public async Task<IEnumerable<Evento>> GetEventos(EventoFiltroDTO filtro)
    {
        var query = context.Evento.AsNoTracking().Include(e => e.IdCategoriaNavigation)
            .Include(e => e.IdOrganizadorNavigation).Where(e => e.Estado != "Retirado");
        if (filtro.IdCategoria.HasValue) query = query.Where(e => e.IdCategoria == filtro.IdCategoria);
        if (filtro.Desde.HasValue) query = query.Where(e => e.FechaHoraInicio >= filtro.Desde);
        if (filtro.Hasta.HasValue) query = query.Where(e => e.FechaHoraInicio <= filtro.Hasta);
        if (!string.IsNullOrWhiteSpace(filtro.Ubicacion)) query = query.Where(e => e.Ubicacion.Contains(filtro.Ubicacion));
        if (!string.IsNullOrWhiteSpace(filtro.Estado)) query = query.Where(e => e.Estado == filtro.Estado);
        return await query.OrderBy(e => e.FechaHoraInicio).ThenBy(e => e.IdEvento).ToListAsync();
    }
    public Task<Evento?> GetEventoById(int id) => context.Evento.Include(e => e.IdCategoriaNavigation)
        .Include(e => e.IdOrganizadorNavigation).FirstOrDefaultAsync(e => e.IdEvento == id && e.Estado != "Retirado");
    public Task<bool> CategoriaActiva(int id) => context.Categoria.AnyAsync(c => c.IdCategoria == id && c.Estado);
    public Task<bool> OrganizadorActivo(int id) => context.Usuario.AnyAsync(u => u.IdUsuario == id && u.Estado == "Activo"
        && u.UsuarioRol.Any(r => r.IdRolNavigation.Nombre == "Organizador"));
    public Task<int> EntradasVendidas(int id) => context.Entrada.CountAsync(e => e.IdDetalleCompraNavigation.IdEvento == id
        && (e.Estado == "Valida" || e.Estado == "Utilizada"));
    public async Task CreateEvento(Evento entity)
    {
        context.Evento.Add(entity);
        await context.SaveChangesAsync();
    }
    public async Task SaveChanges() => await context.SaveChangesAsync();
}
