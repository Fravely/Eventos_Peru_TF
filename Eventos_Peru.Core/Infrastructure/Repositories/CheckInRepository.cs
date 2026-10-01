using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class CheckInRepository(EventosPeruIaContext context) : ICheckInRepository
{
    public async Task<IEnumerable<CheckIn>> GetAll() =>
        await context.CheckIn.AsNoTracking().OrderBy(e => e.IdCheckIn).ToListAsync();
    public Task<CheckIn?> GetById(int idCheckIn) =>
        context.CheckIn.AsNoTracking().FirstOrDefaultAsync(e => e.IdCheckIn == idCheckIn);
}
