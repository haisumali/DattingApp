using Microsoft.AspNetCore.Mvc; // Ensure this is included
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Consider using [controller] for better clarity
    public class BaseApiController : ControllerBase
    {
    }
}
