namespace infrastructure.interfaces;

public interface IJwtToken
{
    public string Create(int userId);
}