using DotNetHW2;
using Service;

namespace ServiceTest;

public class UserServiceTest
{
    private UserService _sut;

    public UserServiceTest()
    {
        _sut = UserService.GetUserService();
    }

    [Fact]
    public void LoginTest()
    {
        //Arrange
        var user = new User("testName", "testPassword");
        var dataBase = DataBase.GetDatabase();
        dataBase.GetUsers().Add(user);

        //Act
        _sut.Login("testName", "testPassword");

        //Assert
        Assert.Equal(_sut.GetUser(), user);
    }

    [Fact]
    public void SignUpTest()
    {
        //Arrange
        var user = new User("testName", "testPassword");
        var dataBase = DataBase.GetDatabase();

        //Act
        _sut.Signup("testName", "testPassword");

        //Assert
        Assert.Equal(_sut.GetUser().Username, user.Username);
    }

    [Fact]
    public void ChangePasswordTest()
    {
        //Arrange
        var user = new User("testName", "testPassword");
        var dataBase = DataBase.GetDatabase();
        dataBase.GetUsers().Add(user);
        string newPassword = "newPassword";

        //Act
        _sut.ChangePassword(user.Password, newPassword);

        //Assert
        Assert.Equal(user.Password, newPassword);
    }

    [Fact]
    public void ChangeUsernameTest()
    {
        //Arrange
        var user = new User("testName", "testPassword");
        var dataBase = DataBase.GetDatabase();
        dataBase.GetUsers().Add(user);
        string newUsername = "newUsername";

        //Act
        _sut.ChangeUsername(user.Username, newUsername);

        //Assert
        Assert.Equal(user.Username, newUsername);
    }
}