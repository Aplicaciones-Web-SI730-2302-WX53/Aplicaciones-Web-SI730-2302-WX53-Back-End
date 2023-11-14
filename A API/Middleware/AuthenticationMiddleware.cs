using Data;
using Domain;

namespace Learnin_center_xw53.Middleware;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    
    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Autenticación
    /// </summary>
    /// <param name="context"></param>
    /// <param name="tokenDomain"></param>
    /// <param name="userDomain"></param>
    public async Task Invoke(HttpContext context, ITokenDomain tokenDomain, IUserData userDomain)
    {
        //Autenticación
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var username = tokenDomain.ValidateJwt(token);

        if (username != null)
        {
            context.Items["User"] = await userDomain.GetByUsername(username);
        }
        
        await _next(context);
    }
}