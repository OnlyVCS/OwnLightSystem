<<<<<<< HEAD
using MediatR;
using UserService.Application.Common.Services.Messages;

namespace UserService.Application.Features.User.Commands;

public class DeleteCommand(Guid id) : IRequest<Message>
{
    public Guid Id { get; set; } = id;
}
=======
using MediatR;
using UserService.Application.Common.Services.Messages;

namespace UserService.Application.Features.User.Commands;

public class DeleteCommand(Guid id) : IRequest<Message>
{
    public Guid Id { get; set; } = id;
}
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
