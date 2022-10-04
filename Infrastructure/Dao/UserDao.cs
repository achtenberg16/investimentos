using infrastructure.Entities;
using infrastructure.interfaces;

namespace infrastructure.Dao;

public class UserDao : IUserDao
{
    private readonly Context.Context _context;

    public UserDao(Context.Context context)
    {
        _context = context;
    }

    public User? FindUser(User userInfos)
    {
        var user = _context.Users.First(u => u.Email == userInfos.Email && u.Password == userInfos.Password);
        return user;
    }
}