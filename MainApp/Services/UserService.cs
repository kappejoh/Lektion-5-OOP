using MainApp.Models;
using System.Diagnostics;

namespace MainApp.Services;

public class UserService
{
    private List<User> _users = [];

    public ServiceRespons CreateUser(User user)
    {
        try
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                return new ServiceRespons { Succeded = false, Message = "No e-mail address was provided" };
            }

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                return new ServiceRespons { Succeded = false, Message = "First name and last name must be provided" };
            }

            if (_users.Any(x => x.Email == user.Email))
            {
                return new ServiceRespons { Succeded = false, Message = "User with the same e-mail address already exists" };
            }

            _users.Add(user);
            return new ServiceRespons { Succeded = false, Message = "User was created" };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new ServiceRespons { Succeded = false, Message = ex.Message };
        }      
    }

    public IEnumerable<User> GetAllUsers()
    {
        try
        {
            return _users;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
}
