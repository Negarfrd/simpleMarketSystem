namespace Service;

public interface IUserService
{
    public string Login(string username, string password);
    public string Signup(string username, string password);
    public string ChangeUsername(string username, string newUsername);
    public string ChangePassword(string oldPassword, string newPassword);
}