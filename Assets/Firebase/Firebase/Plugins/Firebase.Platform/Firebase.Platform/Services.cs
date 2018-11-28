using Firebase.Platform.Default;
using System;

namespace Firebase.Platform
{
	internal static class Services
	{
		public static IAppConfigExtensions AppConfig
		{
			get;
			internal set;
		}

		public static IAuthService Auth
		{
			get;
			internal set;
		}

		public static ICertificateService RootCerts
		{
			get;
			internal set;
		}

		public static IClockService Clock
		{
			get;
			internal set;
		}

		public static IHttpFactoryService HttpFactory
		{
			get;
			internal set;
		}

		public static ILoggingService Logging
		{
			get;
			internal set;
		}

		static Services()
		{
			Services.AppConfig = AppConfigExtensions.Instance;
			Services.Auth = BaseAuthService.BaseInstance;
			Services.RootCerts = NoopCertificateService.Instance;
			Services.Clock = SystemClock.Instance;
			Services.Logging = DebugLogger.Instance;
		}
	}
}
