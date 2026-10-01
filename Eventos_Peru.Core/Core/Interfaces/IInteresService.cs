using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IInteresService
{
    Task<IEnumerable<InteresDTO>> GetAll();
    Task<InteresDTO?> GetById(int idInteres);
}
