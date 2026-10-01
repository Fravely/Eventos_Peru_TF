using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Exceptions;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class EventoService(IEventoRepository repository) : IEventoService
{
    private static EventoDTO Map(Evento e) => new()
    {
        IdEvento = e.IdEvento, IdCategoria = e.IdCategoria, IdOrganizador = e.IdOrganizador,
        Categoria = e.IdCategoriaNavigation?.Nombre ?? string.Empty,
        Organizador = e.IdOrganizadorNavigation == null ? string.Empty : $"{e.IdOrganizadorNavigation.Nombre} {e.IdOrganizadorNavigation.Apellido}",
        Nombre = e.Nombre, Descripcion = e.Descripcion, FechaHoraInicio = e.FechaHoraInicio,
        FechaHoraFin = e.FechaHoraFin, Ubicacion = e.Ubicacion, AforoMaximo = e.AforoMaximo,
        Precio = e.Precio, Estado = e.Estado, FechaCreacion = e.FechaCreacion
    };
    private async Task Validar(EventoCreateDTO dto)
    {
        if (!await repository.CategoriaActiva(dto.IdCategoria)) throw new ReglaNegocioException("La categoría no existe o está inactiva.");
        if (!await repository.OrganizadorActivo(dto.IdOrganizador)) throw new ReglaNegocioException("El usuario debe estar activo y tener el rol Organizador.");
    }
    public async Task<IEnumerable<EventoDTO>> GetEventos(EventoFiltroDTO filtro) => (await repository.GetEventos(filtro)).Select(Map);
    public async Task<EventoDTO?> GetEventoById(int id)
    {
        var entity = await repository.GetEventoById(id);
        return entity == null ? null : Map(entity);
    }
    private static void Assign(Evento e, EventoCreateDTO dto)
    {
        e.IdOrganizador = dto.IdOrganizador; e.IdCategoria = dto.IdCategoria;
        e.Nombre = dto.Nombre.Trim(); e.Descripcion = dto.Descripcion?.Trim();
        e.FechaHoraInicio = dto.FechaHoraInicio; e.FechaHoraFin = dto.FechaHoraFin;
        e.Ubicacion = dto.Ubicacion.Trim(); e.AforoMaximo = dto.AforoMaximo;
        e.Precio = dto.Precio; e.Estado = dto.Estado;
    }
    public async Task<EventoDTO> CreateEvento(EventoCreateDTO dto)
    {
        await Validar(dto);
        var entity = new Evento();
        Assign(entity, dto);
        await repository.CreateEvento(entity);
        return Map((await repository.GetEventoById(entity.IdEvento))!);
    }
    public async Task<bool> UpdateEvento(EventoUpdateDTO dto)
    {
        var entity = await repository.GetEventoById(dto.IdEvento);
        if (entity == null) return false;
        if (entity.Estado is "Cancelado" or "Finalizado" or "Suspendido")
            throw new ReglaNegocioException("No se puede editar un evento cancelado, finalizado o suspendido.");
        if (entity.IdOrganizador != dto.IdOrganizador) throw new ReglaNegocioException("No se puede cambiar el organizador del evento.");
        await Validar(dto);
        var vendidas = await repository.EntradasVendidas(dto.IdEvento);
        if (dto.AforoMaximo < vendidas) throw new ReglaNegocioException($"El aforo no puede ser menor a las {vendidas} entradas ya vendidas.");
        Assign(entity, dto);
        await repository.SaveChanges();
        return true;
    }
    public async Task<bool> DeleteEvento(int id)
    {
        var entity = await repository.GetEventoById(id);
        if (entity == null) return false;
        if (await repository.EntradasVendidas(id) > 0) throw new ReglaNegocioException("No se puede retirar un evento con entradas vendidas; requiere el flujo de cancelación.");
        entity.Estado = "Retirado";
        await repository.SaveChanges();
        return true;
    }
}
