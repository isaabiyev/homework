using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ConsoleApp1
{
    public interface IRepository<User>
    {
        void Add(User user);
        void Delete(User user);
        IEnumerable<User> GetAll();
    }

    public interface IUserService
    {
        string Register(string email, string password);
        string Login(string email, string password);
        string ChangePassword(string email, string oldPassword, string newPassword);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public string Register(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login))
            {
                return "EmailIsNull";
            }
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                return "PasswordIsNull";
            }
            try
            {
                var email = new MailAddress(login);
            }
            catch
            {
                return "InvalidEmail";
            }
            if (password.Length < 6)
            {
                return "PasswordTooShort";
            }
            if (_userRepository.GetAll().FirstOrDefault(u => u.Login == login) != null)
            {
                return "UserAlreadyExists";
            }
            var user = new User();
            user.Login = login;
            user.Password = password;
            _userRepository.Add(user);
            return "OK";
        }

        public string Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login))
            {
                return "EmailIsNull";
            }
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                return "PasswordIsNull";
            }
            try
            {
                var email = new MailAddress(login);
            }
            catch
            {
                return "InvalidEmail";
            }
            if (password.Length < 6)
            {
                return "PasswordTooShort";
            }
            if (_userRepository.GetAll().FirstOrDefault(u => u.Login == login) == null)
            {
                return "UserNotFound";
            }
            if (_userRepository.GetAll().FirstOrDefault(u => u.Login == login && u.Password == password) == null)
            {
                return "PasswordIsNotCorrect";
            }
            return "OK";
        }

        public string ChangePassword(string login, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login))
            {
                return "EmailIsNull";
            }
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrWhiteSpace(oldPassword))
            {
                return "OldPasswordIsNull";
            }
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                return "NewPasswordIsNull";
            }
            try
            {
                var email = new MailAddress(login);
            }
            catch
            {
                return "InvalidEmail";
            }
            if (oldPassword.Length < 6)
            {
                return "OldPasswordTooShort";
            }
            if (newPassword.Length < 6)
            {
                return "NewPasswordTooShort";
            }
            if (string.Equals(oldPassword, newPassword))
            {
                return "NewPasswordEqualsToOldPassword";
            }
            if (_userRepository.GetAll().FirstOrDefault(u => u.Login == login) == null)
            {
                return "UserNotFound";
            }
            if (_userRepository.GetAll().FirstOrDefault(u => u.Login == login && u.Password == oldPassword) == null)
            {
                return "OldPasswordIsNotCorrect";
            }
            var oldUser = _userRepository.GetAll().FirstOrDefault(u => u.Login == login && u.Password == oldPassword);
            _userRepository.Delete(oldUser);
            var newUser = new User();
            newUser.Login = login;
            newUser.Password = newPassword;
            _userRepository.Add(newUser);
            return "OK";
        }
    }
}