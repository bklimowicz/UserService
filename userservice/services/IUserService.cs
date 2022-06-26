using userservice.model;

public interface IUserService
{
    User CreateUser(User user);
    User? GetUserByEmail(string email);
    User? GetUserById(int id);
    User? GetUserByName(string name);
}