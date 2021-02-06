using EpsicBlogBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EpsicBlogBackend.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTests : ApiControllerTestBase
    {
        private string defaultPass = "Asdf1234.";

        [TestMethod]
        public async Task GetAll()
        {
            // Arrange

            // Act
            var response = await GetAsync<List<User>>("/users");

            // Assert
            Assert.AreEqual(3, response.Count);
        }

        [TestMethod]
        public async Task GetSubzero()
        {
            // Arrange

            // Act
            var response = await GetAsync("/users/-1");

            // Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (int)response.StatusCode);
        }

        [TestMethod]
        public async Task GetNotExists()
        {
            // Arrange

            // Act
            var response = await GetAsync("/users/42069");

            // Assert
            Assert.AreEqual(StatusCodes.Status404NotFound, (int)response.StatusCode);
        }

        [TestMethod]
        public async Task Add()
        {
            // Arrange
            var model = new User { Username = "Test", Password = defaultPass, Passconf = defaultPass };

            // Act
            var response = await PostAsync("/users", model);

            // Assert
            Assert.AreEqual("Test", response.Username);
        }

        [TestMethod]
        public async Task AddAlreadyExists()
        {
            // Arrange
            var model = new User { Username = "Yannis", Password = defaultPass, Passconf = defaultPass };

            // Act
            var response = await PostBasicAsync("/users", model);

            // Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (int)response.StatusCode);
        }

        [TestMethod]
        public async Task Delete()
        {
            // Arrange

            // Act
            await DeleteAsync("/users/1");
            var response = await GetAsync<List<User>>("/users");

            // Assert
            Assert.AreEqual(2, response.Count);
        }

        [TestMethod]
        public async Task CheckPassword()
        {
            // Arrange
            var modelUpdate = new UserUpdateViewModel { Password = defaultPass, Passconf = defaultPass };
            var modelCheck = new UserCheckPasswordViewModel { Username = "Yannis", Password = defaultPass };

            // Act
            await PostAsync("/users/1", modelUpdate);
            var response = await PostBasicAsync("/users/check_password", modelCheck);

            // Assert
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        [TestMethod]
        public async Task WrongPassword()
        {
            // Arrange
            var modelUpdate = new UserUpdateViewModel { Password = defaultPass, Passconf = defaultPass };
            var modelCheck = new UserCheckPasswordViewModel { Username = "Yannis", Password = defaultPass + "-wrong" };

            // Act
            await PostAsync("/users/1", modelUpdate);
            var response = await PostBasicAsync("/users/check_password", modelCheck);

            // Assert
            Assert.AreEqual(StatusCodes.Status403Forbidden, (int)response.StatusCode);
        }

        [TestMethod]
        public async Task WrongPassconf()
        {
            // Arrange
            var modelUpdate = new UserUpdateViewModel { Password = "Asdf1234.", Passconf = defaultPass + "-wrong" };

            // Act
            var response = await PostBasicAsync("/users/1", modelUpdate);

            // Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (int)response.StatusCode);
        }

        [TestMethod]
        public async Task SetAvatar()
        {
            //Arrange
            var file = File.ReadAllBytes("avatar.png");

            // Act
            var response = await PostFileAsync($"/users/1/avatar", file);

            // Assert
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);

            var responseGet = await (await GetAsync($"/users/1/avatar")).Content.ReadAsByteArrayAsync();
            Assert.IsTrue(responseGet.SequenceEqual(file));
        }
    }
}
