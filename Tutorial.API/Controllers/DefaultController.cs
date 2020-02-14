using Microsoft.AspNetCore.Mvc;

namespace Inkers.EMahall.DefaultController
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Working";
        }
    }
}
