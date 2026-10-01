using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class InteresService(IInteresRepository repository) : IInteresService
{
    private static InteresDTO Map(Interes e) => new()
    {
        IdInteres = e.IdInteres,
        Nombre = e.Nombre,
        Estado = e.Estado
    };
    public async Task<IEnumerable<InteresDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<InteresDTO?> GetById(int idInteres)
    {
        var entity = await repository.GetById(idInteres);
        return entity == null ? null : Map(entity);
    }
}
