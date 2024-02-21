
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;
using TravelDeskWebApi.ViewModel;

namespace TravelDeskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepo repo, ILogger<UserController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _repo.GetAllUsers();
                _logger.LogInformation("Retrieved all users successfully.");

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all users.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _repo.GetUser(id);

                if (user != null)
                    return Ok(user);
                else
                {
                    _logger.LogWarning("User with ID {UserId} not found.", id);
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving user by ID {UserId}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Active")]
        public IActionResult GetViewUsers()
        {
            try
            {
                var activeUsers = _repo.GetViewUsers();

                _logger.LogInformation("Retrieved all active users successfully.");

                return Ok(activeUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving active users.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {

                if (_repo.DeleteUser(id))
                {
                    _logger.LogInformation("User with ID {UserId} deleted successfully.", id);
                    return Ok();
                }
                else
                {
                    _logger.LogWarning("User with ID {UserId} not found for deletion.", id);
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting user with ID {UserId}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            try
            {
                var result = _repo.Adduser(user);
                if (result)
                {
                    _logger.LogInformation("User added successfully: {@User}", user);
                    return Ok();
                }
                else
                {
                    _logger.LogWarning("Failed to add user: {@User}", user);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding user: {@User}", user);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("checkemail")]
        public IActionResult CheckEmail(string email)
        {
            try
            {
                var isEmailUnique = _repo.CheckEmail(email);
                return Ok(isEmailUnique);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while checking email: {Email}", email);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edituser(User user)
        {
            try
            {
                user.UpdatedOn = DateTime.Now;


                if (await _repo.Edituser(user))
                {
                    _logger.LogInformation("User with ID {UserId} edited successfully.", user.UserId);
                    return Ok();
                }
                else
                {
                    _logger.LogWarning("User with ID {UserId} not found for editing.", user.UserId);
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing user with ID {UserId}.", user.UserId);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("manager")]
        public IActionResult GetManagers()
        {
            try
            {
                var managers = _repo.GetManagers();
                _logger.LogInformation("Retrieved all managers successfully.");
               

                return Ok(managers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving managers.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
