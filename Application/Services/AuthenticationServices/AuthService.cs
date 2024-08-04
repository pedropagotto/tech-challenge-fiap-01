using Application.Models.Authentication;
using Application.Services.UserServices;
using Infra;

namespace Application.Services.AuthenticationServices;

public class AuthService: IAuthService
{
    private readonly AppDbContext _context;
    private readonly IUserService _userService;

    public AuthService(AppDbContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public RegisterModel Register(RegisterModel reg)
    {
        _userService.Create(reg);

        return reg;
    }
}