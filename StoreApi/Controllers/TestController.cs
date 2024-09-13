using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string GetMyName()
        {
            return "oriel";
        }

        // route params - פרמטרים בנתיב
        [HttpGet("get-name/{name}")]
        public string GetName(string name)
        {
            return $"your name is {name}";
        }

        // query params - פרמטרים כשאילתה
        [HttpGet("get-name")]
        public string GetName2(string name = "yehuda", int age = 38)
        {
            return $"your name is {name}\nand your age is {age}";
        }


        [HttpGet("add/{num1}/{num2}")]
        public IActionResult Add(int num1, int num2)
        {
            return Ok(num1 + num2);
        }


        [HttpGet("mul")]
        public IActionResult Mul(int num1, int num2 = 5)
        {
            return Ok(num1 * num2);
        }
    }
}
