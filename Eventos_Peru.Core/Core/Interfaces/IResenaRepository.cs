using Eventos_Peru.Core.Core.Entities;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IResenaRepository
{
    Task<IEnumerable<Resena>> GetAll();
    Task<Resena?> GetById(int idResena);
}
