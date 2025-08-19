using System;
using LibraryManagement.Entities;

namespace LibraryManagement.Logic.Interface
{
    public interface IUserLogic
    {
        public User GetUser(Guid userId);
        public User AddUser(User user);
        public User UpdateUser(Guid userId, User updatedUser);
        public void DeleteUser(Guid userId);
        public void LoginUser(string username, string password);
        public List<User> GetAllUsers();
    }
}