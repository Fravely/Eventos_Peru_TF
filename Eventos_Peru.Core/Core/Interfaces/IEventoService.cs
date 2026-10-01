using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IEventoService
{
    Task<IEnumerable<EventoDTO>> GetEventos(EventoFiltroDTO filtro);
    Task<EventoDTO?> GetEventoById(int id);
    Task<EventoDTO> CreateEvento(EventoCreateDTO dto);
    Task<bool> UpdateEvento(EventoUpdateDTO dto);
    Task<bool> DeleteEvento(int id);
}
