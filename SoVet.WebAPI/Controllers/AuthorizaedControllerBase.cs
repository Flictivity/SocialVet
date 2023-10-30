using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SoVet.WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public sealed class AuthorizedControllerBase : ControllerBase
{
}