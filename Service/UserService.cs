using DotNetHW2;

namespace Service;

public class UserService : IUserService
{
    private User? _user;
    private static UserService? _userService;

    private UserService()
    {
    }

    public static UserService GetUserService()
    {
        if (_userService is null)
        {
            _userService = new UserService();
        }

        return _userService;
    }

    public User? GetUser()
    {
        return _user;
    }

    public void SetUser(User? user)
    {
        _user = user;
    }

    public string Login(string username, string password)
    {
        foreach (User? user in DataBase.GetDatabase().GetUsers())
        {
            if (!user.Username.ToLower().Equals(username.ToLower())) continue;
            if (!user.Password.Equals(password)) return "invalid password";
            SetUser(user);
            return "logging in was successful";
        }

        return "user not found";
    }

    public string Signup(string username, string password)
    {
        foreach (User user in DataBase.GetDatabase().GetUsers())
        {
            if (user.Username.ToLower().Equals(username.ToLower())) continue;
            {
                return "this username is already taken";
            }
        }

        User? newUser = new User(username, password);
        SetUser(newUser);
        DataBase.GetDatabase().GetUsers().Add(newUser);
        return "signing up was successful";
    }

    public string ChangeUsername(string username, string newUsername)
    {
        foreach (User user in DataBase.GetDatabase().GetUsers())
        {
            if (!user.Username.ToLower().Equals(username.ToLower())) continue;
            user.Username = newUsername;
            return "changing username was successful";
        }

        return "user not found";
    }

    public string ChangePassword(string oldPassword, string newPassword)
    {
        foreach (User user in DataBase.GetDatabase().GetUsers())
        {
            if (user.Password.Equals(oldPassword))
            {
                user.Password = newPassword;
                return "changing password was successful";
            }
        }
        return "invalid password";
    }
}