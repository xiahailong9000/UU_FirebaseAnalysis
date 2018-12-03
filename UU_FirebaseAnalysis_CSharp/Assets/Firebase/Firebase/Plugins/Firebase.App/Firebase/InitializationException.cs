using System;

namespace Firebase
{
	public sealed class InitializationException : Exception
	{
		public InitResult InitResult
		{
			get;
			private set;
		}

		public InitializationException(InitResult result)
		{
			this.InitResult = result;
		}

		public InitializationException(InitResult result, string message) : base(message)
		{
			this.InitResult = result;
		}

		public InitializationException(InitResult result, string message, Exception inner) : base(message, inner)
		{
			this.InitResult = result;
		}
	}
}
