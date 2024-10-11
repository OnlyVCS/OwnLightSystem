using AutomationService.Domain.Enums;

namespace AutomationService.Domain.Entities;

public class Routine
{
<<<<<<< HEAD
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public TimeSpan ExecutionTime { get; set; }
    public RecurrencePattern RecurrencePattern { get; set; } = RecurrencePattern.Daily;
    public RoutineActionType ActionType { get; set; }

    public Guid? DeviceId { get; set; }
    public DeviceStatus DeviceStatus { get; set; }
=======
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public TimeSpan ExecutionTime { get; set; }
    public RoutineActionType ActionType { get; set; }

    public Guid? TargetId { get; set; }
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
    public int? Brightness { get; set; }
    public ActionTarget ActionTarget { get; set; }

    public ICollection<RoutineExecutionLog> ExecutionLogs { get; set; } = [];
}
