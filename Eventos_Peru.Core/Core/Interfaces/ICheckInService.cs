using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface ICheckInService
{
    Task<IEnumerable<CheckInDTO>> GetAll();
    Task<CheckInDTO?> GetById(int idCheckIn);
}
