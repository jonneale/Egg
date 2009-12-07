using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace DynamicSmapleApp
{
    public class MyDynamicType : System.Dynamic.DynamicObject
    {
        private IDictionary<string, dynamic> _members = new Dictionary<string, dynamic>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string methodCall = binder.Name;
            dynamic returnObject;
            if (!_members.TryGetValue(methodCall, out returnObject))
            {
                result = string.Format("Unknown method method {0}", methodCall);
                return false;
            }

            result = returnObject;
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _members.Keys;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _members[binder.Name] = value;
            return true;
        }
    }
}
