using Microsoft.AspNetCore.Mvc;
using MDS.Api.Utility.Extensions;
using MDS.Infrastructure.DbUtility;

namespace MDS.Api.Infrastructure
{
    public class BaseController : ControllerBase
    {
        public long CurrentUserId => this.HttpContext.GetCurrentUserId();

        [NonAction] 
        internal async Task<Stream> GetFileStream(string filePath)
        {
            var fileContents = new FileStream(filePath, FileMode.Open);
            return fileContents;
        }
    }
}
