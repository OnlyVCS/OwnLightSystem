using AutomationService.Application.DTOs;
using MediatR;

namespace AutomationService.Application.Features.Room.Queries;
public class GetRoomByIdQuery : IRequest<RoomResponseDTO>
{
    public Guid Id { get; set; }
}