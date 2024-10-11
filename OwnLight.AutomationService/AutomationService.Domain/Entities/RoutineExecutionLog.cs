using AutomationService.Domain.Enums;

namespace AutomationService.Domain.Entities;

public class RoutineExecutionLog
{
<<<<<<< HEAD
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DeviceId { get; set; }
=======
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid TargetId { get; set; }
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396

    public Guid RoutineId { get; set; }
    public Routine Routine { get; set; } = null!;

    public ActionTarget ActionTarget { get; set; }
    public ActionStatus ActionStatus { get; set; }
    public RoutineActionType ActionType { get; set; }
<<<<<<< HEAD
    
=======

>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
    public string ErrorMessage { get; set; } = string.Empty;
    public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;
}
