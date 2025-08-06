using Microsoft.AspNetCore.Mvc;
using DietP.Core.Entities;
using DietP.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietP.Core.Services;
using Microsoft.AspNetCore.Identity.Data;

namespace DietP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] Dictionary<string, string> body)
        {
            if (body.TryGetValue("email", out var email) && body.TryGetValue("password", out var password))
            {
                // העבר את הערכים לפונקציה שלך
                var user = await _userService.login(email, password);
                return Ok(user);
            }

            return BadRequest("Email and password are required.");
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            var createdUser = await _userService.register(user);
            return CreatedAtAction(nameof(GetAllUsers), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("update")]
        public async Task<ActionResult<User>> UpdateUser(string firstName, string lastName, string email, string password, int calPerDay, float bmi,
            float weight, float wishWeight, float height, int daysForDiet,
            string newFirstName, string newLastName, string newEmail, string newPassword, int newCalPerDay, float newBmi,
            float newWeight, float newWishWeight, float newHeight, int newDaysForDiet)
        {
            try
            {
                var updatedUser = await _userService.UpdateUser(firstName, lastName, email, password, calPerDay, bmi, weight, wishWeight, height, daysForDiet,
                    newFirstName, newLastName, newEmail, newPassword, newCalPerDay, newBmi, newWeight, newWishWeight, newHeight, newDaysForDiet);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<User>> DeleteUser(string password, string email)
        {
            try
            {
                var deletedUser = await _userService.DeleteUser(password, email);
                return Ok(deletedUser);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
