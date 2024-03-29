﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OnlineSchool.API.Controllers;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    protected string? GetUserId()
    {
        return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}