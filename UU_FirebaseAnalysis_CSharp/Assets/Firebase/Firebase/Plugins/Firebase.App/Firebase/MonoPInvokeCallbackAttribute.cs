using System;

namespace Firebase
{
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class MonoPInvokeCallbackAttribute : Attribute
	{
		public MonoPInvokeCallbackAttribute(Type t)
		{
		}
	}
}
