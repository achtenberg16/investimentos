using Application.Dto;
using Application.interfaces;
using infrastructure.Entities;
using infrastructure.interfaces;


namespace Application.services;

public class UsersService : IUsersService
{
    private readonly IUserDao _userDao;
    private readonly IJwtToken _jwtToken;
    public UsersService(IUserDao userDao, IJwtToken jwt)
    {
        _userDao = userDao;
        _jwtToken = jwt;
    }

    public string? Login(LoginDto loginInfos)
    {
        var user = new User(){Email = loginInfos.email, Password = loginInfos.password};
        var userFound = _userDao.FindUser(user);
        if (userFound is null) return null;
        var token = _jwtToken.Create(userFound.Id);
        return token;
    }
}