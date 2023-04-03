using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Authentication;
using System.Text;
using System.Text.Encodings.Web;

namespace Day17Lab2.Pages
{
    [Authorize]
    public class PrivateModel : PageModel
    {
        [BindProperty]
        public string? PlainText { get; set; }
        public string? Cipher { get; set; } = null;
        public void OnGet()
        {
        }

        public void OnPost() {
            var md5= System.Security.Cryptography.MD5.Create();
            Cipher = BitConverter.ToString(md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(PlainText)));
        }
    }
}
