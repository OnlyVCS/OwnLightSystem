<<<<<<< HEAD
using System.Text.Json.Serialization;
using DeviceService.Domain.Enums;
using MediatR;

namespace DeviceService.Application.Features.DeviceAction.Commands;

public class ControlDeviceCommand(Guid deviceId, DeviceStatus status) : IRequest
{
    [JsonIgnore]
    public Guid DeviceId { get; set; } = deviceId;

    [JsonIgnore]
    public Guid UserId { get; set; }
    public DeviceStatus Status { get; set; } = status;
}
=======
using System.Text.Json.Serialization;
using DeviceService.Domain.Enums;
using MediatR;

namespace DeviceService.Application.Features.DeviceAction.Commands;

public class ControlDeviceCommand(Guid deviceId, DeviceStatus status) : IRequest
{
    [JsonIgnore]
    public Guid DeviceId { get; set; } = deviceId;

    [JsonIgnore]
    public Guid UserId { get; set; }
    public DeviceStatus Status { get; set; } = status;
}
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
