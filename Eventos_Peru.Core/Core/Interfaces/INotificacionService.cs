using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface INotificacionService
{
    Task<IEnumerable<NotificacionDTO>> GetAll();
    Task<NotificacionDTO?> GetById(int idNotificacion);
}
