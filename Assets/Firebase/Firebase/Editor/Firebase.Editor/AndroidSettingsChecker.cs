using System;
using UnityEditor;
using UnityEngine;

namespace Firebase.Editor
{
	[InitializeOnLoad]
	internal class AndroidSettingsChecker : AssetPostprocessor
	{
		private static bool checkedVersion;

		static AndroidSettingsChecker()
		{
			if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
			{
				AndroidSettingsChecker.CheckMinimumAndroidVersion();
			}
		}

		private static void CheckMinimumAndroidVersion()
		{
			if (!AndroidSettingsChecker.checkedVersion)
			{
				AndroidSettingsChecker.checkedVersion = true;
				bool flag = false;
				switch ((int)PlayerSettings.Android.minSdkVersion)
				{
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
					flag = true;
					break;
				}
				if (flag)
				{
					Debug.LogError(DocStrings.DocRef.AndroidSdkVersionMismatch.String());
					bool flag2 = EditorUtility.DisplayDialog(DocStrings.DocRef.AndroidSdkVersionMismatchSummary.String(), DocStrings.DocRef.AndroidSdkVersionMismatch.String() + "\n" + DocStrings.DocRef.AndroidSdkVersionChange.String(), DocStrings.Yes, DocStrings.No);
					if (flag2)
					{
						PlayerSettings.Android.minSdkVersion= AndroidSdkVersions.AndroidApiLevel16;
					}
				}
			}
		}
	}
}
