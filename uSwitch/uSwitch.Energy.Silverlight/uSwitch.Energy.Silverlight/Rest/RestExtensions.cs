using uSwitch.Energy.Silverlight.Model;

namespace uSwitch.Energy.Silverlight.Rest
{
    public static class RestExtensions
    {
        public static string UrlEncodedName(this Supplier supplier)
        {
            return supplier.Name.Replace(" ", "%20");
        }
    }
}