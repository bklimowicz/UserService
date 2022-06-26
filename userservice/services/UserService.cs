using userservice.database;
using userservice.model;

public class UserService : IUserService
{
    private UserContext _context { get; }

    public UserService(UserContext context)
    {
        this._context = context;

    }
    public User CreateUser(User user)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        this._context.User.Add(user);

        this._context.SaveChanges();

        return user;
    }

    public User? GetUserById(int id) => this._context.User.FirstOrDefault(_user => _user.Id == id);

    public User? GetUserByName(string name) => this._context.User.FirstOrDefault(_user => _user.Name == name);

    public User? GetUserByEmail(string email) => this._context.User.FirstOrDefault(_user => _user.Email == email);
}