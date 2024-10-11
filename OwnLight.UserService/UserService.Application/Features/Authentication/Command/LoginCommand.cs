<<<<<<< HEAD
using System;
using MediatR;
using UserService.Application.Common.Services.Messages;

namespace UserService.Application.Features.Authentication.Command;

public class LoginCommand(string username, string password) : IRequest<Message>
{
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
}
=======
using System;
using MediatR;
using UserService.Application.Common.Services.Messages;

namespace UserService.Application.Features.Authentication.Command;

public class LoginCommand(string username, string password) : IRequest<Message>
{
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
}
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
