using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetCategorias();
    Task<Categoria?> GetCategoriaById(int id);
    Task CreateCategoria(Categoria entity);
    Task SaveChanges();
    Task<bool> NombreExiste(string nombre, int? exceptoId = null);

}
