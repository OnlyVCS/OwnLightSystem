using System.Text.Json.Serialization;
using MediatR;
using UserService.Application.Common.Services.Messages;

namespace UserService.Application.Features.Authentication.Command;

<<<<<<< HEAD
public class RefreshTokenCommand : IRequest<Message>
{
    [JsonIgnore]
    public string RefreshToken { get; set; } = string.Empty;
=======
public class RefreshTokenCommand(Guid userId) : IRequest<Message>
{
    [JsonIgnore]
    public Guid UserId { get; set; } = userId;
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
}
