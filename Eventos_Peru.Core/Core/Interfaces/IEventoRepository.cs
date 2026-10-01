using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IEventoRepository
{
    Task<IEnumerable<Evento>> GetEventos(EventoFiltroDTO filtro);
    Task<Evento?> GetEventoById(int id);
    Task CreateEvento(Evento entity);
    Task SaveChanges();

    Task<bool> CategoriaActiva(int id);
    Task<bool> OrganizadorActivo(int id);
    Task<int> EntradasVendidas(int id);

}
