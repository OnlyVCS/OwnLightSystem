using AutomationService.Domain.Entities;

namespace AutomationService.Application.Common.Services.Interfaces;

public class IRoomService
{
       public Task<Routine> GetRoutineByIdAsync(
        Guid routineId,
        CancellationToken cancellationToken = default
       );

       public Task<Room?> GetRoomByNameAsync(
        string roomName,
        CancellationToken cancellationToken = default
       );

       public Task<IEnumerable<Routine>> GetUserRoutineAsync(
        Guid userId,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default
       );

       public Task CreateRoomAsync(Room room, CancellationToken cancellationToken = default);
       public Task UpdateRoomAsync(Room room, CancellationToken cancellationToken = default);
       public Task DeleteRoomAsync(Guid roomId, CancellationToken cancellationToken = default);
}