using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class CheckInService(ICheckInRepository repository) : ICheckInService
{
    private static CheckInDTO Map(CheckIn e) => new()
    {
        IdCheckIn = e.IdCheckIn,
        IdEntrada = e.IdEntrada,
        FechaHora = e.FechaHora
    };
    public async Task<IEnumerable<CheckInDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<CheckInDTO?> GetById(int idCheckIn)
    {
        var entity = await repository.GetById(idCheckIn);
        return entity == null ? null : Map(entity);
    }
}
