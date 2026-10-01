using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IResenaService
{
    Task<IEnumerable<ResenaDTO>> GetAll();
    Task<ResenaDTO?> GetById(int idResena);
}
