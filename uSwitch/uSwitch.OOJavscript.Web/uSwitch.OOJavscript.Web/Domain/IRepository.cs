using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace uSwitch.OOJavaScript.Web.Domain
{
    [ServiceContract(Namespace = "OOJavaScript", Name = "Repository")]
    public interface IRepository
    {
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "suppliers")]
        [OperationContract]
        Supplier[] GetSuppliers();

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "suppliers/{id}")]
        [OperationContract]
        Supplier GetSupplier(string id);

        [WebGet(ResponseFormat = WebMessageFormat.Xml, UriTemplate = "test")]
        [OperationContract]
        string Test();
    }
}
