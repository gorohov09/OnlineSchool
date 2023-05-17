using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Teacher.Queries.GetAllStudents;

namespace OnlineSchool.API.Controllers
{
    [Route("api/test")]
    [AllowAnonymous]
    public class TestController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok(123);
        }
    }
}
