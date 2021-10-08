using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web;
using TinyUrlBL;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class TinyUrlController : ControllerBase
    {
        static Dictionary<string, string> urls = new Dictionary<string, string>();
        ITinyUrl _tiny;
        public TinyUrlController(ITinyUrl tiny)
        {
            _tiny = tiny;
        }

        [HttpGet]
        [Route("GetUrl/{text}")]                    
        public ActionResult<string> Get(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                string output = _tiny.GenerateTinyUrl(text);
                urls.Add(output.Substring(output.Length - 6), text);
                return Ok(output);
            }
            else
            {
                return BadRequest("Input a valid URL");
            }
        }

        [HttpGet]
        [Route("RedirectUrl/{text}")]
        public ActionResult<string> RedirectUrl(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                string returnUrl = HttpUtility.UrlDecode(text);
                urls.TryGetValue(returnUrl, out string actualURL);     //find the actual URL

                actualURL = HttpUtility.UrlDecode(actualURL);
                Response.Redirect(actualURL);

                return Ok();
            }
            else
            {
                return BadRequest("Input a valid URL");
            }
        }
    }
}
