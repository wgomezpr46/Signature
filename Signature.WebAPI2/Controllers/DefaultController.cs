using System.Web.Http;

namespace Signature.WebAPI2.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default/Get
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok($"Hello World!!");
        }
    }
}