using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserList.Api.Models;
using UserList.Api.Services;
using Xunit;

namespace UserList.Api.Tests.Services
{
    public class EntityFrameworkUserServiceTests
    {
        private (UserDbContext, EntityFrameworkUserService) CreateUserContext()
        {
            var builder = new DbContextOptionsBuilder().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new UserDbContext(builder.Options);
            return (context, new EntityFrameworkUserService(context));
        }

        [Fact]
        public void TestGetAll()
        {
            var (context, userService) = CreateUserContext();
            using (context)
            {
                // arrange
                var userList = new List<User>
                {
                    new User
                    {
                        FamilyName = "Test",
                        FirstName = "User",
                        Username = "TestUser"
                    },
                    new User
                    {
                        FamilyName = "Test",
                        FirstName = "User 2",
                        Username = "TestUser2"
                    },
                };
                context.Users.AddRange(userList);
                context.SaveChanges();

                // act
                var allUsers = userService.GetAll();

                // assert
                Assert.Equal(userList, allUsers);
            }


        }

        [Fact]
        public void TestSearchBloggs()
        {
            var (context, userService) = CreateUserContext();
            using (context)
            {
                // arrange
                var userList = new List<User>
                {
                    new User
                    {
                        FamilyName = "Smith",
                        FirstName = "User",
                        Username = "TestUser"
                    },
                    new User
                    {
                        FamilyName = "Bloggs",
                        FirstName = "User 2",
                        Username = "TestUser2"
                    },
                };

                context.Users.AddRange(userList);
                context.SaveChanges();

                var expected = new[]
                {
                    userList[1]
                };

                // act
                var bloggsUsers = userService.Search("bloggs");

                // assert
                Assert.Equal(expected, bloggsUsers);
            }
        }


        [Fact]
        public void TestSearchNull()
        {
            var (context, userService) = CreateUserContext();
            using (context)
            {
                // arrange
                var userList = new List<User>
                {
                    new User
                    {
                        FamilyName = "Smith",
                        FirstName = "User",
                        Username = "TestUser"
                    },
                    new User
                    {
                        FamilyName = "Bloggs",
                        FirstName = "User 2",
                        Username = "TestUser2"
                    },
                };

                context.Users.AddRange(userList);
                context.SaveChanges();


                // act
                var searchUsers = userService.Search(null);

                // assert
                Assert.Equal(userList, searchUsers);
            }
        }


        [Fact]
        public void TestSearchNonExistant()
        {
            var (context, userService) = CreateUserContext();
            using (context)
            {
                // arrange
                var userList = new List<User>
                {
                    new User
                    {
                        FamilyName = "Smith",
                        FirstName = "User",
                        Username = "TestUser"
                    },
                    new User
                    {
                        FamilyName = "Bloggs",
                        FirstName = "User 2",
                        Username = "TestUser2"
                    },
                };

                context.Users.AddRange(userList);
                context.SaveChanges();


                // act
                var searchUsers = userService.Search("Collins");

                // assert
                Assert.Equal(Enumerable.Empty<User>(), searchUsers);
            }
        }
    }

}