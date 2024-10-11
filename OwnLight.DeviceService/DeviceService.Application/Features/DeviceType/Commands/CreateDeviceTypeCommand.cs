<<<<<<< HEAD
using System.Text.Json.Serialization;
using MediatR;

namespace DeviceService.Application.Features.DeviceType.Commands;

public class CreateDeviceTypeCommand : IRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string TypeName { get; set; } = null!;
}
=======
using System.Text.Json.Serialization;
using MediatR;

namespace DeviceService.Application.Features.DeviceType.Commands;

public class CreateDeviceTypeCommand : IRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string TypeName { get; set; } = null!;
}
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
