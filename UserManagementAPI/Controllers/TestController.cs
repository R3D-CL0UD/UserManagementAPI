using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]  // <-- این یعنی همه اکشن‌های این کنترلر نیاز به توکن دارن
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("شما مجاز هستید!");
        }
    }
}