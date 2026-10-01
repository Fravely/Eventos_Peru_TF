using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IRolService
{
    Task<IEnumerable<RolDTO>> GetAll();
    Task<RolDTO?> GetById(int idRol);
}
