using FilesJsonSerializationLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SerializingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerializingController : ControllerBase
    {
        private readonly ISerializator serializator;
        public SerializingController(ISerializator serializator)
        {
            this.serializator = serializator;
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] string path)
        {
            var res = serializator.Serialize(path);
            return res;
        }
    }
}