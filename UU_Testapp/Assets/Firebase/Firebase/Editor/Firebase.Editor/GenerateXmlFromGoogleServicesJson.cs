using Google;
using GooglePlayServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Firebase.Editor {
    [InitializeOnLoad]
    public class GenerateXmlFromGoogleServicesJson : AssetPostprocessor {
        private delegate void LogMessage(string message);

        private enum ConfigFileType {
            Plist,
            Json,
            Any
        }

        private enum FindGoogleServicesFileMode {
            ReturnBundleIdMatches,
            ReturnAll
        }

        private static string executable_Name_Windows;

        private static string executable_Name_Generic;

        private static string plugin_name;

        private static string executable_Location;

        private static string google_Services_File_BaseName;

        private static string google_services_input_file;

        private static string google_services_output_file;

        private static string google_services_output_directory;

        private static string google_services_output_path;

        private static string google_service_info_file_basename;

        private static string google_service_info_input_file;

        private static string google_services_desktop_output_file;

        private static string google_services_desktop_output_directory;

        private static string google_services_desktop_output_path;

        private static char[] newline_chars;

        private static char[] field_delimiter;

        private static bool spamguard;

        private static SortedDictionary<string, List<string>> ConfigFileDirectory;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcache0;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcache1;

        [CompilerGenerated]
        private static EventHandler<PlayServicesResolver.BundleIdChangedEventArgs> f__mgcache2;

        [CompilerGenerated]
        private static EventHandler<PlayServicesResolver.BundleIdChangedEventArgs> f__mgcache3;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcache4;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcache5;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcache6;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcache7;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcache8;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcache9;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcacheA;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcacheB;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcacheC;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcacheD;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcacheE;

        [CompilerGenerated]
        private static GenerateXmlFromGoogleServicesJson.LogMessage f__mgcacheF;

        private static bool XMLGenerationEnabled {
            get {
                return EditorUserBuildSettings.activeBuildTarget == (BuildTarget)13 && EditorPrefs.GetBool("Firebase.GenerateGoogleServicesXml", true);
            }
        }

        static GenerateXmlFromGoogleServicesJson() {
            GenerateXmlFromGoogleServicesJson.executable_Name_Windows = "generate_xml_from_google_services_json.exe";
            GenerateXmlFromGoogleServicesJson.executable_Name_Generic = "generate_xml_from_google_services_json.py";
            GenerateXmlFromGoogleServicesJson.plugin_name = "Firebase/Firebase";
            GenerateXmlFromGoogleServicesJson.executable_Location = Path.Combine(Path.Combine("Assets", GenerateXmlFromGoogleServicesJson.plugin_name), "Editor");
            GenerateXmlFromGoogleServicesJson.google_Services_File_BaseName = "google-services";
            GenerateXmlFromGoogleServicesJson.google_services_input_file = GenerateXmlFromGoogleServicesJson.google_Services_File_BaseName + ".json";
            GenerateXmlFromGoogleServicesJson.google_services_output_file = GenerateXmlFromGoogleServicesJson.google_Services_File_BaseName + ".xml";
            GenerateXmlFromGoogleServicesJson.google_services_output_directory = Path.Combine(Path.Combine(Path.Combine(Path.Combine(Path.Combine("Assets", "Plugins"), "Android"), "Firebase"), "res"), "values");
            GenerateXmlFromGoogleServicesJson.google_services_output_path = Path.Combine(GenerateXmlFromGoogleServicesJson.google_services_output_directory, GenerateXmlFromGoogleServicesJson.google_services_output_file);
            GenerateXmlFromGoogleServicesJson.google_service_info_file_basename = "GoogleService-Info";
            GenerateXmlFromGoogleServicesJson.google_service_info_input_file = GenerateXmlFromGoogleServicesJson.google_service_info_file_basename + ".plist";
            GenerateXmlFromGoogleServicesJson.google_services_desktop_output_file = GenerateXmlFromGoogleServicesJson.google_Services_File_BaseName + "-desktop.json";
            GenerateXmlFromGoogleServicesJson.google_services_desktop_output_directory = Path.Combine("Assets", "StreamingAssets");
            GenerateXmlFromGoogleServicesJson.google_services_desktop_output_path = Path.Combine(GenerateXmlFromGoogleServicesJson.google_services_desktop_output_directory, GenerateXmlFromGoogleServicesJson.google_services_desktop_output_file);
            GenerateXmlFromGoogleServicesJson.newline_chars = new char[]
            {
                '\r',
                '\n'
            };
            GenerateXmlFromGoogleServicesJson.field_delimiter = new char[]
            {
                '='
            };
            GenerateXmlFromGoogleServicesJson.ConfigFileDirectory = new SortedDictionary<string, List<string>>();
            if (VersionHandler.GetUnityVersionMajorMinor() >= 5f) {
                GenerateXmlFromGoogleServicesJson.CheckConfiguration();
            } else {
                Delegate arg_182_0 = EditorApplication.update;
                if (GenerateXmlFromGoogleServicesJson.f__mgcache0 == null) {
                    GenerateXmlFromGoogleServicesJson.f__mgcache0 = new EditorApplication.CallbackFunction(GenerateXmlFromGoogleServicesJson.CheckConfiguration);
                }
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(arg_182_0, GenerateXmlFromGoogleServicesJson.f__mgcache0);
                Delegate arg_1B3_0 = EditorApplication.update;
                if (GenerateXmlFromGoogleServicesJson.f__mgcache1 == null) {
                    GenerateXmlFromGoogleServicesJson.f__mgcache1 = new EditorApplication.CallbackFunction(GenerateXmlFromGoogleServicesJson.CheckConfiguration);
                }
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(arg_1B3_0, GenerateXmlFromGoogleServicesJson.f__mgcache1);
            }
            if (GenerateXmlFromGoogleServicesJson.f__mgcache2 == null) {
                GenerateXmlFromGoogleServicesJson.f__mgcache2 = new EventHandler<PlayServicesResolver.BundleIdChangedEventArgs>(GenerateXmlFromGoogleServicesJson.OnBundleIdChanged);
            }
            //PlayServicesResolver.remove_BundleIdChanged(GenerateXmlFromGoogleServicesJson.f__mgcache2);
            PlayServicesResolver.BundleIdChanged -= GenerateXmlFromGoogleServicesJson.f__mgcache2;
            if (GenerateXmlFromGoogleServicesJson.f__mgcache3 == null) {
                GenerateXmlFromGoogleServicesJson.f__mgcache3 = new EventHandler<PlayServicesResolver.BundleIdChangedEventArgs>(GenerateXmlFromGoogleServicesJson.OnBundleIdChanged);
            }
            //PlayServicesResolver.add_BundleIdChanged(GenerateXmlFromGoogleServicesJson.f__mgcache3);
            PlayServicesResolver.BundleIdChanged += GenerateXmlFromGoogleServicesJson.f__mgcache3;

        }

        private static void LogNoMessage(string message) {
        }

        private static void LogInfoIfEnabled(string message) {
            if (GenerateXmlFromGoogleServicesJson.XMLGenerationEnabled) {
                Debug.Log(message);
            }
        }

        private static void LogWarningIfEnabled(string message) {
            if (GenerateXmlFromGoogleServicesJson.XMLGenerationEnabled) {
                Debug.LogWarning(message);
            }
        }

        private static void LogErrorIfEnabled(string message) {
            if (GenerateXmlFromGoogleServicesJson.XMLGenerationEnabled) {
                Debug.LogError(message);
            }
        }

        private static void UpdateJson(bool ignoreModificationDate, GenerateXmlFromGoogleServicesJson.LogMessage logMessageForNoConfigFiles = null, GenerateXmlFromGoogleServicesJson.LogMessage logMessageForMissingBundleId = null) {
            GenerateXmlFromGoogleServicesJson.ConfigFileType arg_3D_0 = GenerateXmlFromGoogleServicesJson.ConfigFileType.Json;
            string arg_3D_1 = null;
            GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode arg_3D_2 = GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode.ReturnBundleIdMatches;
            if (GenerateXmlFromGoogleServicesJson.f__mgcache4 == null) {
                GenerateXmlFromGoogleServicesJson.f__mgcache4 = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogNoMessage);
            }
            GenerateXmlFromGoogleServicesJson.LogMessage arg_3D_3 = GenerateXmlFromGoogleServicesJson.f__mgcache4;
            if (GenerateXmlFromGoogleServicesJson.f__mgcache5 == null) {
                GenerateXmlFromGoogleServicesJson.f__mgcache5 = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogNoMessage);
            }
            string text = GenerateXmlFromGoogleServicesJson.FindGoogleServicesFile(arg_3D_0, arg_3D_1, arg_3D_2, arg_3D_3, GenerateXmlFromGoogleServicesJson.f__mgcache5);
            GenerateXmlFromGoogleServicesJson.ConfigFileType arg_80_0 = GenerateXmlFromGoogleServicesJson.ConfigFileType.Plist;
            string arg_80_1 = null;
            GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode arg_80_2 = GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode.ReturnBundleIdMatches;
            if (GenerateXmlFromGoogleServicesJson.f__mgcache6 == null) {
                GenerateXmlFromGoogleServicesJson.f__mgcache6 = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogNoMessage);
            }
            GenerateXmlFromGoogleServicesJson.LogMessage arg_80_3 = GenerateXmlFromGoogleServicesJson.f__mgcache6;
            if (GenerateXmlFromGoogleServicesJson.f__mgcache7 == null) {
                GenerateXmlFromGoogleServicesJson.f__mgcache7 = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogNoMessage);
            }
            string text2 = GenerateXmlFromGoogleServicesJson.FindGoogleServicesFile(arg_80_0, arg_80_1, arg_80_2, arg_80_3, GenerateXmlFromGoogleServicesJson.f__mgcache7);
            if (text != null) {
                GenerateXmlFromGoogleServicesJson.GenerateXmlResources(text, ignoreModificationDate);
            }
            bool flag = text != null || text2 != null;
            if (EditorUserBuildSettings.selectedBuildTargetGroup == (BuildTargetGroup)1 && !flag) {
                GenerateXmlFromGoogleServicesJson.ConfigFileType arg_F2_0 = GenerateXmlFromGoogleServicesJson.ConfigFileType.Any;
                string arg_F2_1 = null;
                GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode arg_F2_2 = GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode.ReturnAll;
                if (GenerateXmlFromGoogleServicesJson.f__mgcache8 == null) {
                    GenerateXmlFromGoogleServicesJson.f__mgcache8 = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogNoMessage);
                }
                GenerateXmlFromGoogleServicesJson.LogMessage arg_F2_3 = GenerateXmlFromGoogleServicesJson.f__mgcache8;
                if (GenerateXmlFromGoogleServicesJson.f__mgcache9 == null) {
                    GenerateXmlFromGoogleServicesJson.f__mgcache9 = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogNoMessage);
                }
                string text3 = GenerateXmlFromGoogleServicesJson.FindGoogleServicesFile(arg_F2_0, arg_F2_1, arg_F2_2, arg_F2_3, GenerateXmlFromGoogleServicesJson.f__mgcache9);
                if (text3 != null) {
                    if (GenerateXmlFromGoogleServicesJson.IsFileOfType(text3, GenerateXmlFromGoogleServicesJson.ConfigFileType.Json)) {
                        text = text3;
                    } else if (GenerateXmlFromGoogleServicesJson.IsFileOfType(text3, GenerateXmlFromGoogleServicesJson.ConfigFileType.Plist)) {
                        text2 = text3;
                    }
                    flag = (text != null || text2 != null);
                }
            }
            if (flag) {
                BuildTargetGroup selectedBuildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
                // IL_158:
                switch ((int)selectedBuildTargetGroup) {
                    case 1:
                        goto IL_187;
                    case 2:
                    case 3:
                         IL_158:
                        if ((int)selectedBuildTargetGroup != 7) {
                            goto IL_187;
                        }
                        goto IL_187;
                    case 4:
                        if (text2 != null) {
                            GenerateXmlFromGoogleServicesJson.CreateDesktopJsonFromPlist(text2);
                        } else if (text != null) {
                            GenerateXmlFromGoogleServicesJson.CreateDesktopJsonFromJson(text);
                        }
                        goto IL_1A9;
                    default:
                        goto IL_158;
                }
                IL_187:
                if (text != null) {
                    GenerateXmlFromGoogleServicesJson.CreateDesktopJsonFromJson(text);
                } else if (text2 != null) {
                    GenerateXmlFromGoogleServicesJson.CreateDesktopJsonFromPlist(text2);
                }
            IL_1A9:;
            } else {
                Debug.LogWarning(DocStrings.DocRef.CouldNotFindPlistOrJson.Format(new object[0]));
                GenerateXmlFromGoogleServicesJson.LogMessage arg_1E5_0;
                if ((arg_1E5_0 = logMessageForNoConfigFiles) == null) {
                    if (GenerateXmlFromGoogleServicesJson.f__mgcacheA == null) {
                        GenerateXmlFromGoogleServicesJson.f__mgcacheA = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogErrorIfEnabled);
                    }
                    arg_1E5_0 = GenerateXmlFromGoogleServicesJson.f__mgcacheA;
                }
                logMessageForNoConfigFiles = arg_1E5_0;
                logMessageForNoConfigFiles(DocStrings.DocRef.GoogleServicesFileBundleIdMissing.Format(new object[]
                {
                    UnityCompat.ApplicationId,
                    ((int)EditorUserBuildSettings.selectedBuildTargetGroup != 4) ? "google-services.json" : "GoogleService-Info.plist",
                    string.Join("\n", GenerateXmlFromGoogleServicesJson.BundleIdsFromBundleIdsByConfigFile(GenerateXmlFromGoogleServicesJson.ConfigFileDirectory).ToArray()),
                    DocStrings.Link.AndroidAddApp
                }));
            }
        }

        private static void CheckConfiguration() {
            Delegate arg_22_0 = EditorApplication.update;
            if (GenerateXmlFromGoogleServicesJson.f__mgcacheB == null) {
                GenerateXmlFromGoogleServicesJson.f__mgcacheB = new EditorApplication.CallbackFunction(GenerateXmlFromGoogleServicesJson.CheckConfiguration);
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(arg_22_0, GenerateXmlFromGoogleServicesJson.f__mgcacheB);
            GenerateXmlFromGoogleServicesJson.UpdateConfigFileDirectory();
            if (GenerateXmlFromGoogleServicesJson.XMLGenerationEnabled) {
                GenerateXmlFromGoogleServicesJson.UpdateJsonWithBundleIdChooserDialog(UnityCompat.ApplicationId, false);
            } else {
                GenerateXmlFromGoogleServicesJson.UpdateJson(false, null, null);
            }
        }

        private static void UpdateConfigFileDirectory() {
            GenerateXmlFromGoogleServicesJson.ConfigFileDirectory.Clear();
            string[] array = AssetDatabase.FindAssets("google");
            for (int i = 0; i < array.Length; i++) {
                string text = array[i];
                string text2 = AssetDatabase.GUIDToAssetPath(text);
                if (Path.GetFileName(text2) == GenerateXmlFromGoogleServicesJson.google_services_input_file || Path.GetFileName(text2) == GenerateXmlFromGoogleServicesJson.google_service_info_input_file) {
                    GenerateXmlFromGoogleServicesJson.ConfigFileDirectory[text2] = null;
                }
            }
            foreach (string current in new List<string>(GenerateXmlFromGoogleServicesJson.ConfigFileDirectory.Keys)) {
                GenerateXmlFromGoogleServicesJson.ConfigFileDirectory[current] = GenerateXmlFromGoogleServicesJson.ReadBundleIds(current);
            }
        }

        private static List<string> BundleIdsFromBundleIdsByConfigFile(SortedDictionary<string, List<string>> bundleIdsByConfigFile) {
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
            foreach (List<string> current in bundleIdsByConfigFile.Values) {
                foreach (string current2 in current) {
                    sortedDictionary[current2] = current2;
                }
            }
            return new List<string>(sortedDictionary.Keys);
        }

        private static bool IsFileOfType(string fileName, GenerateXmlFromGoogleServicesJson.ConfigFileType fileType) {
            switch (fileType) {
                case GenerateXmlFromGoogleServicesJson.ConfigFileType.Plist:
                    return fileName.EndsWith(".plist");
                case GenerateXmlFromGoogleServicesJson.ConfigFileType.Json:
                    return fileName.EndsWith(".json");
                case GenerateXmlFromGoogleServicesJson.ConfigFileType.Any:
                    return true;
                default:
                    return false;
            }
        }

        private static string FindGoogleServicesFile(GenerateXmlFromGoogleServicesJson.ConfigFileType fileType, string bundleId = null, GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode mode = GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode.ReturnBundleIdMatches, GenerateXmlFromGoogleServicesJson.LogMessage logMessageForNoConfigFiles = null, GenerateXmlFromGoogleServicesJson.LogMessage logMessageForMissingBundleId = null) {
            bundleId = (bundleId ?? UnityCompat.ApplicationId);
            if (GenerateXmlFromGoogleServicesJson.ConfigFileDirectory.Count == 0) {
                string message = DocStrings.DocRef.GoogleServicesAndroidFileMissing.Format(new object[]
                {
                    GenerateXmlFromGoogleServicesJson.google_services_input_file,
                    GenerateXmlFromGoogleServicesJson.google_services_output_file,
                    DocStrings.Link.AndroidSetup
                });
                GenerateXmlFromGoogleServicesJson.LogMessage arg_6A_0;
                if ((arg_6A_0 = logMessageForNoConfigFiles) == null) {
                    if (GenerateXmlFromGoogleServicesJson.f__mgcacheC == null) {
                        GenerateXmlFromGoogleServicesJson.f__mgcacheC = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogErrorIfEnabled);
                    }
                    arg_6A_0 = GenerateXmlFromGoogleServicesJson.f__mgcacheC;
                }
                logMessageForNoConfigFiles = arg_6A_0;
                logMessageForNoConfigFiles(message);
                return null;
            }
            string text = null;
            int num = 0;
            foreach (KeyValuePair<string, List<string>> current in GenerateXmlFromGoogleServicesJson.ConfigFileDirectory) {
                if (GenerateXmlFromGoogleServicesJson.IsFileOfType(current.Key, fileType) && (mode == GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode.ReturnAll || new HashSet<string>(current.Value).Contains(bundleId))) {
                    text = current.Key;
                    num++;
                }
            }
            if (text == null) {
                GenerateXmlFromGoogleServicesJson.LogMessage arg_119_0;
                if ((arg_119_0 = logMessageForMissingBundleId) == null) {
                    if (GenerateXmlFromGoogleServicesJson.f__mgcacheD == null) {
                        GenerateXmlFromGoogleServicesJson.f__mgcacheD = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogErrorIfEnabled);
                    }
                    arg_119_0 = GenerateXmlFromGoogleServicesJson.f__mgcacheD;
                }
                logMessageForMissingBundleId = arg_119_0;
                logMessageForMissingBundleId(DocStrings.DocRef.GoogleServicesFileBundleIdMissing.Format(new object[]
                {
                    bundleId,
                    (fileType != GenerateXmlFromGoogleServicesJson.ConfigFileType.Json) ? "GoogleService-Info.plist" : "google-services.json",
                    string.Join("\n", GenerateXmlFromGoogleServicesJson.BundleIdsFromBundleIdsByConfigFile(GenerateXmlFromGoogleServicesJson.ConfigFileDirectory).ToArray()),
                    DocStrings.Link.AndroidAddApp
                }));
            } else if (num > 1 && mode != GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode.ReturnAll) {
                GenerateXmlFromGoogleServicesJson.LogInfoIfEnabled(DocStrings.DocRef.GoogleServicesFileMultipleFiles.Format(new object[]
                {
                    (fileType != GenerateXmlFromGoogleServicesJson.ConfigFileType.Plist) ? GenerateXmlFromGoogleServicesJson.google_service_info_input_file : GenerateXmlFromGoogleServicesJson.google_services_input_file,
                    text,
                    bundleId,
                    string.Join("\n", new List<string>(GenerateXmlFromGoogleServicesJson.ConfigFileDirectory.Keys).ToArray())
                }));
            }
            return text;
        }

        private static List<string> ReadBundleIds(string googleServicesFile) {
            string str = (!GenerateXmlFromGoogleServicesJson.IsFileOfType(googleServicesFile, GenerateXmlFromGoogleServicesJson.ConfigFileType.Plist)) ? string.Empty : " --plist";
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
            CommandLine.Result result = GenerateXmlFromGoogleServicesJson.RunResourceGenerator("-i \"" + googleServicesFile + "\" -l" + str, googleServicesFile, false);
            if (result.exitCode == 0) {
                string[] array = result.stdout.Split(GenerateXmlFromGoogleServicesJson.newline_chars);
                for (int i = 0; i < array.Length; i++) {
                    string text = array[i];
                    if (!string.IsNullOrEmpty(text)) {
                        sortedDictionary[text] = text;
                    }
                }
            }
            return new List<string>(sortedDictionary.Keys);
        }

        private static Dictionary<string, string> ReadProjectFields(string googleServicesFile) {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            CommandLine.Result result = GenerateXmlFromGoogleServicesJson.RunResourceGenerator("-i \"" + googleServicesFile + "\" -f", googleServicesFile, false);
            if (result.exitCode == 0) {
                string[] array = result.stdout.Split(GenerateXmlFromGoogleServicesJson.newline_chars);
                for (int i = 0; i < array.Length; i++) {
                    string text = array[i];
                    string[] array2 = text.Split(GenerateXmlFromGoogleServicesJson.field_delimiter);
                    if (array2.Length == 2) {
                        dictionary[array2[0]] = array2[1];
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, string> ReadProjectFields() {
            string text = GenerateXmlFromGoogleServicesJson.FindGoogleServicesFile(GenerateXmlFromGoogleServicesJson.ConfigFileType.Json, null, GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode.ReturnBundleIdMatches, null, null);
            if (text != null) {
                return GenerateXmlFromGoogleServicesJson.ReadProjectFields(text);
            }
            return new Dictionary<string, string>();
        }

        private static void OnBundleIdChanged(object sender, PlayServicesResolver.BundleIdChangedEventArgs args) {
            GenerateXmlFromGoogleServicesJson.UpdateJsonWithBundleIdChooserDialog(args.BundleId, true);
        }

        private static void UpdateJsonWithBundleIdChooserDialog(string bundleId, bool ignoreModificationDate) {
            GenerateXmlFromGoogleServicesJson.ConfigFileType configFileType;
            if ((int)EditorUserBuildSettings.selectedBuildTargetGroup == 7) {
                configFileType = GenerateXmlFromGoogleServicesJson.ConfigFileType.Json;
            } else {
                if ((int)EditorUserBuildSettings.selectedBuildTargetGroup != 4) {
                    return;
                }
                configFileType = GenerateXmlFromGoogleServicesJson.ConfigFileType.Plist;
            }
            GenerateXmlFromGoogleServicesJson.ConfigFileType arg_62_0 = configFileType;
            GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode arg_62_2 = GenerateXmlFromGoogleServicesJson.FindGoogleServicesFileMode.ReturnBundleIdMatches;
            if (GenerateXmlFromGoogleServicesJson.f__mgcacheE == null) {
                GenerateXmlFromGoogleServicesJson.f__mgcacheE = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogNoMessage);
            }
            GenerateXmlFromGoogleServicesJson.LogMessage arg_62_3 = GenerateXmlFromGoogleServicesJson.f__mgcacheE;
            if (GenerateXmlFromGoogleServicesJson.f__mgcacheF == null) {
                GenerateXmlFromGoogleServicesJson.f__mgcacheF = new GenerateXmlFromGoogleServicesJson.LogMessage(GenerateXmlFromGoogleServicesJson.LogNoMessage);
            }
            if (GenerateXmlFromGoogleServicesJson.FindGoogleServicesFile(arg_62_0, bundleId, arg_62_2, arg_62_3, GenerateXmlFromGoogleServicesJson.f__mgcacheF) != null || UnityCompat.InBatchMode) {
                GenerateXmlFromGoogleServicesJson.UpdateJson(UnityCompat.InBatchMode, null, null);
                return;
            }
            List<string> list = GenerateXmlFromGoogleServicesJson.BundleIdsFromBundleIdsByConfigFile(GenerateXmlFromGoogleServicesJson.ConfigFileDirectory);
            if (GenerateXmlFromGoogleServicesJson.spamguard || list.Count == 0) {
                return;
            }
            ChooserDialog.Show("请修复您的Bundle ID  大哥!!", "从Firebase配置中选择一个有效的Bundle ID", string.Format("您的捆绑包ID {0}不存在于您的FialBasic配置中。不匹配的捆绑ID会导致应用程序无法初始化。", bundleId), list.ToArray(), 0, "Apply", "Cancel", delegate (string selectedBundleId) {
                if (!string.IsNullOrEmpty(selectedBundleId)) {
                    UnityCompat.ApplicationId = selectedBundleId;
                } else {
                    GenerateXmlFromGoogleServicesJson.spamguard = true;
                }
                GenerateXmlFromGoogleServicesJson.UpdateJson(true, null, null);
            });
            //ChooserDialog.Show("Please fix your Bundle ID", "Select a valid Bundle ID from your Firebase configuration.", string.Format("Your bundle ID {0} is not present in your Firebase configuration.  A mismatched bundle ID will result in your application to fail to initialize.\n\nNew Bundle ID:", bundleId), list.ToArray(), 0, "Apply", "Cancel", delegate (string selectedBundleId) {
            //    if (!string.IsNullOrEmpty(selectedBundleId)) {
            //        UnityCompat.ApplicationId = selectedBundleId;
            //    } else {
            //        GenerateXmlFromGoogleServicesJson.spamguard = true;
            //    }
            //    GenerateXmlFromGoogleServicesJson.UpdateJson(true, null, null);
            //});
        }

        private static string GetProjectDir() {
            return Path.Combine(Application.dataPath, "..");
        }

        private static CommandLine.Result RunResourceGenerator(string arguments, string inputPath, bool showCommandLine = true) {
            bool flag = Application.platform == RuntimePlatform.WindowsEditor;
            string text = Path.Combine(Path.Combine(GenerateXmlFromGoogleServicesJson.GetProjectDir(), GenerateXmlFromGoogleServicesJson.executable_Location), (!flag) ? GenerateXmlFromGoogleServicesJson.executable_Name_Generic : GenerateXmlFromGoogleServicesJson.executable_Name_Windows);
            string text2;
            string text3;
            if (flag) {
                text2 = text;
                text3 = arguments;
            } else {
                text2 = "python";
                text3 = "\"" + text + "\" " + arguments;
            }
            string text4 = string.Concat(new string[]
            {
                "`",
                text2,
                " ",
                text3,
                "`."
            });
            CommandLine.Result result = new CommandLine.Result {
                exitCode = 1
            };
            try {
                result = CommandLine.Run(text2, text3, null, null, null);
            } catch (Win32Exception ex) {
                Debug.LogError(DocStrings.DocRef.GoogleServicesToolMissing.Format(new object[]
                {
                    text2,
                    GenerateXmlFromGoogleServicesJson.google_services_output_file,
                    inputPath,
                    ex.ToString()
                }));
                return result;
            }
            if (result.exitCode == 0) {
                if (showCommandLine) {
                    Debug.Log(DocStrings.DocRef.GoogleServicesAndroidGenerateXml.Format(new object[]
                    {
                        GenerateXmlFromGoogleServicesJson.google_services_output_path,
                        inputPath,
                        text4
                    }));
                }
            } else {
                Debug.LogError(DocStrings.DocRef.GoogleServicesAndroidGenerationFailed.Format(new object[]
                {
                    GenerateXmlFromGoogleServicesJson.google_services_output_file,
                    inputPath,
                    text4,
                    result.stdout + "\n" + result.stderr + "\n"
                }));
            }
            return result;
        }

        private static void GenerateXmlResources(string googleServicesFile, bool ignoreModificationDate) {
            if (!GenerateXmlFromGoogleServicesJson.XMLGenerationEnabled) {
                return;
            }
            string projectDir = GenerateXmlFromGoogleServicesJson.GetProjectDir();
            string text = Path.Combine(projectDir, GenerateXmlFromGoogleServicesJson.google_services_output_directory);
            if (!Directory.Exists(text)) {
                try {
                    Directory.CreateDirectory(text);
                } catch (Exception exception) {
                    Debug.LogError(DocStrings.DocRef.GoogleServicesAndroidGenerationFailed.Format(new object[]
                    {
                        GenerateXmlFromGoogleServicesJson.google_services_output_path,
                        googleServicesFile,
                        DocStrings.DocRef.UnableToCreateDirectory.Format(new object[]
                        {
                            text
                        }),
                        string.Empty
                    }));
                    Debug.LogException(exception);
                    return;
                }
            }
            string text2 = Path.Combine(projectDir, googleServicesFile);
            string text3 = Path.Combine(projectDir, GenerateXmlFromGoogleServicesJson.google_services_output_path);
            if (!ignoreModificationDate && File.Exists(text3) && File.GetLastWriteTime(text3).CompareTo(File.GetLastWriteTime(text2)) >= 0) {
                return;
            }
            GenerateXmlFromGoogleServicesJson.RunResourceGenerator(string.Concat(new string[]
            {
                "-i \"",
                text2,
                "\" -o \"",
                text3,
                "\" -p \"",
                UnityCompat.ApplicationId,
                "\""
            }), text2, true);
        }

        private static void CreateDesktopJsonFromPlist(string sourceFilename) {
            string projectDir = GenerateXmlFromGoogleServicesJson.GetProjectDir();
            string text = Path.Combine(projectDir, sourceFilename);
            string text2 = Path.Combine(projectDir, GenerateXmlFromGoogleServicesJson.google_services_desktop_output_path);
            if (File.Exists(text2) && File.GetLastWriteTime(text2).CompareTo(File.GetLastWriteTime(text)) >= 0) {
                return;
            }
            if (GenerateXmlFromGoogleServicesJson.PrepareJsonDirectory()) {
                CommandLine.Result result = GenerateXmlFromGoogleServicesJson.RunResourceGenerator(string.Concat(new string[]
                {
                    "-i \"",
                    text,
                    "\" -o \"",
                    text2,
                    "\" --plist"
                }), sourceFilename, false);
                if (result.exitCode != 0) {
                    Debug.LogError(DocStrings.DocRef.CouldNotTranslatePlist.Format(new object[]
                    {
                        sourceFilename
                    }));
                }
            }
        }

        private static void CreateDesktopJsonFromJson(string sourceFilename) {
            string projectDir = GenerateXmlFromGoogleServicesJson.GetProjectDir();
            string path = Path.Combine(projectDir, sourceFilename);
            string path2 = Path.Combine(projectDir, GenerateXmlFromGoogleServicesJson.google_services_desktop_output_path);
            if (File.Exists(path2) && File.GetLastWriteTime(path2).CompareTo(File.GetLastWriteTime(path)) >= 0) {
                return;
            }
            if (GenerateXmlFromGoogleServicesJson.PrepareJsonDirectory()) {
                try {
                    AssetDatabase.CopyAsset(sourceFilename, GenerateXmlFromGoogleServicesJson.google_services_desktop_output_path);
                } catch {
                    Debug.LogError(DocStrings.DocRef.CouldNotCopyFile.Format(new object[]
                    {
                        Path.Combine(projectDir, sourceFilename),
                        Path.Combine(projectDir, GenerateXmlFromGoogleServicesJson.google_services_desktop_output_path)
                    }));
                }
            }
        }

        private static bool PrepareJsonDirectory() {
            string text = Path.Combine(GenerateXmlFromGoogleServicesJson.GetProjectDir(), GenerateXmlFromGoogleServicesJson.google_services_desktop_output_directory);
            if (!Directory.Exists(text)) {
                try {
                    Directory.CreateDirectory(text);
                } catch (Exception exception) {
                    Debug.LogError(DocStrings.DocRef.UnableToCreateDirectory.Format(new object[]
                    {
                        text
                    }));
                    Debug.LogException(exception);
                    return false;
                }
                return true;
            }
            return true;
        }

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath) {
            //Debug.Log("oooooooooooooooooooooo");
            bool flag = false;
            for (int i = 0; i < importedAssets.Length; i++) {
                string path = importedAssets[i];
                string fileName = Path.GetFileName(path);
                if (fileName == GenerateXmlFromGoogleServicesJson.google_services_input_file || fileName == GenerateXmlFromGoogleServicesJson.google_service_info_input_file) {
                    flag = true;
                    break;
                }
            }
            for (int j = 0; j < deletedAssets.Length; j++) {
                string a = deletedAssets[j];
                if (a == GenerateXmlFromGoogleServicesJson.google_services_desktop_output_path) {
                    flag = true;
                    break;
                }
            }
            for (int k = 0; k < movedAssets.Length; k++) {
                string a2 = movedAssets[k];
                if (a2 == GenerateXmlFromGoogleServicesJson.google_services_desktop_output_path) {
                    flag = true;
                    break;
                }
            }
            if (flag) {
                GenerateXmlFromGoogleServicesJson.UpdateConfigFileDirectory();
                GenerateXmlFromGoogleServicesJson.spamguard = false;
                GenerateXmlFromGoogleServicesJson.UpdateJson(true, null, null);
            }
        }

        public static void ForceJsonUpdate(bool canPromptToChangePackageId = false) {
            GenerateXmlFromGoogleServicesJson.spamguard = !canPromptToChangePackageId;
            GenerateXmlFromGoogleServicesJson.UpdateConfigFileDirectory();
            GenerateXmlFromGoogleServicesJson.UpdateJson(true, null, null);
        }
    }
}
