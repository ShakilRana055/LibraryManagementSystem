using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.EntityModel;
using LibraryManagementSystem.RepositoryPattern.Interfaces.IUnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork context;
        public UserController(IUnitOfWork unitOfWork)
        {
            context = unitOfWork;
        }

        [HttpPost]
        [Route("FindUser")]
        public async Task<ActionResult<User>> GetUser(User user)
        {
            var getUser = await context.User.GetFirstOrDefault(item => item.Email == user.Email && item.Password == user.Password);
            if (getUser == null)
                return NotFound();
            return getUser;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await context.User.GetAll();
            return users.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (user == null)
                return BadRequest();
            User newUser = new User()
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                CreatedDate = System.DateTime.Now,
            };
            context.User.Save(newUser);
            await context.Save();
            return newUser;
        }
    }
}
