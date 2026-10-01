using Eventos_Peru.Core.Core.DTOs;
namespace Eventos_Peru.Core.Core.Interfaces;
public interface IEntradaService
{
    Task<IEnumerable<EntradaDTO>> GetAll();
    Task<EntradaDTO?> GetById(int idEntrada);
}
