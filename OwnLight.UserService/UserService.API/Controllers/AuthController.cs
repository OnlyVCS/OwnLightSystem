<<<<<<< HEAD
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Features.Authentication.Command;

namespace UserService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.StatusCode == StatusCodes.Status200OK.ToString())
            return Ok(result);
        else if (result.StatusCode == StatusCodes.Status401Unauthorized.ToString())
            return Unauthorized(result);
        else if (result.StatusCode == StatusCodes.Status404NotFound.ToString())
            return NotFound(result);
        else
            return BadRequest(result);
    }

    [Authorize]
    [HttpPost]
    [Route("logout/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Logout([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new LogoutCommand(id));
        if (result.StatusCode == StatusCodes.Status200OK.ToString())
            return Ok(result);
        else
            return BadRequest(result);
    }

    [Authorize]
    [HttpGet]
    [Route("current_user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetCurrentUser()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized(
                new
                {
                    StatusCode = StatusCodes.Status401Unauthorized.ToString(),
                    Message = "Nenhum usuário autenticado neste contexto.",
                }
            );
        var userId = Guid.Parse(userIdClaim.Value);
        return Ok(new { Id = userId });
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("refresh_token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RefreshToken()
    {
        // Verifica se o header Authorization existe e tem pelo menos duas partes
        var authorizationHeader = Request.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            return Unauthorized(new { message = "Authorization header is missing or invalid" });

        var tokenParts = authorizationHeader.Split(" ");
        if (tokenParts.Length < 2)
            return Unauthorized(new { message = "Invalid authorization format" });

        var command = new RefreshTokenCommand { RefreshToken = tokenParts[1] };
        var result = await _mediator.Send(command);

        if (result.StatusCode == StatusCodes.Status200OK.ToString())
            return Ok(result);
        else if (result.StatusCode == StatusCodes.Status401Unauthorized.ToString())
            return Unauthorized(result);
        else
            return NotFound(result);
    }
}
=======
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Features.Authentication.Command;

namespace UserService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.StatusCode == StatusCodes.Status200OK.ToString())
            return Ok(result);
        else if (result.StatusCode == StatusCodes.Status401Unauthorized.ToString())
            return Unauthorized(result);
        else if (result.StatusCode == StatusCodes.Status404NotFound.ToString())
            return NotFound(result);
        else
            return BadRequest(result);
    }

    [Authorize]
    [HttpPost]
    [Route("logout/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Logout([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new LogoutCommand(id));
        if (result.StatusCode == StatusCodes.Status200OK.ToString())
            return Ok(result);
        else
            return BadRequest(result);
    }

    [Authorize]
    [HttpGet]
    [Route("current_user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetCurrentUser()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized(
                new
                {
                    StatusCode = StatusCodes.Status401Unauthorized.ToString(),
                    Message = "Nenhum usuário autenticado neste contexto.",
                }
            );
        var userId = Guid.Parse(userIdClaim.Value);
        return Ok(new { Id = userId });
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("refresh_token/{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RefreshToken([FromRoute] Guid userId)
    {
        var result = await _mediator.Send(new RefreshTokenCommand(userId));

        if (result.StatusCode == StatusCodes.Status404NotFound.ToString())
            return NotFound(result);
        if (result.StatusCode == StatusCodes.Status401Unauthorized.ToString())
            return Unauthorized(result);

        return Ok(result);
    }
}
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
