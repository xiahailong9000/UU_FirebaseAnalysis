using System;
using UnityEditor;
using UnityEngine;

namespace Firebase.Editor
{
	[InitializeOnLoad]
	internal class SettingsWindowUpdater : AssetPostprocessor
	{
		public static UnityEngine.Object assetsChangedLock = new UnityEngine.Object();

		public static bool assetsChanged = false;

		private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath)
		{
			object obj = SettingsWindowUpdater.assetsChangedLock;
			lock (obj)
			{
				SettingsWindowUpdater.assetsChanged = true;
			}
		}
	}
}
