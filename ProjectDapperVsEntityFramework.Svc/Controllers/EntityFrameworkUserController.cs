using Microsoft.AspNetCore.Mvc;
using ProjectDapperVsEntityFramework.Application.Interfaces;

namespace ProjectDapperVsEntityFramework.Svc.Controllers
{    
    public class EntityFrameworkController : Controller
    {        
        private readonly IUserEfRepository _userEfRepository;

        public EntityFrameworkController(     
           IUserEfRepository userEfRepository)
        {            
            _userEfRepository = userEfRepository;
        }

        /// <summary>
        /// Get user by email EF
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet()]
        [Route("user1/{email}")]
        public async Task<IActionResult> GetUsersByEmailEf(string email)
        {
            return Ok(await _userEfRepository.GetUserByEmail(email));
        }

        /// <summary>
        /// Get users EF
        /// </summary>
        /// <returns></returns>
        ///         
        [HttpGet()]
        [Route("user1")]
        public async Task<IActionResult> GetUsersEf()
        {
            return Ok(await _userEfRepository.GetUsers());
        }
    }
}
