using System;
using LibraryManagement.Entities;
using LibraryManagement.UserRepository.Interface;

namespace LibraryManagement.Repository.Implementation;

public class UserRepository : IUserRepository
{
    private readonly List<User> Users = [];

    public User GetUser(Guid userid)
    {
        var user = Users.Find(u => u.UserId == userid);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {userid} not found.");
        }

        return user;
    }

    public User AddUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null");
        }

        Users.Add(user);
        return user;
    }

    public User UpdateUser(Guid userid, User updatedUser)
    {
        if (updatedUser == null)
        {
            throw new ArgumentNullException(nameof(updatedUser), "Updated user cannot be null");
        }

        var user = Users.FirstOrDefault(u => u.UserId == userid);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {userid} not found.");
        }

        user.UserName = updatedUser.UserName;
        user.Email = updatedUser.Email;
        user.Password = updatedUser.Password;
        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;

        return user;
    }

    public void DeleteUser(Guid UserId)
    {
        var user = Users.FirstOrDefault(u => u.UserId == UserId);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {UserId} not found.");
        }

        Users.Remove(user);
        Console.WriteLine($"User with ID {UserId} has been deleted.");
    }

    public List<User> GetUsers()
    {
        return Users;
    }
}
