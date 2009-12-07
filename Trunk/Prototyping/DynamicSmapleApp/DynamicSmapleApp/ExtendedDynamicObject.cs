using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace DynamicSmapleApp
{
	public class ExtendedDynamicObject : DynamicObject
	{
		private IDictionary<string, MemberDescription> _members = new Dictionary<string, MemberDescription>();

		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
		{
			MemberDescription description;
			if (!_members.TryGetValue(binder.Name, out description))
			{
				result = new object();
				return false;
			}

			Delegate delegateMethod = description.Value as Delegate;
			result = delegateMethod.Method.Invoke(null, new object[] { });

			return true;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			string methodCall = binder.Name;
			MemberDescription member;

			if (!_members.TryGetValue(methodCall, out member))
			{
				result = new object();
				return false;
			}

			result = member.Value;
			return true;
		}

		public override IEnumerable<string> GetDynamicMemberNames()
		{
			return _members.Keys;
		}

		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
		{
			if (!(indexes[0] is string))
			{
				result = new object();
				return false;
			}

			MemberDescription member;
			if (!_members.TryGetValue(indexes[0] as string, out member))
			{
				result = new object();
				return false;
			}

			result = member.Value;
			return true;
		}

		public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
		{
			if (!(indexes[0] is string))
			{
				return false;
			}

			_members[indexes[0] as string] = new MemberDescription(indexes[0] as string, value, new Type[] { });
			return true;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			if (value is Delegate)
			{
				var delegateMethod = value as Delegate;
				IEnumerable<Type> argumentTypes = MemberDescription.GetArgumentTypes(delegateMethod);

				var memberDescription = new MemberDescription(binder.Name, argumentTypes, new Type[] { });
				_members[binder.Name] = memberDescription;
			}

			var description = new MemberDescription(binder.Name, value, new Type[] { });
			_members[binder.Name] = description;
			return true;
		}
	}
}
