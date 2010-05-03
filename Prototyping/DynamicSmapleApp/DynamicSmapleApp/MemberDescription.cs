using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicSmapleApp
{
	public class MemberDescription
	{
		public bool IsDelegate
		{
			get;
			private set;
		}

		public dynamic Value
		{
			get;
			private set;
		}

		public string MemberName
		{
			get;
			private set;
		}

		public IEnumerable<Type> ArgumentTypes
		{
			get;
			private set;
		}

		public MemberDescription(string memberName, bool isDelegate, dynamic value)
		{
			MemberName = memberName;
			IsDelegate = isDelegate;
			Value = value;
			ArgumentTypes = new Type[] { };
		}

		public MemberDescription(string methodName, bool isDelegate, dynamic value, IEnumerable<Type> argumentTypes)
		{
			MemberName = methodName;
			IsDelegate = isDelegate;
			ArgumentTypes = argumentTypes;
			Value = value;
		}

		public dynamic InvokeMethod(params object[] arguments)
		{
			Delegate method = Value as Delegate;

			if (method == null)
			{
				throw new Exception("Method doesnt exist");
			}
			return method.Method.Invoke(null, new object[] { });
		}

		public static IEnumerable<Type> GetArgumentTypes(Delegate instance)
		{
			return instance.Method.GetParameters().Select(x => x.ParameterType);
		}
	}
}
