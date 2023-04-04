using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Day18Lab1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MD5Contoller : ControllerBase {

        protected readonly System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        public MD5Contoller() {

        }

        protected string Compute(string PlainText) {
            byte[] HashCode = md5.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(PlainText));
            return BitConverter.ToString(HashCode);
        }

        [HttpGet]
        public IActionResult Get(string PlainText) { 
            return Ok(Compute(PlainText));
        }

        [HttpPost]
        public IActionResult Validate(string PlainText,string HexText) {
            //ff-aa-bb-99
            /* Long and useless way
            string[] tk = HexText.Split('-');
            List<byte> tmpls = new List<byte>();
            foreach(string s in tk) {
                byte tmp;
                if (Byte.TryParse(s, out tmp) {
                    tmpls.Add(tmp);
                }
            }
            byte[] bin_has= tmpls.ToArray<byte>();  
            //*/
            if (HexText.Equals(Compute(PlainText)))  { 
                return Ok(true);
            } else {
                return Ok(false);
            }
            return BadRequest();
        }
    }
}
