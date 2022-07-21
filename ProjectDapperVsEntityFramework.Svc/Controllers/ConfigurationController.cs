using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectDapperVsEntityFramework.Application.Entities;
using ProjectDapperVsEntityFramework.Infra.Configuration;
using ProjectDapperVsEntityFramework.Infra.Context;

namespace ProjectDapperVsEntityFramework.Svc.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserModel> _userManager;

        public ConfigurationController(           
           ApplicationDbContext context,
           UserManager<UserModel> userManager)
        {            
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Set Configurations
        /// </summary>
        /// <returns></returns>
        ///
        [HttpPost("setConfig")]
        public IActionResult SetConfig()
        {
            SeedData.Initialize(_context, _userManager);

            return Ok();
        }
    }
}
