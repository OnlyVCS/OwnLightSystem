using AutomationService.Domain.Entities;
using AutomationService.Domain.Enums;
using AutomationService.Domain.Interfaces;
using AutomationService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AutomationService.Infrastructure.Repositories;

public class RoutineExecutionLogRepository(DataContext dataContext)
    : Repository<RoutineExecutionLog>(dataContext),
        IRoutineExecutionLogRepository
{
    private readonly DbSet<RoutineExecutionLog> _dbSet = dataContext.Set<RoutineExecutionLog>();

    public async Task<IEnumerable<RoutineExecutionLog>> GetByActionStatus(
        ActionStatus actionStatus,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var skipAmount = (page - 1) * pageSize;
        return await _dbSet
            .Where(r => r.ActionStatus == actionStatus)
            .Skip(skipAmount)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<RoutineExecutionLog>> GetByActionTarget(
        ActionTarget actionTarget,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var skipAmount = (page - 1) * pageSize;
        return await _dbSet
            .Where(r => r.ActionTarget == actionTarget)
            .Skip(skipAmount)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<RoutineExecutionLog>> GetByRoutineActionType(
        RoutineActionType actionType,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var skipAmount = (page - 1) * pageSize;
        return await _dbSet
            .Where(r => r.ActionType == actionType)
            .Skip(skipAmount)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

<<<<<<< HEAD
    public async Task<IEnumerable<RoutineExecutionLog>> GetByDeviceId(
        Guid deviceId,
=======
    public async Task<IEnumerable<RoutineExecutionLog>> GetByTargetId(
        Guid targetId,
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
        int page,
        int pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var skipAmount = (page - 1) * pageSize;
        return await _dbSet
<<<<<<< HEAD
            .Where(r => r.DeviceId == deviceId)
=======
            .Where(r => r.TargetId == targetId)
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
            .Skip(skipAmount)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<RoutineExecutionLog>> GetByUserId(
        Guid userId,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var skipAmount = (page - 1) * pageSize;
        return await _dbSet
            .Where(r => r.UserId == userId)
            .Skip(skipAmount)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<RoutineExecutionLog>> GetByRoutineId(
        Guid routineId,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var skipAmount = (page - 1) * pageSize;
        return await _dbSet
            .Where(r => r.RoutineId == routineId)
            .Skip(skipAmount)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}
