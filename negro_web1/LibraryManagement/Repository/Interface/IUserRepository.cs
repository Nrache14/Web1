using System;
using LibraryManagement.Entities;

namespace LibraryManagement.UserRepository.Interface;

public interface IUserRepository
{
    public User GetUser(Guid userid);
    public User AddUser(User user);
    public User UpdateUser(Guid userid, User updatedUser);
    public void DeleteUser(Guid UserId);

}
