using AutoMapper;
using AutomationService.Application.DTOs;
using AutomationService.Application.Features.Routine.Queries;
using AutomationService.Domain.Interfaces;
using MediatR;

namespace AutomationService.Application.Features.Room.Handlers.Queries;

public class GetRoomByNameQueryHandler(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<GetRoomByNameQuery, RoomResponseDTO>
{
    private readonly IRoomRepository _roomRepository = roomRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<RoutineResponseDTO> Handle(
        GetRoomByNameQuery request,
        CancellationToken cancellationToken
    )
    {
        var room =
            await _roomRepository.GetRoomByNameAsync(request.Name, cancellationToken)
            ?? throw new Exception("Room not found");

        return _mapper.Map<RoomResponseDTO>(room);
    }
}
