using Microsoft.AspNetCore.Mvc;

namespace Day14Lab1PokeDex.Controllers {
    public class FileUploadController : Controller {
        public IActionResult Index() {
            return View();
        }


        [HttpPost]
        public IActionResult UploadFile() {
            if(Request.Form.Files.Count > 0) {
                foreach(var file in Request.Form.Files) {
                    var fileName = file.FileName;
                    using(var outpuFile = System.IO.File.Create($"Upload/{fileName}")) { 
                        file.CopyTo(outpuFile);
                    }
                }

            }

            return Ok("Saved!");
        }
    }
}
