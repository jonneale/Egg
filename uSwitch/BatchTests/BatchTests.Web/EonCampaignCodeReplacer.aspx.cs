using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BatchTests.Web.Core;

namespace BatchTests.Web
{
    public partial class EonCampaignCodeReplacer_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            createFileButton.Click += createFileButton_Click;
        }

        void createFileButton_Click(object sender, EventArgs e)
        {
            string fullFileNameOld = Path.GetTempFileName();
            originalFileuploader.PostedFile.SaveAs(fullFileNameOld);

            var codeReplacer = new EonCampaignCodeReplacer(fullFileNameOld);
            string newFullFileName = codeReplacer.GenerateFile();
            string fileName = Path.GetFileName(newFullFileName);

            newFileHyperLink.NavigateUrl = string.Format("~/EonCampaignCodeNewFile.csv?filename={0}",
                                                         HttpUtility.UrlEncode(fileName));

            newFileHyperLinkDiv.Visible = true;
        }
    }
}
