using MediatR;
using AutomationService.Application.DTOs;

namespace AutomationService.Application.Features.Room.Queries;

public class GetRoomByNameQuery : IRequest<RoomResponseDTO>
{
    public required string Name { get; set; }
}
