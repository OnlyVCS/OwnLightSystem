namespace AutomationService.Application.DTOs;

public class RoomResponseDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Name { get; set; }
    public required bool IsHomeRoom { get; set; }
    public ICollection<Guid>? DeviceIds { get; set; } // Ta certo?
}
