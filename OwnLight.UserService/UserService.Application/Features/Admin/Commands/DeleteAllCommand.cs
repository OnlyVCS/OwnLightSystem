<<<<<<< HEAD
using MediatR;
using Entity = UserService.Domain.Entities;

namespace UserService.Application.Features.Admin.Commands;

public class DeleteAllCommand : IRequest
{
    public Guid AdminId { get; set; }
    public required string AdminPassword { get; set; }
}
=======
using MediatR;
using Entity = UserService.Domain.Entities;

namespace UserService.Application.Features.Admin.Commands;

public class DeleteAllCommand : IRequest
{
    public Guid AdminId { get; set; }
    public required string AdminPassword { get; set; }
}
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
