using MediatR;
using Microsoft.AspNetCore.Http;
using UserService.Application.Common.Services.Messages;
using UserService.Application.Common.Services.Token;
using UserService.Application.Features.Authentication.Command;
using UserService.Domain.Interfaces;

namespace UserService.Application.Features.Authentication.Handlers;

public class RefreshTokenCommandHandler(
    IRefreshTokenRepository refreshTokenRepository,
    IUserRepository userRepository,
    ITokenService tokenService,
<<<<<<< HEAD
    IMessageService messageService,
    IHttpContextAccessor httpContextAccessor
=======
    IMessageService messageService
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
) : IRequestHandler<RefreshTokenCommand, Message>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IMessageService _messageService = messageService;
<<<<<<< HEAD
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
=======
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396

    public async Task<Message> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken
    )
    {
<<<<<<< HEAD
        var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["RefreshToken"];

        if (string.IsNullOrEmpty(refreshToken))
            return _messageService.CreateNotAuthorizedMessage("Refresh token não encontrado.");

        var tokenInDb = await _refreshTokenRepository.GetTokenAsync(refreshToken);

        if (tokenInDb == null || tokenInDb.IsExpired() || tokenInDb.IsRevoked == true)
            return _messageService.CreateNotAuthorizedMessage(
                "Token inválido, expirado ou revogado."
            );

        var user = await _userRepository.FindByIdAsync(tokenInDb.UserId);
        if (user == null)
            return _messageService.CreateNotFoundMessage("Usuário não encontrado.");
=======
        var user =
            await _userRepository.FindByIdAsync(request.UserId)
            ?? return _messageService.CreateNotFoundMessage("Usuário não encontrado.");

        var tokenInDb = await _refreshTokenRepository.GetUserTokenAsync(user.Id);

        if (tokenInDb == null || tokenInDb.IsExpired() || tokenInDb.IsRevoked == true)
            return _messageService.CreateNotAuthorizedMessage("Token inválido.");
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396

        var newAccessToken = _tokenService.GenerateToken(user);

        return _messageService.CreateLoginMessage(
            "Access token atualizado com sucesso.",
            newAccessToken
        );
    }
}
