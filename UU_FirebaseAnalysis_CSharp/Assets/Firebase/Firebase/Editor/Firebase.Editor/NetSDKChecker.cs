using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Firebase.Editor
{
	[InitializeOnLoad]
	internal class NetSDKChecker : AssetPostprocessor
	{
		private static bool checkedSDK;

		[CompilerGenerated]
		private static EditorApplication.CallbackFunction f__mgcache0;

		[CompilerGenerated]
		private static EditorApplication.CallbackFunction f__mgcache1;

		[CompilerGenerated]
		private static EditorApplication.CallbackFunction f__mgcache2;

		static NetSDKChecker()
		{
			Delegate arg_22_0 = EditorApplication.update;
			if (NetSDKChecker.f__mgcache0 == null)
			{
				NetSDKChecker.f__mgcache0 = new EditorApplication.CallbackFunction(NetSDKChecker.CheckForFullSdk);
			}
			EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(arg_22_0, NetSDKChecker.f__mgcache0);
			Delegate arg_53_0 = EditorApplication.update;
			if (NetSDKChecker.f__mgcache1 == null)
			{
				NetSDKChecker.f__mgcache1 = new EditorApplication.CallbackFunction(NetSDKChecker.CheckForFullSdk);
			}
			EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(arg_53_0, NetSDKChecker.f__mgcache1);
		}

		private static void CheckForFullSdk()
		{
			Delegate arg_22_0 = EditorApplication.update;
			if (NetSDKChecker.f__mgcache2 == null)
			{
				NetSDKChecker.f__mgcache2 = new EditorApplication.CallbackFunction(NetSDKChecker.CheckForFullSdk);
			}
			EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(arg_22_0, NetSDKChecker.f__mgcache2);
			if (!NetSDKChecker.checkedSDK)
			{
				NetSDKChecker.checkedSDK = true;
				string[] array = AssetDatabase.FindAssets("Firebase.Database");
				bool flag = array != null && array.Length > 0;
				if (flag && (int)PlayerSettings.apiCompatibilityLevel == 2)
				{
					Debug.LogError(DocStrings.DocRef.DotNetSdkMismatch.String());
					bool flag2 = EditorUtility.DisplayDialog(DocStrings.DocRef.DotNetSdkMismatchSummary.String(), DocStrings.DocRef.DotNetSdkMismatch.String() + "\n" + DocStrings.DocRef.DotNetSdkChange.String(), DocStrings.Yes, DocStrings.No);
					if (flag2)
					{
						PlayerSettings.apiCompatibilityLevel=ApiCompatibilityLevel.NET_2_0;
					}
				}
			}
		}
	}
}
