using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class UsuarioInteresService(IUsuarioInteresRepository repository) : IUsuarioInteresService
{
    private static UsuarioInteresDTO Map(UsuarioInteres e) => new()
    {
        IdUsuario = e.IdUsuario,
        IdInteres = e.IdInteres,
        FechaRegistro = e.FechaRegistro
    };
    public async Task<IEnumerable<UsuarioInteresDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<UsuarioInteresDTO?> GetById(int idUsuario, int idInteres)
    {
        var entity = await repository.GetById(idUsuario, idInteres);
        return entity == null ? null : Map(entity);
    }
}
