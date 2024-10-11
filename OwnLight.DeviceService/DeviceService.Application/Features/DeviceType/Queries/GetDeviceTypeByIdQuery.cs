<<<<<<< HEAD
using DeviceService.Application.DTOs;
using MediatR;

namespace DeviceService.Application.Features.DeviceType.Queries;

public class GetDeviceTypeByIdQuery(Guid id) : IRequest<DeviceTypeResponseDTO>
{
    public Guid Id { get; set; } = id;
}
=======
using DeviceService.Application.DTOs;
using MediatR;

namespace DeviceService.Application.Features.DeviceType.Queries;

public class GetDeviceTypeByIdQuery(Guid id) : IRequest<DeviceTypeResponseDTO>
{
    public Guid Id { get; set; } = id;
}
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
