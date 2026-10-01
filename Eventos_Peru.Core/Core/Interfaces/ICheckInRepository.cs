using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface ICheckInRepository
{
    Task<IEnumerable<CheckIn>> GetAll();
    Task<CheckIn?> GetById(int idCheckIn);
}
