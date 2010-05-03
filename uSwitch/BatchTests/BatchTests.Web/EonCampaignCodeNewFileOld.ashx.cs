using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BatchTests.Web
{
    public class EonCampaignCodeNewFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string fileName = context.Request.QueryString["filename"];

            string path = Path.GetTempPath();
            string fullFileName = Path.Combine(path, fileName);
            context.Response.ContentType = "text/csv";
            context.Response.WriteFile(fullFileName);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
