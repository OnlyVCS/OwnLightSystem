using AutoMapper;
using DeviceService.Application.DTOs;
using DeviceService.Application.Features.Device.Queries;
using DeviceService.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DeviceService.Application.Features.Device.Handlers.QueryHandlers;

public class GetUserDevicesByRoomIdQueryHandler(
    IDeviceRepository deviceRepository,
    IMapper mapper,
    IHttpContextAccessor httpContextAccessor
) : IRequestHandler<GetUserDevicesByRoomIdQuery, PaginatedResultDTO<UserResponseDTO>>
{
    private readonly IDeviceRepository _deviceRepository = deviceRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public async Task<PaginatedResultDTO<UserResponseDTO>> Handle(
        GetUserDevicesByRoomIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var userId = _httpContextAccessor.HttpContext?.Items["UserId"]?.ToString();
        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException("Usuário não autenticado.");

        if (request.RoomId == Guid.Empty)
            throw new ArgumentException("RoomId Inválido ou não encontrado.");

        var devices = await _deviceRepository.GetUserDevicesByRoomIdAsync(
            Guid.Parse(userId),
            request.RoomId,
            request.PageNumber,
            request.PageSize
        );
        var devicesDTO = _mapper.Map<IEnumerable<UserResponseDTO>>(devices);

        return new PaginatedResultDTO<UserResponseDTO>(
            devicesDTO.Count(),
            request.PageNumber,
            request.PageSize,
            devicesDTO
        );
    }
}
