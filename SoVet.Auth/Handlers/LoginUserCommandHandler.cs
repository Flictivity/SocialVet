using MediatR;
using Microsoft.AspNetCore.Identity;
using SoVet.Auth.Models;
using SoVet.Domain.Commands.Token;
using SoVet.Domain.Commands.User;
using SoVet.Domain.ErrorMessages;
using SoVet.Domain.Responses.Authorization;

namespace SoVet.Auth.Handlers;

public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthorizationResponse>
{
    private readonly UserManager<ClinicUser> _userManager;
    private readonly SignInManager<ClinicUser> _signInManager;
    private readonly ISender _sender;

    public LoginUserCommandHandler(UserManager<ClinicUser> userManager, SignInManager<ClinicUser> signInManager,
        ISender sender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _sender = sender;
    }

    public async Task<AuthorizationResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
            return new AuthorizationResponse { IsSuccess = false, Message = UserErrorMessages.UserNotFound };

        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!signInResult.Succeeded)
            return new AuthorizationResponse { IsSuccess = false, Message = UserErrorMessages.UserWrongPassword };

        return new AuthorizationResponse
        {
            IsSuccess = true,
            Token = await _sender.Send(new GenerateTokenCommand(request.Email, user.Id), cancellationToken)
        };
    }
}