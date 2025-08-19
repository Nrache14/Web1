using LibraryManagement.Entities;
using LibraryManagement.Logic.Interface;
using LibraryManagement.UserRepository.Interface;
// Add the correct namespace for IUserRepository if it's different

namespace LibraryManagement.Logic.Implementation
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepo;

        public UserLogic(IUserRepository userRepo)
        {
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        public User GetUser(Guid userId)
        {
            // Add business logic if needed
            return _userRepo.GetUser(userId);
        }

        public User AddUser(User user)
        {
            // Add business logic if needed
            return _userRepo.AddUser(user);
        }

        public User UpdateUser(Guid userId, User updatedUser)
        {
            // Add business logic if needed
            return _userRepo.UpdateUser(userId, updatedUser);
        }

        public void DeleteUser(Guid userId)
        {
            // Add business logic if needed
            _userRepo.DeleteUser(userId);
        }

        public List<User> GetAllUsers()
        {
            // Add business logic if needed
            return _userRepo.GetUsers();
        }

        public void LoginUser(string username, string password)
        {
            // Implement login logic here
            
            if (_userRepo.GetUsers() == null || !_userRepo.GetUsers().Any())
            {
                throw new InvalidOperationException("No users available for login.");
            }
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password cannot be null or empty.");
            }
            
            var user = _userRepo.GetUsers().FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }
                Console.WriteLine($"User {username} logged in successfully.");
            
            // Additional login logic can be added here, such as setting session data
        }
        
    }
}