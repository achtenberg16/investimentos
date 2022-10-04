using infrastructure.Entities;

namespace infrastructure.interfaces;

public interface IUserDao
{
    public User? FindUser(User userInfos);
}