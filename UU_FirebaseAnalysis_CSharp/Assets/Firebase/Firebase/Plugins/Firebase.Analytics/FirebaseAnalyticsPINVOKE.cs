using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Firebase.Analytics
{
	internal class FirebaseAnalyticsPINVOKE
	{
		protected class SWIGExceptionHelper
		{
			public delegate void ExceptionDelegate(string message);

			public delegate void ExceptionArgumentDelegate(string message, string paramName);

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate applicationDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate arithmeticDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate divideByZeroDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate indexOutOfRangeDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidCastDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidOperationDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate ioDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate nullReferenceDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate outOfMemoryDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate overflowDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate systemDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentNullDelegate;

			private static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentOutOfRangeDelegate;

			static SWIGExceptionHelper()
			{
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.applicationDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingApplicationException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.arithmeticDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingArithmeticException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.divideByZeroDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingDivideByZeroException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.indexOutOfRangeDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingIndexOutOfRangeException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.invalidCastDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingInvalidCastException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.invalidOperationDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingInvalidOperationException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ioDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingIOException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.nullReferenceDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingNullReferenceException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.outOfMemoryDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingOutOfMemoryException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.overflowDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingOverflowException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.systemDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingSystemException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.argumentDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingArgumentException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.argumentNullDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingArgumentNullException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.argumentOutOfRangeDelegate = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SetPendingArgumentOutOfRangeException);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SWIGRegisterExceptionCallbacks_FirebaseAnalytics(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.applicationDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.arithmeticDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.divideByZeroDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.indexOutOfRangeDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.invalidCastDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.invalidOperationDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ioDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.nullReferenceDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.outOfMemoryDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.overflowDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.systemDelegate);
				FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.SWIGRegisterExceptionCallbacksArgument_FirebaseAnalytics(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.argumentDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.argumentNullDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.argumentOutOfRangeDelegate);
			}

			[DllImport("FirebaseCppApp-5.2.1")]
			public static extern void SWIGRegisterExceptionCallbacks_FirebaseAnalytics(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate applicationDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate arithmeticDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate divideByZeroDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate indexOutOfRangeDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidCastDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidOperationDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate ioDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate nullReferenceDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate outOfMemoryDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate overflowDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate systemExceptionDelegate);

			[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_FirebaseAnalytics")]
			public static extern void SWIGRegisterExceptionCallbacksArgument_FirebaseAnalytics(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentNullDelegate, FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentOutOfRangeDelegate);

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingApplicationException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new ApplicationException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingArithmeticException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new ArithmeticException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingDivideByZeroException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new DivideByZeroException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingIndexOutOfRangeException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new IndexOutOfRangeException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingInvalidCastException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new InvalidCastException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingInvalidOperationException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new InvalidOperationException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingIOException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new IOException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingNullReferenceException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new NullReferenceException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingOutOfMemoryException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new OutOfMemoryException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingOverflowException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new OverflowException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionDelegate))]
			private static void SetPendingSystemException(string message)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new SystemException(message, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate))]
			private static void SetPendingArgumentException(string message, string paramName)
			{
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new ArgumentException(message, paramName, FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve()));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate))]
			private static void SetPendingArgumentNullException(string message, string paramName)
			{
				Exception ex = FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve();
				if (ex != null)
				{
					message = message + " Inner Exception: " + ex.Message;
				}
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new ArgumentNullException(paramName, message));
			}

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate))]
			private static void SetPendingArgumentOutOfRangeException(string message, string paramName)
			{
				Exception ex = FirebaseAnalyticsPINVOKE.SWIGPendingException.Retrieve();
				if (ex != null)
				{
					message = message + " Inner Exception: " + ex.Message;
				}
				FirebaseAnalyticsPINVOKE.SWIGPendingException.Set(new ArgumentOutOfRangeException(paramName, message));
			}
		}

		public class SWIGPendingException
		{
			[ThreadStatic]
			private static Exception pendingException;

			private static int numExceptionsPending;

			public static bool Pending
			{
				get
				{
					bool result = false;
					if (FirebaseAnalyticsPINVOKE.SWIGPendingException.numExceptionsPending > 0 && FirebaseAnalyticsPINVOKE.SWIGPendingException.pendingException != null)
					{
						result = true;
					}
					return result;
				}
			}

			public static void Set(Exception e)
			{
				if (FirebaseAnalyticsPINVOKE.SWIGPendingException.pendingException != null)
				{
					throw new ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + FirebaseAnalyticsPINVOKE.SWIGPendingException.pendingException.ToString() + ")", e);
				}
				FirebaseAnalyticsPINVOKE.SWIGPendingException.pendingException = e;
				object typeFromHandle = typeof(FirebaseAnalyticsPINVOKE);
				lock (typeFromHandle)
				{
					FirebaseAnalyticsPINVOKE.SWIGPendingException.numExceptionsPending++;
				}
			}

			public static Exception Retrieve()
			{
				Exception result = null;
				if (FirebaseAnalyticsPINVOKE.SWIGPendingException.numExceptionsPending > 0 && FirebaseAnalyticsPINVOKE.SWIGPendingException.pendingException != null)
				{
					result = FirebaseAnalyticsPINVOKE.SWIGPendingException.pendingException;
					FirebaseAnalyticsPINVOKE.SWIGPendingException.pendingException = null;
					object typeFromHandle = typeof(FirebaseAnalyticsPINVOKE);
					lock (typeFromHandle)
					{
						FirebaseAnalyticsPINVOKE.SWIGPendingException.numExceptionsPending--;
					}
				}
				return result;
			}
		}

		protected class SWIGStringHelper
		{
			public delegate string SWIGStringDelegate(string message);

			private static FirebaseAnalyticsPINVOKE.SWIGStringHelper.SWIGStringDelegate stringDelegate;

			static SWIGStringHelper()
			{
				FirebaseAnalyticsPINVOKE.SWIGStringHelper.stringDelegate = new FirebaseAnalyticsPINVOKE.SWIGStringHelper.SWIGStringDelegate(FirebaseAnalyticsPINVOKE.SWIGStringHelper.CreateString);
				FirebaseAnalyticsPINVOKE.SWIGStringHelper.SWIGRegisterStringCallback_FirebaseAnalytics(FirebaseAnalyticsPINVOKE.SWIGStringHelper.stringDelegate);
			}

			[DllImport("FirebaseCppApp-5.2.1")]
			public static extern void SWIGRegisterStringCallback_FirebaseAnalytics(FirebaseAnalyticsPINVOKE.SWIGStringHelper.SWIGStringDelegate stringDelegate);

			[MonoPInvokeCallback(typeof(FirebaseAnalyticsPINVOKE.SWIGStringHelper.SWIGStringDelegate))]
			private static string CreateString(string cString)
			{
				return cString;
			}
		}

		protected static FirebaseAnalyticsPINVOKE.SWIGExceptionHelper swigExceptionHelper;

		protected static FirebaseAnalyticsPINVOKE.SWIGStringHelper swigStringHelper;

		static FirebaseAnalyticsPINVOKE()
		{
			FirebaseAnalyticsPINVOKE.swigExceptionHelper = new FirebaseAnalyticsPINVOKE.SWIGExceptionHelper();
			FirebaseAnalyticsPINVOKE.swigStringHelper = new FirebaseAnalyticsPINVOKE.SWIGStringHelper();
		}

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventAddPaymentInfo_get")]
		public static extern string kEventAddPaymentInfo_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventAddToCart_get")]
		public static extern string kEventAddToCart_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventAddToWishlist_get")]
		public static extern string kEventAddToWishlist_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventAppOpen_get")]
		public static extern string kEventAppOpen_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventBeginCheckout_get")]
		public static extern string kEventBeginCheckout_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventCampaignDetails_get")]
		public static extern string kEventCampaignDetails_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventCheckoutProgress_get")]
		public static extern string kEventCheckoutProgress_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventEarnVirtualCurrency_get")]
		public static extern string kEventEarnVirtualCurrency_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventEcommercePurchase_get")]
		public static extern string kEventEcommercePurchase_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventGenerateLead_get")]
		public static extern string kEventGenerateLead_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventJoinGroup_get")]
		public static extern string kEventJoinGroup_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventLevelUp_get")]
		public static extern string kEventLevelUp_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventLogin_get")]
		public static extern string kEventLogin_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventPostScore_get")]
		public static extern string kEventPostScore_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventPresentOffer_get")]
		public static extern string kEventPresentOffer_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventPurchaseRefund_get")]
		public static extern string kEventPurchaseRefund_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventRemoveFromCart_get")]
		public static extern string kEventRemoveFromCart_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventSearch_get")]
		public static extern string kEventSearch_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventSelectContent_get")]
		public static extern string kEventSelectContent_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventSetCheckoutOption_get")]
		public static extern string kEventSetCheckoutOption_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventShare_get")]
		public static extern string kEventShare_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventSignUp_get")]
		public static extern string kEventSignUp_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventSpendVirtualCurrency_get")]
		public static extern string kEventSpendVirtualCurrency_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventTutorialBegin_get")]
		public static extern string kEventTutorialBegin_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventTutorialComplete_get")]
		public static extern string kEventTutorialComplete_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventUnlockAchievement_get")]
		public static extern string kEventUnlockAchievement_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventViewItem_get")]
		public static extern string kEventViewItem_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventViewItemList_get")]
		public static extern string kEventViewItemList_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventViewSearchResults_get")]
		public static extern string kEventViewSearchResults_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventLevelStart_get")]
		public static extern string kEventLevelStart_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kEventLevelEnd_get")]
		public static extern string kEventLevelEnd_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterAchievementId_get")]
		public static extern string kParameterAchievementId_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterAdNetworkClickID_get")]
		public static extern string kParameterAdNetworkClickID_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterAffiliation_get")]
		public static extern string kParameterAffiliation_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterCampaign_get")]
		public static extern string kParameterCampaign_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterCharacter_get")]
		public static extern string kParameterCharacter_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterCheckoutStep_get")]
		public static extern string kParameterCheckoutStep_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterCheckoutOption_get")]
		public static extern string kParameterCheckoutOption_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterContent_get")]
		public static extern string kParameterContent_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterContentType_get")]
		public static extern string kParameterContentType_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterCoupon_get")]
		public static extern string kParameterCoupon_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterCP1_get")]
		public static extern string kParameterCP1_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterCreativeName_get")]
		public static extern string kParameterCreativeName_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterCreativeSlot_get")]
		public static extern string kParameterCreativeSlot_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterCurrency_get")]
		public static extern string kParameterCurrency_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterDestination_get")]
		public static extern string kParameterDestination_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterEndDate_get")]
		public static extern string kParameterEndDate_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterFlightNumber_get")]
		public static extern string kParameterFlightNumber_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterGroupId_get")]
		public static extern string kParameterGroupId_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterIndex_get")]
		public static extern string kParameterIndex_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterItemBrand_get")]
		public static extern string kParameterItemBrand_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterItemCategory_get")]
		public static extern string kParameterItemCategory_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterItemId_get")]
		public static extern string kParameterItemId_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterItemLocationId_get")]
		public static extern string kParameterItemLocationId_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterItemName_get")]
		public static extern string kParameterItemName_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterItemList_get")]
		public static extern string kParameterItemList_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterItemVariant_get")]
		public static extern string kParameterItemVariant_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterLevel_get")]
		public static extern string kParameterLevel_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterLocation_get")]
		public static extern string kParameterLocation_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterMedium_get")]
		public static extern string kParameterMedium_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterNumberOfNights_get")]
		public static extern string kParameterNumberOfNights_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterNumberOfPassengers_get")]
		public static extern string kParameterNumberOfPassengers_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterNumberOfRooms_get")]
		public static extern string kParameterNumberOfRooms_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterOrigin_get")]
		public static extern string kParameterOrigin_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterPrice_get")]
		public static extern string kParameterPrice_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterQuantity_get")]
		public static extern string kParameterQuantity_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterScore_get")]
		public static extern string kParameterScore_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterSearchTerm_get")]
		public static extern string kParameterSearchTerm_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterShipping_get")]
		public static extern string kParameterShipping_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterSignUpMethod_get")]
		public static extern string kParameterSignUpMethod_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterSource_get")]
		public static extern string kParameterSource_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterStartDate_get")]
		public static extern string kParameterStartDate_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterTax_get")]
		public static extern string kParameterTax_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterTerm_get")]
		public static extern string kParameterTerm_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterTransactionId_get")]
		public static extern string kParameterTransactionId_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterTravelClass_get")]
		public static extern string kParameterTravelClass_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterValue_get")]
		public static extern string kParameterValue_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterVirtualCurrencyName_get")]
		public static extern string kParameterVirtualCurrencyName_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterLevelName_get")]
		public static extern string kParameterLevelName_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kParameterSuccess_get")]
		public static extern string kParameterSuccess_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_kUserPropertySignUpMethod_get")]
		public static extern string kUserPropertySignUpMethod_get();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_new_Parameter__SWIG_0")]
		public static extern IntPtr new_Parameter__SWIG_0(string jarg1, string jarg2);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_new_Parameter__SWIG_1")]
		public static extern IntPtr new_Parameter__SWIG_1(string jarg1, long jarg2);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_new_Parameter__SWIG_2")]
		public static extern IntPtr new_Parameter__SWIG_2(string jarg1, double jarg2);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_delete_Parameter")]
		public static extern void delete_Parameter(HandleRef jarg1);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_SetAnalyticsCollectionEnabled")]
		public static extern void SetAnalyticsCollectionEnabled(bool jarg1);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_LogEvent__SWIG_0")]
		public static extern void LogEvent__SWIG_0(string jarg1, string jarg2, string jarg3);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_LogEvent__SWIG_1")]
		public static extern void LogEvent__SWIG_1(string jarg1, string jarg2, double jarg3);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_LogEvent__SWIG_2")]
		public static extern void LogEvent__SWIG_2(string jarg1, string jarg2, long jarg3);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_LogEvent__SWIG_3")]
		public static extern void LogEvent__SWIG_3(string jarg1, string jarg2, int jarg3);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_LogEvent__SWIG_4")]
		public static extern void LogEvent__SWIG_4(string jarg1);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_LogEvent__SWIG_5")]
		public static extern void LogEvent__SWIG_5(string jarg1, IntPtr arg, int jarg2);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_SetUserProperty")]
		public static extern void SetUserProperty(string jarg1, string jarg2);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_SetUserId")]
		public static extern void SetUserId(string jarg1);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_SetMinimumSessionDurationInternal")]
		internal static extern void SetMinimumSessionDurationInternal(long jarg1);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_SetSessionTimeoutDurationInternal")]
		internal static extern void SetSessionTimeoutDurationInternal(long jarg1);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_SetCurrentScreen")]
		public static extern void SetCurrentScreen(string jarg1, string jarg2);

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_ResetAnalyticsData")]
		public static extern void ResetAnalyticsData();

		[DllImport("FirebaseCppApp-5.2.1", EntryPoint = "Firebase_Analytics_CSharp_GetAnalyticsInstanceId")]
		public static extern IntPtr GetAnalyticsInstanceId();
	}
}
