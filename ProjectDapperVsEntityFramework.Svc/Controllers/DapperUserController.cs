using Microsoft.AspNetCore.Mvc;
using ProjectDapperVsEntityFramework.Application.Interfaces.Repository;

namespace ProjectDapperVsEntityFramework.Svc.Controllers
{    
    public class DapperController : Controller
    {
        private readonly IUserRepository _userRepository;

        public DapperController(
           IUserRepository userRepository)
        {
            _userRepository = userRepository;            
        }

        /// <summary>
        /// Get user by email DAPPER
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet()]
        [Route("user/{email}")]
        public async Task<IActionResult> GetUsersByEmail(string email)
        {
            return Ok(await _userRepository.GetUserByEmail(email));
        }

        /// <summary>
        /// Get users DAPPER
        /// </summary>
        /// <returns></returns>
        ///         
        [HttpGet()]
        [Route("user")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userRepository.GetUsers());
        }
    }
}
