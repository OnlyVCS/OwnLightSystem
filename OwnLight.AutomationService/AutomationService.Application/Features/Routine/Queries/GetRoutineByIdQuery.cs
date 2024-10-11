<<<<<<< HEAD
using AutomationService.Application.DTOs;
using MediatR;

namespace AutomationService.Application.Features.Routine.Queries;

public class GetRoutineByIdQuery : IRequest<RoutineResponseDTO>
{
    public Guid Id { get; set; }
=======
using MediatR;
using Entity = AutomationService.Domain.Entities;

namespace AutomationService.Application.Features.Routine.Queries;

public class GetRoutineByIdQuery(Guid id) : IRequest<Entity.Routine>
{
    public Guid Id { get; set; } = id;
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
}
