using ConsoleApp1;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApp2
{
    public class UserServiceTestClass
	{
        public IUserService UserService { get; }

        [Fact]
        public void UserServiceRegisterInvalidEmailFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "blablabla";
            var password = "password";
            var user = service.Register(login, password);
            Assert.Equal("InvalidEmail", user);
        }

        [Fact]
        public void UserServiceRegisterInvalidEmailOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Register(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceRegisterPasswordTooShortFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "passw";
            var user = service.Register(login, password);
            Assert.Equal("PasswordTooShort", user);
        }

        [Fact]
        public void UserServiceRegisterPasswordTooShortOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "passwo";
            var user = service.Register(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceRegisterEmailIsNullFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "";
            var password = "password";
            var user = service.Register(login, password);
            Assert.Equal("EmailIsNull", user);
        }

        [Fact]
        public void UserServiceRegisterEmailIsNullOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Register(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceRegisterPasswordIsNullFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "";
            var user = service.Register(login, password);
            Assert.Equal("PasswordIsNull", user);
        }

        [Fact]
        public void UserServiceRegisterPasswordIsNullOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Register(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceRegisterUserAlreadyExistsFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Register(login, password);
            Assert.Equal("UserAlreadyExists", user);
        }

        [Fact]
        public void UserServiceRegisterUserAlreadyExistsOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Register(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceLoginInvalidEmailFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "blablabla";
            var password = "password";
            var user = service.Login(login, password);
            Assert.Equal("InvalidEmail", user);
        }

        [Fact]
        public void UserServiceLoginInvalidEmailOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Login(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceLoginPasswordTooShortFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "passw";
            var user = service.Login(login, password);
            Assert.Equal("PasswordTooShort", user);
        }

        [Fact]
        public void UserServiceLoginPasswordTooShortOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Login(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceLoginEmailIsNullFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "";
            var password = "password";
            var user = service.Login(login, password);
            Assert.Equal("EmailIsNull", user);
        }

        [Fact]
        public void UserServiceLoginEmailIsNullOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Login(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceLoginPasswordIsNullFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "";
            var user = service.Login(login, password);
            Assert.Equal("PasswordIsNull", user);
        }

        [Fact]
        public void UserServiceLoginPasswordIsNullOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Login(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceLoginUserNotFoundFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Login(login, password);
            Assert.Equal("UserNotFound", user);
        }

        [Fact]
        public void UserServiceLoginUserNotFoundOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Login(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceLoginPasswordIsNotCorrectFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "wrongPassword";
            var user = service.Login(login, password);
            Assert.Equal("PasswordIsNotCorrect", user);
        }

        [Fact]
        public void UserServiceLoginPasswordIsNotCorrectOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "password"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var password = "password";
            var user = service.Login(login, password);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceChangePasswordInvalidEmailFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "blablabla";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("InvalidEmail", user);
        }

        [Fact]
        public void UserServiceChangePasswordInvalidEmailOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceChangePasswordOldPasswordTooShortFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPa";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OldPasswordTooShort", user);
        }

        [Fact]
        public void UserServiceChangePasswordOldPasswordTooShortOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceChangePasswordNewPasswordTooShortFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPa";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("NewPasswordTooShort", user);
        }

        [Fact]
        public void UserServiceChangePasswordNewPasswordTooShortOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceChangePasswordNewPasswordEqualsToOldPasswordFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "oldPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("NewPasswordEqualsToOldPassword", user);
        }

        [Fact]
        public void UserServiceChangePasswordNewPasswordEqualsToOldPasswordOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceChangePasswordEmailIsNullFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("EmailIsNull", user);
        }

        [Fact]
        public void UserServiceChangePasswordEmailIsNullOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceChangeOldPasswordIsNullFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OldPasswordIsNull", user);
        }

        [Fact]
        public void UserServiceChangeOldPasswordIsNullOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceChangeNewPasswordIsNullFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("NewPasswordIsNull", user);
        }

        [Fact]
        public void UserServiceChangeNewPasswordIsNullOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceChangeUserNotFoundFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("John", "Doe"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("UserNotFound", user);
        }

        [Fact]
        public void UserServiceChangeUserNotFoundOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OK", user);
        }

        [Fact]
        public void UserServiceChangeOldPasswordIsNotCorrectFailTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "wrongOldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OldPasswordIsNotCorrect", user);
        }

        [Fact]
        public void UserServiceChangeOldPasswordIsNotCorrectOkTest()
        {
            var repoMock = new Mock<IRepository<User>>();
            repoMock.Setup(m => m.GetAll())
                .Returns(() => new List<User>
                {
                    new User("isaabiyev@gmail.com", "oldPassword"),
                    new User("Steve", "Jobs"),
                    new User("Bill", "Gates"),
                });
            var service = new UserService(repoMock.Object);
            var login = "isaabiyev@gmail.com";
            var oldPassword = "oldPassword";
            var newPassword = "newPassword";
            var user = service.ChangePassword(login, oldPassword, newPassword);
            Assert.Equal("OK", user);
        }
    }
}
