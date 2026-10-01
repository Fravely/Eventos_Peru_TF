using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IModeracionService
{
    Task<IEnumerable<ModeracionDTO>> GetAll();
    Task<ModeracionDTO?> GetById(int idModeracion);
}
