using Application.Dto;

namespace Application.interfaces;

public interface IUsersService
{
    public string? Login(LoginDto loginInfos);
}