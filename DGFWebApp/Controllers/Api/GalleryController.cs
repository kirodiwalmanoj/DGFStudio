using DGFWebApp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGFWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        [HttpGet("getGallaryitems")]
        public IEnumerable<string> Get()
        {
            var fileList = Directory.GetFiles("wwwroot\\img\\gallery");
            return fileList.Select(x => Path.GetFileName(x));
        }

    }
}
