using System;
using System.Linq;
using System.Security.Claims;
using API.Constants;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DebugAuthController : ControllerBase  // NOT BaseApiController
{
    [HttpGet("anon")]
    [AllowAnonymous]
    public ActionResult Anon()
    {
        return Ok(new
        {
            Message = "Anonymous endpoint reached",
            IsAuthenticated = User.Identity?.IsAuthenticated,
            AuthenticationType = User.Identity?.AuthenticationType,
            Claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList(),
            HasAuthHeader = Request.Headers.ContainsKey("Authorization"),
        });
    }

    [HttpGet("basic-auth")]
    [Authorize]
    public ActionResult BasicAuth()
    {
        return Ok(new
        {
            Message = "Basic authorize endpoint reached",
            IsAuthenticated = User.Identity?.IsAuthenticated,
            AuthenticationType = User.Identity?.AuthenticationType,
            Claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList(),
        });
    }

    [HttpGet("admin-policy")]
    [Authorize(Policy = PolicyGroups.AdminPolicy)]
    public ActionResult AdminPolicy()
    {
        return Ok(new
        {
            Message = "Admin policy endpoint reached",
            IsAuthenticated = User.Identity?.IsAuthenticated,
            AuthenticationType = User.Identity?.AuthenticationType,
            Claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList(),
        });
    }

    [HttpGet("manual-check")]
    [Authorize]
    public ActionResult ManualCheck()
    {
        var identity = User.Identity as ClaimsIdentity;

        return Ok(new
        {
            IsInRole_Admin = User.IsInRole("Admin"),
            HasClaim_ClaimTypesRole = User.HasClaim(ClaimTypes.Role, "Admin"),
            HasClaim_ShortRole = User.HasClaim("role", "Admin"),
            AllRoleClaims = User.Claims
                .Where(c => c.Type == ClaimTypes.Role || c.Type == "role")
                .Select(c => new { c.Type, c.Value })
                .ToList(),
            IdentityRoleClaimType = identity?.RoleClaimType,
            IdentityAuthenticationType = identity?.AuthenticationType,
            IdentityLabel = identity?.Label,

            // Add these
            HasOidcCookie = Request.Cookies.ContainsKey(OidcService.CookieName),
            AllCookieNames = Request.Cookies.Keys.ToList(),
            HasAuthHeader = Request.Headers.ContainsKey("Authorization"),
            AuthHeaderValue = Request.Headers.Authorization.ToString().Substring(0, Math.Min(20, Request.Headers.Authorization.ToString().Length)) + "..."
        });
    }
}
