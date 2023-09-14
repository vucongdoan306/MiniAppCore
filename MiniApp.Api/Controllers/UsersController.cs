using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniApp.BL.Interface;

namespace MiniApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult UserById(string id)
        {
            try
            {
                var data = _service.GetUserById(id);
                return StatusCode(200,data);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
