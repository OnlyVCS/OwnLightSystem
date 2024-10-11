<<<<<<< HEAD
using DeviceService.Application.DTOs;
using MediatR;

namespace DeviceService.Application.Features.DeviceType.Queries;

public class GetAllDeviceTypesQuery(int page, int pageSize) : IRequest<PaginatedResultDTO<DeviceTypeResponseDTO>>
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
}
=======
using DeviceService.Application.DTOs;
using MediatR;

namespace DeviceService.Application.Features.DeviceType.Queries;

public class GetAllDeviceTypesQuery(int page, int pageSize) : IRequest<PaginatedResultDTO<DeviceTypeResponseDTO>>
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
}
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
