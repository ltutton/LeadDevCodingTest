using System.Collections.Generic;
using UserList.Api.Models;

namespace UserList.Api.Services
{
    public interface IUserService
    {
        IReadOnlyList<User> GetAll();

        IReadOnlyList<User> Search(string familyName);
    }
}