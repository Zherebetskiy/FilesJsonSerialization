using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilesJsonSerializationLibrary.Interfaces;

namespace SerializingWebAPI.Controllers
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

        // GET api/values/path
        [HttpGet("{path}")]
        public ActionResult<string> Post([FromBody]string path)
        {
           // return path;
            return serializator.Serialize(path);
        }
    }
}