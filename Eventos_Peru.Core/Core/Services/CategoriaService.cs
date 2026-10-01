using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Exceptions;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class CategoriaService(ICategoriaRepository repository) : ICategoriaService
{
    private static CategoriaDTO Map(Categoria c) => new() { IdCategoria = c.IdCategoria, Nombre = c.Nombre, Descripcion = c.Descripcion, Estado = c.Estado };
    public async Task<IEnumerable<CategoriaDTO>> GetCategorias() => (await repository.GetCategorias()).Select(Map);
    public async Task<CategoriaDTO?> GetCategoriaById(int id)
    {
        var entity = await repository.GetCategoriaById(id);
        return entity == null ? null : Map(entity);
    }
    public async Task<CategoriaDTO> CreateCategoria(CategoriaCreateDTO dto)
    {
        if (await repository.NombreExiste(dto.Nombre.Trim())) throw new ReglaNegocioException("Ya existe una categoría con ese nombre.");
        var entity = new Categoria { Nombre = dto.Nombre.Trim(), Descripcion = dto.Descripcion?.Trim(), Estado = true };
        await repository.CreateCategoria(entity);
        return Map(entity);
    }
    public async Task<bool> UpdateCategoria(CategoriaUpdateDTO dto)
    {
        var entity = await repository.GetCategoriaById(dto.IdCategoria);
        if (entity == null) return false;
        if (await repository.NombreExiste(dto.Nombre.Trim(), dto.IdCategoria)) throw new ReglaNegocioException("Ya existe una categoría con ese nombre.");
        entity.Nombre = dto.Nombre.Trim();
        entity.Descripcion = dto.Descripcion?.Trim();
        await repository.SaveChanges();
        return true;
    }
    public async Task<bool> DeleteCategoria(int id)
    {
        var entity = await repository.GetCategoriaById(id);
        if (entity == null) return false;
        entity.Estado = false;
        await repository.SaveChanges();
        return true;
    }
}
