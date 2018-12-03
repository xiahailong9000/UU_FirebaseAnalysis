using Firebase.Platform.Default;
using System;
using System.Threading;

namespace Firebase.Platform.Security
{
	internal abstract class ServiceCredential
	{
		internal class Initializer
		{
			public string TokenServerUrl
			{
				get;
				private set;
			}

			public IClockService Clock
			{
				get;
				set;
			}

			public Initializer(string tokenServerUrl)
			{
				this.TokenServerUrl = tokenServerUrl;
				this.Clock = SystemClock.Instance;
			}
		}

		public string TokenServerUrl
		{
			get;
			private set;
		}

		public IClockService Clock
		{
			get;
			private set;
		}

		protected ServiceCredential(ServiceCredential.Initializer initializer)
		{
			this.TokenServerUrl = initializer.TokenServerUrl;
			this.Clock = initializer.Clock;
		}

		public string GetAccessTokenForRequest()
		{
			return this.GetAccessTokenForRequestSync(default(CancellationToken));
		}

		public abstract string GetAccessTokenForRequestSync(CancellationToken taskCancellationToken);
	}
}
