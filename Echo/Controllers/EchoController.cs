using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Echo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EchoController : ControllerBase
    {
        private readonly ILogger<EchoController> _logger;

        public EchoController(ILogger<EchoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IDictionary<string, string> Get()
        {
            var res = new Dictionary<string, string>();

            foreach (var (headerName, values) in Request.Headers)
            {
                res.Add($"Header_{headerName}", values.ToString());
            }

            return res;
        }

        [HttpPost]
        public IDictionary<string, string> Post(IDictionary<string, string> body)
        {
            var res = new Dictionary<string, string>(body);

            foreach (var (headerName, values) in Request.Headers)
            {
                res.Add($"Header_{headerName}", values.ToString());
            }

            return res;
        }
    }
}
