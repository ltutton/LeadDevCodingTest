using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserList.Api.Models;

namespace UserList.Api.Services
{
    public class EntityFrameworkUserService : IUserService
    {
        private readonly UserDbContext _userDb;

        public EntityFrameworkUserService(UserDbContext userDb)
        {
            _userDb = userDb;
        }

        public IReadOnlyList<User> GetAll()
        {
            return _userDb.Users.AsEnumerable().ToList();
        }

        public IReadOnlyList<User> Search(string familyName)
        {
            if (string.IsNullOrEmpty(familyName))
            {
                return GetAll();
            }

            return _userDb.Users.Where(x => EF.Functions.Like(x.FamilyName, $"%{familyName}%")).AsEnumerable().ToList();
        }
    }
}