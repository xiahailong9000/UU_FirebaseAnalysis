using System;
using System.Collections.Generic;

namespace Firebase.Editor
{
	internal static class DocStrings
	{
		public enum Link
		{
			AndroidSetup,
			AndroidAddApp,
			IOSSetup,
			IOSAddApp,
			AnalyticsGuide,
			AnalyticsReference,
			AuthGuide,
			AuthReference,
			CloudMessagingGuide,
			CloudMessagingReference,
			DatabaseGuide,
			DatabaseReference,
			DynamicLinksGuide,
			DynamicLinksReference,
			FunctionsGuide,
			FunctionsReference,
			InvitesGuide,
			InvitesReference,
			RemoteConfigGuide,
			RemoteConfigReference,
			StorageGuide,
			StorageReference
		}

		public class LinkToUrl : Dictionary<DocStrings.Link, string>
		{
		}

		public enum DocRef
		{
			Yes,
			No,
			Android,
			IOS,
			FirebaseDescription,
			OpenConsole,
			LearnMore,
			AndroidConnected,
			AndroidDisconnected,
			IOSConnected,
			IOSDisconnected,
			AnalyticsName,
			AnalyticsDescription,
			AnalyticsGuideSummary,
			AuthName,
			AuthDescription,
			AuthGuideSummary,
			CloudMessagingName,
			CloudMessagingDescription,
			CloudMessagingGuideSummary,
			DatabaseName,
			DatabaseDescription,
			DatabaseGuideSummary,
			DynamicLinksName,
			DynamicLinksDescription,
			DynamicLinksGuideSummary,
			FunctionsName,
			FunctionsDescription,
			FunctionsGuideSummary,
			InvitesName,
			InvitesDescription,
			InvitesGuideSummary,
			RemoteConfigName,
			RemoteConfigDescription,
			RemoteConfigGuideSummary,
			StorageName,
			StorageDescription,
			StorageGuideSummary,
			GoogleServicesAndroidGenerateXml,
			GoogleServicesAndroidFileMissing,
			GoogleServicesIOSFileMissing,
			GoogleServicesFileMultipleFiles,
			GoogleServicesMismatchedBundleId,
			GoogleServicesChangeBundleId,
			GoogleServicesFileBundleIdMissing,
			GoogleServicesAndroidGenerationFailed,
			GoogleServicesToolMissing,
			UnableToCreateDirectory,
			IOSNotSupportedOnWindows,
			FailedToLoadIOSExtensions,
			PropertyMissingForGoogleSignIn,
			DotNetSdkMismatchSummary,
			DotNetSdkMismatch,
			DotNetSdkChange,
			AndroidSdkVersionMismatchSummary,
			AndroidSdkVersionMismatch,
			AndroidSdkVersionChange,
			CouldNotCopyFile,
			CouldNotFindPlistOrJson,
			CouldNotTranslatePlist
		}

		public class DocRefToString : Dictionary<DocStrings.DocRef, string>
		{
		}

		public class Translations
		{
			private DocStrings.DocRefToString strings;

			private DocStrings.LinkToUrl links;

			public Translations(DocStrings.DocRefToString strings, DocStrings.LinkToUrl links)
			{
				this.strings = strings;
				this.links = links;
			}

			public string GetString(DocStrings.DocRef reference)
			{
				return this.strings[reference];
			}

			public string GetLink(DocStrings.Link link)
			{
				return this.links[link];
			}
		}

		private static Dictionary<string, DocStrings.LinkToUrl> LINKS_BY_LANGUAGE;

		private static Dictionary<string, DocStrings.DocRefToString> REFERENCE_BY_LANGUAGE;

		private static DocStrings.Translations translations;

		public static string Yes
		{
			get
			{
				return DocStrings.DocRef.Yes.String();
			}
		}

		public static string No
		{
			get
			{
				return DocStrings.DocRef.No.String();
			}
		}

		static DocStrings()
		{
			DocStrings.LINKS_BY_LANGUAGE = new Dictionary<string, DocStrings.LinkToUrl>
			{
				{
					"en",
					new DocStrings.LinkToUrl
					{
						{
							DocStrings.Link.AndroidSetup,
							"https://firebase.google.com/docs/unity/setup#setup_for_android"
						},
						{
							DocStrings.Link.AndroidAddApp,
							"https://firebase.google.com/docs/unity/setup#add_firebase_to_your_app_1"
						},
						{
							DocStrings.Link.IOSSetup,
							"https://firebase.google.com/docs/unity/setup#setup_for_ios"
						},
						{
							DocStrings.Link.IOSAddApp,
							"https://firebase.google.com/docs/unity/setup#add_firebase_to_your_app"
						},
						{
							DocStrings.Link.AnalyticsGuide,
							"https://firebase.google.com/docs/analytics/"
						},
						{
							DocStrings.Link.AnalyticsReference,
							"https://firebase.google.com/docs/reference/unity/namespace/firebase/analytics"
						},
						{
							DocStrings.Link.AuthGuide,
							"https://firebase.google.com/docs/auth/"
						},
						{
							DocStrings.Link.AuthReference,
							"https://firebase.google.com/docs/reference/unity/class/firebase/auth/firebase-auth"
						},
						{
							DocStrings.Link.CloudMessagingGuide,
							"https://firebase.google.com/docs/cloud-messaging/"
						},
						{
							DocStrings.Link.CloudMessagingReference,
							"https://firebase.google.com/docs/reference/unity/class/firebase/messaging/firebase-messaging"
						},
						{
							DocStrings.Link.DatabaseGuide,
							"https://firebase.google.com/docs/database/"
						},
						{
							DocStrings.Link.DatabaseReference,
							"https://firebase.google.com/docs/reference/unity/class/firebase/database/firebase-database"
						},
						{
							DocStrings.Link.DynamicLinksGuide,
							"https://firebase.google.com/docs/dynamic-links/"
						},
						{
							DocStrings.Link.DynamicLinksReference,
							"https://firebase.google.com/docs/reference/unity/class/firebase/dynamic-links/dynamic-links"
						},
						{
							DocStrings.Link.FunctionsGuide,
							"https://firebase.google.com/docs/functions/"
						},
						{
							DocStrings.Link.FunctionsReference,
							"https://firebase.google.com/docs/reference/unity/class/firebase/functions/firebase-functions"
						},
						{
							DocStrings.Link.InvitesGuide,
							"https://firebase.google.com/docs/invites/"
						},
						{
							DocStrings.Link.InvitesReference,
							"https://firebase.google.com/docs/reference/unity/class/firebase/invites/firebase-invites"
						},
						{
							DocStrings.Link.RemoteConfigGuide,
							"https://firebase.google.com/docs/remote-config/"
						},
						{
							DocStrings.Link.RemoteConfigReference,
							"https://firebase.google.com/docs/reference/unity/class/firebase/remote-config/firebase-remote-config"
						},
						{
							DocStrings.Link.StorageGuide,
							"https://firebase.google.com/docs/storage/"
						},
						{
							DocStrings.Link.StorageReference,
							"https://firebase.google.com/docs/reference/unity/class/firebase/storage/firebase-storage"
						}
					}
				}
			};
			DocStrings.REFERENCE_BY_LANGUAGE = new Dictionary<string, DocStrings.DocRefToString>
			{
				{
					"en",
					new DocStrings.DocRefToString
					{
						{
							DocStrings.DocRef.Yes,
							"Yes"
						},
						{
							DocStrings.DocRef.No,
							"No"
						},
						{
							DocStrings.DocRef.Android,
							"Android"
						},
						{
							DocStrings.DocRef.IOS,
							"iOS"
						},
						{
							DocStrings.DocRef.FirebaseDescription,
							"Firebase gives you the tools and infrastructure from Google to help you develop, grow and earn money from your app."
						},
						{
							DocStrings.DocRef.OpenConsole,
							"Open in Console"
						},
						{
							DocStrings.DocRef.LearnMore,
							"Learn More"
						},
						{
							DocStrings.DocRef.AndroidConnected,
							"Ready to use Firebase on Android."
						},
						{
							DocStrings.DocRef.AndroidDisconnected,
							"To connect Firebase for Android, add the google-services.json from Firebase to your Assets."
						},
						{
							DocStrings.DocRef.IOSConnected,
							"Ready to use Firebase on iOS."
						},
						{
							DocStrings.DocRef.IOSDisconnected,
							"To connect Firebase for iOS, add the GoogleService-Info.plist from Firebase to your Assets."
						},
						{
							DocStrings.DocRef.AnalyticsName,
							"Analytics"
						},
						{
							DocStrings.DocRef.AnalyticsDescription,
							"Measure user activity and engagement with free, easy, and unlimited analytics."
						},
						{
							DocStrings.DocRef.AnalyticsGuideSummary,
							"Log an Analytics event"
						},
						{
							DocStrings.DocRef.AuthName,
							"Authentication"
						},
						{
							DocStrings.DocRef.AuthDescription,
							"Sign in and manage users with ease, accepting emails, Google Sign-In, Facebook and other login providers."
						},
						{
							DocStrings.DocRef.AuthGuideSummary,
							"Email and password authentication"
						},
						{
							DocStrings.DocRef.CloudMessagingName,
							"Cloud Messaging"
						},
						{
							DocStrings.DocRef.CloudMessagingDescription,
							"Deliver and receive messages and notifications reliably across cloud and device."
						},
						{
							DocStrings.DocRef.CloudMessagingGuideSummary,
							"Set up Firebase Cloud Messaging"
						},
						{
							DocStrings.DocRef.DatabaseName,
							"Realtime Database"
						},
						{
							DocStrings.DocRef.DatabaseDescription,
							"Store and sync data across all clients in realtime."
						},
						{
							DocStrings.DocRef.DatabaseGuideSummary,
							"Set up Firebase Realtime Database"
						},
						{
							DocStrings.DocRef.DynamicLinksName,
							"Dynamic Links"
						},
						{
							DocStrings.DocRef.DynamicLinksDescription,
							"Send users to the right place in your app whether or not it is already installed."
						},
						{
							DocStrings.DocRef.DynamicLinksGuideSummary,
							"Set up Firebase Dynamic Links"
						},
						{
							DocStrings.DocRef.FunctionsName,
							"Cloud Functions for Firebase"
						},
						{
							DocStrings.DocRef.FunctionsDescription,
							"Call Cloud Functions directly from your app."
						},
						{
							DocStrings.DocRef.FunctionsGuideSummary,
							"Set up Cloud Functions for Firebase"
						},
						{
							DocStrings.DocRef.InvitesName,
							"Invites and Dynamic Links"
						},
						{
							DocStrings.DocRef.InvitesDescription,
							"Let your existing users easily share your app, or their favorite in-app content, via email or SMS."
						},
						{
							DocStrings.DocRef.InvitesGuideSummary,
							"Send Firebase invites from your app"
						},
						{
							DocStrings.DocRef.RemoteConfigName,
							"Remote Config"
						},
						{
							DocStrings.DocRef.RemoteConfigDescription,
							"Customize and experiment with app behavior using cloud-based configuration parameters."
						},
						{
							DocStrings.DocRef.RemoteConfigGuideSummary,
							"Set up Firebase Remote Config"
						},
						{
							DocStrings.DocRef.StorageName,
							"Storage"
						},
						{
							DocStrings.DocRef.StorageDescription,
							"Store files with ease."
						},
						{
							DocStrings.DocRef.StorageGuideSummary,
							"Set up Firebase Storage"
						},
						{
							DocStrings.DocRef.GoogleServicesAndroidGenerateXml,
							"Generated Firebase Android Resources file {0} from {1}\n\nExecuted {2}"
						},
						{
							DocStrings.DocRef.GoogleServicesAndroidFileMissing,
							"No {0} files found in your project so it is not possible to generate Firebase Android resources file {1}.\nBuilding without Firebase Android resources ({1}) will result in an app that will fail to initialize.\n\nTo resolve this problem, follow the setup instructions at {2}"
						},
						{
							DocStrings.DocRef.GoogleServicesIOSFileMissing,
							"No {0} files found in your project.\nBuilding without Firebase configuration will result in an app that will fail to initialize.\n\nTo resolve this problem, follow the setup instructions at {1}"
						},
						{
							DocStrings.DocRef.GoogleServicesFileMultipleFiles,
							"Multiple {0} files found in your project. Using {1} (bundle ID {2}) to configure Firebase.\n\nAll files present:\n{3}\n"
						},
						{
							DocStrings.DocRef.GoogleServicesMismatchedBundleId,
							"Incorrect Bundle ID"
						},
						{
							DocStrings.DocRef.GoogleServicesChangeBundleId,
							"Would you like to change your bundle ID from {0} to {1}?"
						},
						{
							DocStrings.DocRef.GoogleServicesFileBundleIdMissing,
							"Project Bundle ID {0} does not match any bundle IDs in your {1} files\nThis will result in an app that will fail to initialize.\n\nAvailable Bundle IDs:\n{2}\n\nYou need to either:\n* Fix your app's bundle ID under \"Player Settings --> Bundle Identifier\"\nor:\n* Add another app to your firebase project\n  Goto {3}\n  and add the new configuration file to your project.\n"
						},
						{
							DocStrings.DocRef.GoogleServicesAndroidGenerationFailed,
							"Generation of the Firebase Android resource file {0} from {1} failed.\nIf you have not included a valid Firebase Android resources in your app it will fail to initialize.\n{2}\n{3}\n\nYou can start to diagnose this issue by executing \"{2}\" from the command line."
						},
						{
							DocStrings.DocRef.GoogleServicesToolMissing,
							"Unable to find command line tool {0} required for Firebase Android resource generation.\n{0} is required to generate the Firebase Android resource file {1} from {2}. Without Firebase Android resources, your app will fail to initialize.\n{0} was distributed with each Firebase Unity SDK plugin, was it deleted?\n\n{3}"
						},
						{
							DocStrings.DocRef.UnableToCreateDirectory,
							"Failed to create directory {0}. Is the directory read-only?"
						},
						{
							DocStrings.DocRef.IOSNotSupportedOnWindows,
							"Firebase iOS builds are not supported on Windows. Please build on a OSX machine instead."
						},
						{
							DocStrings.DocRef.FailedToLoadIOSExtensions,
							"Failed to load the UnityEditor.iOS.Extensions.Xcode dll.\nIs iOS support installed?"
						},
						{
							DocStrings.DocRef.PropertyMissingForGoogleSignIn,
							"{0} file missing {1}, Google Sign-In will fail to initialize.\nTo resolve this issue follow the instructions at {2}"
						},
						{
							DocStrings.DocRef.DotNetSdkMismatchSummary,
							"Incorrect .Net Version."
						},
						{
							DocStrings.DocRef.DotNetSdkMismatch,
							"The Firebase Database requires the full .Net 2.0 SDK. It does not work with .Net 2.0 Subset.\n\nResolve this by changing the .Net SDK to \".NET 2.0\" in:\nBuild Settings -> Player Settings -> Other Settings -> Optimization -> Api Compatibility Level\n"
						},
						{
							DocStrings.DocRef.DotNetSdkChange,
							"Change .Net version?"
						},
						{
							DocStrings.DocRef.AndroidSdkVersionMismatchSummary,
							"Incorrect Minimum Android Version."
						},
						{
							DocStrings.DocRef.AndroidSdkVersionMismatch,
							"Minimum Target Android SDK needs to be set to level 14 or above.\n\nChange the Android SDK version to at least \"API level 14\" in:\nBuild Settings -> Player Settings -> Other Settings -> Identification -> Minimum API Level\n"
						},
						{
							DocStrings.DocRef.AndroidSdkVersionChange,
							"Change Android SDK Version?"
						},
						{
							DocStrings.DocRef.CouldNotCopyFile,
							"Could not copy file {0} to {1}."
						},
						{
							DocStrings.DocRef.CouldNotFindPlistOrJson,
							"Could not locate google-services.json or GoogleService-Info.plist files."
						},
						{
							DocStrings.DocRef.CouldNotTranslatePlist,
							"Could not parse the file {0} as a plist file.  Redownload from the firebase console?"
						}
					}
				}
			};
			DocStrings.translations = null;
			DocStrings.SetLanguage("en");
		}

		private static DocStrings.DocRefToString GetStrings(string language)
		{
			DocStrings.DocRefToString result;
			if (DocStrings.REFERENCE_BY_LANGUAGE.TryGetValue(language, out result))
			{
				return result;
			}
			return DocStrings.REFERENCE_BY_LANGUAGE["en"];
		}

		private static DocStrings.LinkToUrl GetLinks(string language)
		{
			DocStrings.LinkToUrl result;
			if (DocStrings.LINKS_BY_LANGUAGE.TryGetValue(language, out result))
			{
				return result;
			}
			return DocStrings.LINKS_BY_LANGUAGE["en"];
		}

		private static DocStrings.Translations GetTranslations(string language)
		{
			return new DocStrings.Translations(DocStrings.GetStrings(language), DocStrings.GetLinks(language));
		}

		public static void SetLanguage(string language)
		{
			DocStrings.translations = DocStrings.GetTranslations(language);
		}

		public static string String(this DocStrings.DocRef reference)
		{
			return DocStrings.translations.GetString(reference);
		}

		public static string Format(this DocStrings.DocRef reference, params object[] list)
		{
			object[] array = new object[Math.Max(list.Length, 10)];
			for (int i = list.Length; i < array.Length; i++)
			{
				array[i] = "<undefined>";
			}
			for (int j = 0; j < list.Length; j++)
			{
				object obj = list[j];
				Type type = obj.GetType();
				if (type == typeof(DocStrings.Link))
				{
					obj = ((DocStrings.Link)obj).String();
				}
				else if (type == typeof(DocStrings.DocRef))
				{
					obj = ((DocStrings.DocRef)obj).String();
				}
				array[j] = obj;
			}
			return string.Format(DocStrings.translations.GetString(reference), array);
		}

		public static string String(this DocStrings.Link link)
		{
			return DocStrings.translations.GetLink(link);
		}
	}
}
