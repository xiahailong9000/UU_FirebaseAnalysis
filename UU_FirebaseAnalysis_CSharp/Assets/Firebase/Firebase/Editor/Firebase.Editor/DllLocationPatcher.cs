using System;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Firebase.Editor
{
	[InitializeOnLoad]
	internal class DllLocationPatcher : AssetPostprocessor
	{
		private const int BUILD_ORDER_PATCH_PROJECT = 1;

		private static char[] VERSION_DELIMITER = new char[]
		{
			'.'
		};

		[PostProcessBuild(1)]
		internal static void OnPostProcessDllLocation(BuildTarget buildTarget, string pathToBuiltProject)
		{
			string text = buildTarget.ToString();
			long num = 0L;
			string[] array = Application.unityVersion.Split(DllLocationPatcher.VERSION_DELIMITER);
			if (array.Length == 0 || !long.TryParse(array[0], out num) || num == 0L)
			{
				Debug.LogWarning("Cannot apply patch: unable to parse unityVersion: " + Application.unityVersion);
				return;
			}
			if (text.StartsWith("StandaloneOSX") && num >= 2017L)
			{
				string srcFolder = Path.Combine(pathToBuiltProject, "Contents/Plugins/x86_64/");
				string dstFolder = Path.Combine(pathToBuiltProject, "Contents/Frameworks/MonoEmbedRuntime/osx/");
				DllLocationPatcher.CopyLibrary(srcFolder, dstFolder, "lib", "bundle");
			}
			else if (text.StartsWith("StandaloneLinux") && num == 5L)
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathToBuiltProject);
				string path = Path.Combine(Path.GetDirectoryName(pathToBuiltProject), fileNameWithoutExtension + "_Data");
				string srcFolder2 = Path.Combine(path, "Plugins/x86_64/");
				string dstFolder2 = Path.Combine(path, "Mono/x86_64/");
				DllLocationPatcher.CopyLibrary(srcFolder2, dstFolder2, "lib", "so");
			}
		}

		internal static void CopyLibrary(string srcFolder, string dstFolder, string prefix, string extension)
		{
			Debug.Log("Post process to patch App." + extension + "'s location");
			Directory.CreateDirectory(dstFolder);
			string[] files = Directory.GetFiles(srcFolder, "*App*." + extension);
			string[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				string fileName = Path.GetFileName(text);
				string text2 = Path.Combine(dstFolder, prefix + fileName);
				File.Copy(text, text2);
				Debug.Log("Copied " + text + " to " + text2);
			}
		}
	}
}
