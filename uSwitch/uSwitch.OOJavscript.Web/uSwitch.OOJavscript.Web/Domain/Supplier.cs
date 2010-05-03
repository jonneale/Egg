using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace uSwitch.OOJavaScript.Web.Domain
{
    [DataContract(Namespace = "OOJavascript")]
    public class Supplier
    {
        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public IList<Plan> Plans
        {
            get;
            set;
        }
    }
}
