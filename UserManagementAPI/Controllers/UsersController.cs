using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new List<User>
        {
        new User { Id = 1, Name = "علی رضایی", Age = 25, UserName = "ali_r" },
        new User { Id = 2, Name = "مریم احمدی", Age = 30, UserName = "m_ahmadi" },
        new User { Id = 3, Name = "رضا کریمی", Age = 28, UserName = "reza_k" },
        new User { Id = 4, Name = "سارا محمدی", Age = 22, UserName = "s_mohammadi" }
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_users);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            if (newUser == null || string.IsNullOrWhiteSpace(newUser.Name) || string.IsNullOrWhiteSpace(newUser.UserName))
            {
                return BadRequest("اطلاعات کاربر نامعتبر است.");
            }

            int newId = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            newUser.Id = newId;

            _users.Add(newUser);

            return CreatedAtAction(nameof(GetUsers), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (updatedUser == null || string.IsNullOrWhiteSpace(updatedUser.Name) || string.IsNullOrWhiteSpace(updatedUser.UserName))
            {
                return BadRequest("اطلاعات کاربر نامعتبر است.");
            }

            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound($"کاربر با شناسه {id} یافت نشد.");
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Age = updatedUser.Age;
            existingUser.UserName = updatedUser.UserName;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound($"کاربر با شناسه {id} یافت نشد.");
            }

            _users.Remove(existingUser);

            return NoContent();
        }
    }

}
