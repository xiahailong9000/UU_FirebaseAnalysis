using Google;
using GooglePlayServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace Firebase.Editor {
    [InitializeOnLoad]
    internal class XcodeProjectPatcher : AssetPostprocessor {
        private const int BUILD_ORDER_PATCH_PROJECT = 1;

        private const string GOOGLE_SERVICES_INFO_PLIST_BASENAME = "GoogleService-Info";

        private const string GOOGLE_SERVICES_INFO_PLIST_FILE = "GoogleService-Info.plist";

        private static string[] PROJECT_KEYS;

        private static Dictionary<string, string> configValues;

        private static HashSet<string> allBundleIds;

        private static string configFile;

        private static bool spamguard;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcache0;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcache1;

        [CompilerGenerated]
        private static EventHandler<PlayServicesResolver.BundleIdChangedEventArgs> f__mgcache2;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcache3;

        [CompilerGenerated]
        private static EventHandler<PlayServicesResolver.BundleIdChangedEventArgs> f__mgcache4;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcache5;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcache6;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcache7;

        private static bool Enabled {
            get {
                return (int)EditorUserBuildSettings.activeBuildTarget == 9 && IOSResolver.Enabled;
            }
        }

        static XcodeProjectPatcher() {
            XcodeProjectPatcher.PROJECT_KEYS = new string[]
            {
                "CLIENT_ID",
                "REVERSED_CLIENT_ID",
                "BUNDLE_ID",
                "PROJECT_ID",
                "STORAGE_BUCKET",
                "DATABASE_URL"
            };
            XcodeProjectPatcher.configValues = new Dictionary<string, string>();
            XcodeProjectPatcher.allBundleIds = new HashSet<string>();
            XcodeProjectPatcher.configFile = null;
            IOSResolver.RemapXcodeExtension();
            Delegate arg_7C_0 = EditorApplication.update;
            if (XcodeProjectPatcher.f__mgcache0 == null) {
                XcodeProjectPatcher.f__mgcache0 = new EditorApplication.CallbackFunction(XcodeProjectPatcher.ReadConfigOnUpdate);
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(arg_7C_0, XcodeProjectPatcher.f__mgcache0);
            Delegate arg_AD_0 = EditorApplication.update;
            if (XcodeProjectPatcher.f__mgcache1 == null) {
                XcodeProjectPatcher.f__mgcache1 = new EditorApplication.CallbackFunction(XcodeProjectPatcher.ReadConfigOnUpdate);
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(arg_AD_0, XcodeProjectPatcher.f__mgcache1);
            if (XcodeProjectPatcher.f__mgcache2 == null) {
                XcodeProjectPatcher.f__mgcache2 = new EventHandler<PlayServicesResolver.BundleIdChangedEventArgs>(XcodeProjectPatcher.OnBundleIdChanged);
            }
            PlayServicesResolver.BundleIdChanged -= XcodeProjectPatcher.f__mgcache2;//.remove_BundleIdChanged(XcodeProjectPatcher.f__mgcache2);
            Delegate arg_100_0 = EditorApplication.update;
            if (XcodeProjectPatcher.f__mgcache3 == null) {
                XcodeProjectPatcher.f__mgcache3 = new EditorApplication.CallbackFunction(XcodeProjectPatcher.CheckConfiguration);
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(arg_100_0, XcodeProjectPatcher.f__mgcache3);
            if (XcodeProjectPatcher.Enabled) {
                if (XcodeProjectPatcher.f__mgcache4 == null) {
                    XcodeProjectPatcher.f__mgcache4 = new EventHandler<PlayServicesResolver.BundleIdChangedEventArgs>(XcodeProjectPatcher.OnBundleIdChanged);
                }
                PlayServicesResolver.BundleIdChanged += XcodeProjectPatcher.f__mgcache4;
                Delegate arg_15D_0 = EditorApplication.update;
                if (XcodeProjectPatcher.f__mgcache5 == null) {
                    XcodeProjectPatcher.f__mgcache5 = new EditorApplication.CallbackFunction(XcodeProjectPatcher.CheckConfiguration);
                }
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(arg_15D_0, XcodeProjectPatcher.f__mgcache5);
            }
        }

        internal static void ReadConfigOnUpdate() {
            Delegate arg_22_0 = EditorApplication.update;
            if (XcodeProjectPatcher.f__mgcache6 == null) {
                XcodeProjectPatcher.f__mgcache6 = new EditorApplication.CallbackFunction(XcodeProjectPatcher.ReadConfigOnUpdate);
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(arg_22_0, XcodeProjectPatcher.f__mgcache6);
            XcodeProjectPatcher.ReadConfig(false, null);
        }

        private static void CheckConfiguration() {
            Delegate arg_22_0 = EditorApplication.update;
            if (XcodeProjectPatcher.f__mgcache7 == null) {
                XcodeProjectPatcher.f__mgcache7 = new EditorApplication.CallbackFunction(XcodeProjectPatcher.CheckConfiguration);
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(arg_22_0, XcodeProjectPatcher.f__mgcache7);
            XcodeProjectPatcher.CheckBundleId(UnityCompat.ApplicationId, true, true);
            XcodeProjectPatcher.CheckBuildEnvironment();
        }

        internal static void ReadConfig(bool errorOnNoConfig = true, string filename = null) {
            try {
                XcodeProjectPatcher.ReadConfigInternal(errorOnNoConfig, filename);
            } catch (Exception ex) {
                if (!(ex is FileNotFoundException) && !(ex is TypeInitializationException)) {
                    throw ex;
                }
                if (XcodeProjectPatcher.Enabled) {
                    Debug.LogWarning(DocStrings.DocRef.FailedToLoadIOSExtensions.String());
                }
            }
        }

        internal static void ReadConfigInternal(bool errorOnNoConfig, string filename = null) {
            XcodeProjectPatcher.configValues = new Dictionary<string, string>();
            XcodeProjectPatcher.configFile = (filename ?? XcodeProjectPatcher.FindConfig(errorOnNoConfig));
            if (XcodeProjectPatcher.configFile == null) {
                return;
            }
            PlistDocument plistDocument = new PlistDocument();
            plistDocument.ReadFromString(File.ReadAllText(XcodeProjectPatcher.configFile));
            PlistElementDict root = plistDocument.root;
            string[] pROJECT_KEYS = XcodeProjectPatcher.PROJECT_KEYS;
            for (int i = 0; i < pROJECT_KEYS.Length; i++) {
                string text = pROJECT_KEYS[i];
                PlistElement plistElement = root[text];
                if (plistElement != null) {
                    XcodeProjectPatcher.configValues[text] = plistElement.AsString();
                    if (object.Equals(text, "BUNDLE_ID")) {
                        XcodeProjectPatcher.allBundleIds.Add(plistElement.AsString());
                    }
                }
            }
        }

        internal static Dictionary<string, string> GetConfig() {
            return XcodeProjectPatcher.configValues;
        }

        private static void CheckBuildEnvironment() {
            if ((int)EditorUserBuildSettings.activeBuildTarget == 9 && Application.platform == RuntimePlatform.WindowsEditor) {
                Debug.LogError(DocStrings.DocRef.IOSNotSupportedOnWindows.String());
            }
        }

        private static void OnBundleIdChanged(object sender, PlayServicesResolver.BundleIdChangedEventArgs args) {
            XcodeProjectPatcher.ReadConfig(false, null);
            XcodeProjectPatcher.CheckBundleId(UnityCompat.ApplicationId, true, true);
        }

        private static string CheckBundleId(string bundleId, bool promptUpdate = true, bool logErrorOnMissingBundleId = true) {
            if (XcodeProjectPatcher.configFile == null) {
                return null;
            }
            Dictionary<string, string> config = XcodeProjectPatcher.GetConfig();
            string text;
            if (!config.TryGetValue("BUNDLE_ID", out text)) {
                return null;
            }
            if (!text.Equals(bundleId) && logErrorOnMissingBundleId && XcodeProjectPatcher.allBundleIds.Count > 0) {
                string[] array = XcodeProjectPatcher.allBundleIds.ToArray<string>();
                string errorMessage = DocStrings.DocRef.GoogleServicesFileBundleIdMissing.Format(new object[]
                {
                    bundleId,
                    "GoogleServices-Info.plist",
                    string.Join(", ", array),
                    DocStrings.Link.IOSAddApp
                });
                if (promptUpdate && !XcodeProjectPatcher.spamguard) {
                    ChooserDialog.Show("Please fix your Bundle ID", "Select a valid Bundle ID from your Firebase configuration.", string.Format("Your bundle ID {0} is not present in your Firebase configuration.  A mismatched bundle ID will result in your application to fail to initialize.\n\nNew Bundle ID:", bundleId), array, 0, "Apply", "Cancel", delegate (string selectedBundleId) {
                        if (!string.IsNullOrEmpty(selectedBundleId)) {
                            UnityCompat.ApplicationId = selectedBundleId;
                        } else {
                            XcodeProjectPatcher.spamguard = true;
                            Debug.LogError(errorMessage);
                        }
                        XcodeProjectPatcher.ReadConfig(true, null);
                    });
                } else {
                    Debug.LogError(errorMessage);
                }
            }
            return text;
        }

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath) {
            if (!XcodeProjectPatcher.Enabled) {
                return;
            }
            bool flag = false;
            for (int i = 0; i < importedAssets.Length; i++) {
                string path = importedAssets[i];
                if (Path.GetFileName(path) == "GoogleService-Info.plist") {
                    flag = true;
                    break;
                }
            }
            if (flag) {
                XcodeProjectPatcher.spamguard = false;
                XcodeProjectPatcher.ReadConfig(false, null);
                XcodeProjectPatcher.CheckBundleId(UnityCompat.ApplicationId, true, true);
            }
        }

        internal static string FindConfig(bool errorOnNoConfig = true) {
            string value = XcodeProjectPatcher.configFile;
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
            XcodeProjectPatcher.allBundleIds.Clear();
            string[] array = AssetDatabase.FindAssets("GoogleService-Info");
            for (int i = 0; i < array.Length; i++) {
                string text = array[i];
                string text2 = AssetDatabase.GUIDToAssetPath(text);
                if (Path.GetFileName(text2) == "GoogleService-Info.plist") {
                    sortedDictionary[text2] = text2;
                }
            }
            string[] array2 = new string[sortedDictionary.Keys.Count];
            sortedDictionary.Keys.CopyTo(array2, 0);
            string text3 = (array2.Length < 1) ? null : array2[0];
            if (array2.Length == 0) {
                if (errorOnNoConfig && XcodeProjectPatcher.Enabled) {
                    Debug.LogError(DocStrings.DocRef.GoogleServicesIOSFileMissing.Format(new object[]
                    {
                        "GoogleService-Info.plist",
                        DocStrings.Link.IOSAddApp
                    }));
                }
            } else if (array2.Length > 1) {
                string applicationId = UnityCompat.ApplicationId;
                string text4 = null;
                string[] array3 = array2;
                for (int j = 0; j < array3.Length; j++) {
                    string text5 = array3[j];
                    string filename = text5;
                    XcodeProjectPatcher.ReadConfig(true, filename);
                    string text6 = XcodeProjectPatcher.CheckBundleId(applicationId, true, false);
                    text4 = (text4 ?? text6);
                    if (text6 == applicationId) {
                        text3 = text5;
                        text4 = applicationId;
                    }
                }
                if (string.IsNullOrEmpty(value) || !text3.Equals(value)) {
                    Debug.LogWarning(DocStrings.DocRef.GoogleServicesFileMultipleFiles.Format(new object[]
                    {
                        "GoogleService-Info.plist",
                        text3,
                        text4,
                        string.Join("\n", array2)
                    }));
                }
            }
            return text3;
        }

        [PostProcessBuild(1)]
        internal static void OnPostProcessAddGoogleServicePlist(BuildTarget buildTarget, string pathToBuiltProject) {
            if (!XcodeProjectPatcher.Enabled) {
                return;
            }
            XcodeProjectPatcher.AddGoogleServicePlist(buildTarget, pathToBuiltProject);
        }

        internal static void AddGoogleServicePlist(BuildTarget buildTarget, string pathToBuiltProject) {
            XcodeProjectPatcher.ReadConfig(true, null);
            if (XcodeProjectPatcher.configFile == null) {
                return;
            }
            XcodeProjectPatcher.CheckBundleId(UnityCompat.ApplicationId, false, true);
            string fileName = Path.GetFileName(XcodeProjectPatcher.configFile);
            File.Copy(XcodeProjectPatcher.configFile, Path.Combine(pathToBuiltProject, fileName), true);
            string projectPath = IOSResolver.GetProjectPath(pathToBuiltProject);
            PBXProject pBXProject = new PBXProject();
            pBXProject.ReadFromString(File.ReadAllText(projectPath));
            pBXProject.AddFileToBuild(pBXProject.TargetGuidByName(IOSResolver.TARGET_NAME), pBXProject.AddFile(fileName, fileName, PBXSourceTree.Source));
            File.WriteAllText(projectPath, pBXProject.WriteToString());
        }

        [PostProcessBuild(1)]
        internal static void OnPostProcessReadAndApplyFirebaseConfig(BuildTarget buildTarget, string pathToBuiltProject) {
            if (!XcodeProjectPatcher.Enabled) {
                return;
            }
            XcodeProjectPatcher.ReadAndApplyFirebaseConfig(buildTarget, pathToBuiltProject);
        }

        internal static void ReadAndApplyFirebaseConfig(BuildTarget buildTarget, string pathToBuiltProject) {
            string text = "Firebase.Invites.dll";
            HashSet<string> hashSet = new HashSet<string>
            {
                "Firebase.Auth.dll",
                "Firebase.DynamicLinks.dll",
                text
            };
            bool flag = false;
            bool flag2 = false;
            string[] array = AssetDatabase.FindAssets("t:Object");
            for (int i = 0; i < array.Length; i++) {
                string text2 = array[i];
                string fileName = Path.GetFileName(AssetDatabase.GUIDToAssetPath(text2));
                if (hashSet.Contains(fileName)) {
                    flag = true;
                    flag2 = (fileName == text);
                }
            }
            if (!flag2 && !flag) {
                return;
            }
            XcodeProjectPatcher.ReadConfig(true, null);
            Dictionary<string, string> config = XcodeProjectPatcher.GetConfig();
            if (config.Count == 0) {
                return;
            }
            string text3 = null;
            string text4 = null;
            if (!config.TryGetValue("REVERSED_CLIENT_ID", out text3)) {
                Debug.LogError(DocStrings.DocRef.PropertyMissingForGoogleSignIn.Format(new object[]
                {
                    "GoogleService-Info.plist",
                    "REVERSED_CLIENT_ID",
                    DocStrings.Link.IOSAddApp
                }));
            }
            if (!config.TryGetValue("BUNDLE_ID", out text4)) {
                Debug.LogError(DocStrings.DocRef.PropertyMissingForGoogleSignIn.Format(new object[]
                {
                    "GoogleService-Info.plist",
                    "BUNDLE_ID",
                    DocStrings.Link.IOSAddApp
                }));
            }
            string path = Path.Combine(pathToBuiltProject, "Info.plist");
            PlistDocument plistDocument = new PlistDocument();
            plistDocument.ReadFromString(File.ReadAllText(path));
            PlistElementDict root = plistDocument.root;
            PlistElementArray plistElementArray = null;
            if (root.values.ContainsKey("CFBundleURLTypes")) {
                plistElementArray = root["CFBundleURLTypes"].AsArray();
            }
            if (plistElementArray == null) {
                plistElementArray = root.CreateArray("CFBundleURLTypes");
            }
            if (text3 != null) {
                PlistElementDict plistElementDict = plistElementArray.AddDict();
                plistElementDict.SetString("CFBundleTypeRole", "Editor");
                plistElementDict.SetString("CFBundleURLName", "google");
                plistElementDict.CreateArray("CFBundleURLSchemes").AddString(text3);
            }
            if (text4 != null) {
                PlistElementDict plistElementDict2 = plistElementArray.AddDict();
                plistElementDict2.SetString("CFBundleTypeRole", "Editor");
                plistElementDict2.SetString("CFBundleURLName", text4);
                plistElementDict2.CreateArray("CFBundleURLSchemes").AddString(text4);
            }
            if (flag2 && !root.values.ContainsKey("NSContactsUsageDescription")) {
                root.SetString("NSContactsUsageDescription", "Invite others to use the app.");
            }
            File.WriteAllText(path, plistDocument.WriteToString());
        }
    }
}
