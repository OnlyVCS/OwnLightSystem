using AutoMapper;
using AutomationService.Application.DTOs;
using AutomationService.Application.Features.Room.Queries;
using AutomationService.Domain.Interfaces;
using MediatR;

namespace AutomationService.Application.Features.Room.Handlers.Queries;

public class GetRoomByIdQueryHandler(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<GetRoomByIdQuery, RoomResponseDTO>
{
    private readonly IRoomRepository _roomRepository = roomRepository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<RoomResponseDTO> Handle(
        GetRoomByIdQueryHandler request,
        CancellationToken cancellationToken
    )
    {
        var room = 
            await _routineRepository.GetByIdAsync(request.Id)
            ?? throw new Exception("Room not found");

        return _mapper.Map<RoomResponseDTO>(room);
    }
}