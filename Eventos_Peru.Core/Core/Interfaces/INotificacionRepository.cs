using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface INotificacionRepository
{
    Task<IEnumerable<Notificacion>> GetAll();
    Task<Notificacion?> GetById(int idNotificacion);
}
