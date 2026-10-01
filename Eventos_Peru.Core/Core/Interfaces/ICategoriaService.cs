using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> GetCategorias();
    Task<CategoriaDTO?> GetCategoriaById(int id);
    Task<CategoriaDTO> CreateCategoria(CategoriaCreateDTO dto);
    Task<bool> UpdateCategoria(CategoriaUpdateDTO dto);
    Task<bool> DeleteCategoria(int id);
}
