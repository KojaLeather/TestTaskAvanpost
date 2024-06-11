using Microsoft.EntityFrameworkCore;
using Task.Connector.Data;
using Task.Connector.Data.Models;
using Task.Connector.Service;
using Task.Integration.Data.Models;
using Task.Integration.Data.Models.Models;

namespace Task.Connector
{
    public class ConnectorDb : IConnector
    {
        private ApplicationDbContext _context;
        public void StartUp(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            _context = new ApplicationDbContext(optionsBuilder.Options);
        }

        public void CreateUser(UserToCreate user)
        {
            User userToAdd = new User() { Login = user.Login };
            SetPropertiesService setPropertiesService = new SetPropertiesService();
            setPropertiesService.SetUserProperties(user.Properties, userToAdd);
            _context.User.Add(userToAdd);

            PasswordEntity password = new PasswordEntity() { Password = user.HashPassword, UserId = user.Login };
            _context.Passwords.Add(password);
            _context.SaveChanges();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProperty> GetUserProperties(string userLogin)
        {
            throw new NotImplementedException();
        }

        public bool IsUserExists(string userLogin)
        {
            return _context.User.Any(e => e.Login == userLogin);
        }

        public void UpdateUserProperties(IEnumerable<UserProperty> properties, string userLogin)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            throw new NotImplementedException();
        }

        public void AddUserPermissions(string userLogin, IEnumerable<string> rightIds)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserPermissions(string userLogin, IEnumerable<string> rightIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetUserPermissions(string userLogin)
        {
            throw new NotImplementedException();
        }

        public ILogger Logger { get; set; }
    }
}