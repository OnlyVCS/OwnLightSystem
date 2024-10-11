namespace AutomationService.Domain.Entities;

public class Room
{
<<<<<<< HEAD
    public Guid Id { get; set; }
=======
    public Guid Id { get; set; } = Guid.NewGuid();
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

    public ICollection<Guid> DeviceIds { get; set; } = [];
}
