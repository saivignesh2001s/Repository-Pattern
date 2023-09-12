using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using Repository_pattern.context;
using Repository_pattern.Controllers;
using Repository_pattern.Model;
using Repository_pattern.Repository;
using System.Net;
using System.Text.Json;

namespace RepositoryTesting
{

    public class UserTesting
    {

        private readonly Mock<IRepository<user>> _repository;

        public UserTesting()
        {


            _repository = new Mock<IRepository<user>>();





        }
        [Fact]
        public async void Get()
        {
            _repository.Setup(x => x.GetAllasync()).Returns(userlist());
            userController usercontroller = new userController(_repository.Object);

            var result = await usercontroller.Get();

            var resultData = result as OkObjectResult;

            // var t = JsonSerializer.Deserialize<Res>(result);
            Assert.NotNull(result);

            Assert.Equal(resultData?.StatusCode, 200);


        }
        [Fact]

        public async void GetById()
        {
            _repository.Setup(x => x.Find(1)).Returns(Get1());
            userController usercontroller = new userController(_repository.Object);
            var result = await usercontroller.Get(1);
            var resultData = result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(resultData?.StatusCode, 200);


        }
        [Fact]
        public async void Insert()
        {
            var k = GetUser();

            _repository.Setup(x => x.Addasync(k)).Returns(GetTrue());

            userController usercontroller = new userController(_repository.Object);
            var result = await usercontroller.Post(k);
            var resultData = result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(resultData?.StatusCode, 200);

        }
        [Fact]
        public async void Delete_success()
        {
            var k = await Get1();
            _repository.Setup(x => x.DeleteAsync(1)).Returns(GetTrue());
            userController usercontroller = new userController(_repository.Object);
            var result = await usercontroller.Delete(1);
            var resultData = result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(resultData?.StatusCode, 200);


        }

        public async Task<user> Get1()
        {
            return new user()
            {
                id = 1,
                username = "saivignesh",
                useremail = "sai@gmail.com",
                password = "abcd"
            };

        }
        public user GetUser()
        {
            user k = new user()
            {
                id = 3,
                username = "user",
                useremail = "user@gmail.com",
                password = "password"

            };
            return k;

        }
        public async Task<bool> GetTrue()
        {
            return true;
        }
        public async Task<List<user>> userlist()
        {
            return new List<user>{
                new user()
                {
                    id = 1,
                    username = "saivignesh",
                    useremail = "sai@gmail.com",
                    password = "abcd"
                },
                new user()
            {
                id = 10,
                username = "abirami",
                  useremail = "abirami@gmail.com",
                password = "abi@123"
            },
            new user()
            {
                id = 12,
                username = "saivignesh",
                useremail = "sai",
                password = "sai14012001"
            },
            new user()
            {   
                id= 533010933,
                username = "venkat",
                useremail = "v@gmail.com",
                password = "abcd"
            }
                




               };

        }
    }
}