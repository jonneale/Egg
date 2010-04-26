using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BatchTests.Web
{
    public partial class EonReplaceString : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            convertButton.Click += convertButton_Click;
        }

        void convertButton_Click(object sender, EventArgs e)
        {
            string fullFileName = Path.GetTempFileName();
            string allTheFile = Encoding.Default.GetString(fileToDoReplaceFileUpload.FileBytes);
            allTheFile = allTheFile.Replace("E.ON FixOnline v8 UR", "E.ON FixOnline v8 Unrestricted");
            allTheFile = allTheFile.Replace("E.ON FixOnline v8 E7", "E.ON FixOnline v8 Economy 7");
            allTheFile = allTheFile.Replace("E.ON FixOnline v8 E Only_UR", "E.ON FixOnline v8 E Only_Unrestricted");

            File.WriteAllText(fullFileName, allTheFile);
            string fileName = Path.GetFileName(fullFileName);

            getFileHyperlink.NavigateUrl = string.Format("~/EonCampaignCodeNewFile.csv?filename={0}",
                                                         HttpUtility.UrlEncode(fileName));

            newFileHyperLinkDiv.Visible = true;
        }
    }
}
