using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserList.Api.Models;
using UserList.Api.Services;

namespace UserList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> All()
        {
            _logger.LogInformation("Request for all users");
            return _userService.GetAll();
        }

        [HttpGet("Search/")]
        public IEnumerable<User> Search(string familyName)
        {
            _logger.LogInformation("Request for users with family name {familyName}", familyName);
            return _userService.Search(familyName);
        }
    }
}