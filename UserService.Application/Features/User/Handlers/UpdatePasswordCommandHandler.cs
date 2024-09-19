using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using UserService.Application.Common.Services.Auth;
using UserService.Application.Common.Services.Messages;
using UserService.Application.Features.User.Commands;
using UserService.Domain.Interfaces;
using Entity = UserService.Domain.Entities;

namespace UserService.Application.Features.User.Handlers;

public class UpdatePasswordCommandHandler(
    IUserRepository userRepository,
    IAuthRepository authRepository,
    IValidator<UpdatePasswordCommand> validator,
    IMessageService messageService
) : IRequestHandler<UpdatePasswordCommand, Message>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IAuthRepository _authRepository = authRepository;
    private readonly IValidator<UpdatePasswordCommand> validator = validator;
    private readonly IMessageService _messageService = messageService;

    public async Task<Message> Handle(
        UpdatePasswordCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = await _userRepository.FindByIdAsync(request.Id);

        if (user == null)
            return _messageService.CreateNotFoundMessage("user not found");

        var authResult = AuthServices.Authenticate(user);
        if (authResult.StatusCode != StatusCodes.Status200OK.ToString())
            return authResult;

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return _messageService.CreateValidationMessage(
                validationResult.Errors.Select(e => e.ErrorMessage)
            );

        var passwordHasher = new PasswordHasher<Entity.User>();
        var passwordVerificationResult = passwordHasher.VerifyHashedPassword(
            user,
            user.Password,
            request.CurrentPassword
        );
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
            return _messageService.CreateBadRequestMessage("current password is incorrect");
            
        if (request.CurrentPassword == request.NewPassword)
            return _messageService.CreateBadRequestMessage(
                "new password cannot be the same as the current password"
            );

        request.NewPassword = passwordHasher.HashPassword(user, request.NewPassword);
        await _userRepository.UpdatePasswordAsync(user.Id, request.NewPassword);
        await _authRepository.LogoutAsync(user.Id);

        return _messageService.CreateSuccessMessage("password updated successfully");
    }
}
