using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Firebase.Editor
{
	internal class SettingsWindow : EditorWindow
	{
		private interface IMenuState
		{
			void OnGUI(Stack<SettingsWindow.IMenuState> menus);
		}

		private class MainMenuState : SettingsWindow.IMenuState
		{
			private Texture2D titleTexture;

			private Vector2 scrollBar;

			private List<ApiInfo> apis;

			public MainMenuState(params ApiInfo[] apis)
			{
				this.titleTexture = (Texture2D)EditorGUIUtility.Load("Firebase/firebase_lockup" + ((!EditorGUIUtility.isProSkin) ? string.Empty : "_dark") + ".png");
				this.apis = new List<ApiInfo>(apis);
			}

			void SettingsWindow.IMenuState.OnGUI(Stack<SettingsWindow.IMenuState> menus)
			{
				GUILayout.Label(this.titleTexture, new GUILayoutOption[0]);
				SettingsWindow.IndentedLabel(20, DocStrings.DocRef.FirebaseDescription.String());
				SettingsWindow.DrawLine();
				this.scrollBar = GUILayout.BeginScrollView(this.scrollBar, false, true, GUIStyle.none, GUI.skin.verticalScrollbar, new GUILayoutOption[0]);
				this.scrollBar.x = 0f;
				this.DrawConnectionInfo();
				SettingsWindow.DrawLine();
				foreach (ApiInfo current in this.apis)
				{
					this.DisplayApi(current, menus);
				}
				EditorGUILayout.EndScrollView();
			}

			private void DisplayApi(ApiInfo api, Stack<SettingsWindow.IMenuState> menus)
			{
				GUIContent content = new GUIContent("<b>" + api.Name.String() + "</b>\n" + api.Description.String(), api.Image);
				SettingsWindow.Indent(10, delegate
				{
					GUILayout.Label(content, new GUILayoutOption[0]);
				});
				SettingsWindow.IndentedButtonLink(20, api.GuideButton.String(), api.GuideLink.String());
				SettingsWindow.IndentedButtonLink(20, "Open API Reference", api.ApiReference.String());
				EditorGUILayout.Separator();
			}

			private void DrawConnectionInfo()
			{
				SettingsWindow.IndentedLabel(10, DocStrings.DocRef.Android.String(), EditorStyles.boldLabel);
				SettingsWindow.Indent(20, delegate
				{
					if (SettingsWindow.IsAndroidConnected())
					{
						GUILayout.Label(DocStrings.DocRef.AndroidConnected.String(), new GUILayoutOption[0]);
						SettingsWindow.IndentedButtonLink(0, DocStrings.DocRef.OpenConsole.String(), "https://console.firebase.google.com/project/" + SettingsWindow.s_androidProjectId + "/overview");
					}
					else
					{
						GUILayout.Label(DocStrings.DocRef.AndroidDisconnected.String(), new GUILayoutOption[0]);
						SettingsWindow.IndentedButtonLink(0, DocStrings.DocRef.LearnMore.String(), DocStrings.Link.AndroidSetup.String());
					}
				});
				SettingsWindow.IndentedLabel(10, DocStrings.DocRef.IOS.String(), EditorStyles.boldLabel);
				SettingsWindow.Indent(20, delegate
				{
					if (SettingsWindow.IsIosConnected())
					{
						GUILayout.Label(DocStrings.DocRef.IOSConnected.String(), new GUILayoutOption[0]);
						SettingsWindow.IndentedButtonLink(0, DocStrings.DocRef.OpenConsole.String(), "https://console.firebase.google.com/project/" + SettingsWindow.s_iosProjectId + "/overview");
					}
					else
					{
						GUILayout.Label(DocStrings.DocRef.IOSDisconnected.String(), new GUILayoutOption[0]);
						SettingsWindow.IndentedButtonLink(0, DocStrings.DocRef.LearnMore.String(), DocStrings.Link.IOSSetup.String());
					}
				});
			}
		}

		private static GUIStyle labelStyle;

		private SettingsWindow.IMenuState mainMenu;

		private Stack<SettingsWindow.IMenuState> menuStateStack;

		private static string s_androidProjectId;

		private static string s_iosProjectId;

		private static GUIStyle LabelStyle
		{
			get
			{
				if (SettingsWindow.labelStyle == null)
				{
					SettingsWindow.labelStyle = new GUIStyle(EditorStyles.label);
					SettingsWindow.labelStyle.richText = true;
					SettingsWindow.labelStyle.wordWrap = true;
				}
				return SettingsWindow.labelStyle;
			}
		}

		private SettingsWindow.IMenuState CurrentMenuState
		{
			get
			{
				if (this.menuStateStack.Count == 0)
				{
					return this.mainMenu;
				}
				return this.menuStateStack.Peek();
			}
		}

		[MenuItem("Window/Firebase")]
		public static void ShowWindow()
		{
			EditorWindow.GetWindow(typeof(SettingsWindow));
		}

		private void ResetStyles()
		{
			SettingsWindow.labelStyle = null;
		}

		private void OnInspectorUpdate()
		{
			object assetsChangedLock = SettingsWindowUpdater.assetsChangedLock;
			lock (assetsChangedLock)
			{
				if (SettingsWindowUpdater.assetsChanged)
				{
					this.OnFocus();
				}
				SettingsWindowUpdater.assetsChanged = false;
			}
		}

		private void SetTitle(string title)
		{
			Type type = base.GetType();
			PropertyInfo property = type.GetProperty("title");
			if (property != null)
			{
				property.SetValue(this, title, null);
			}
			else
			{
				this.SetTitleUnity5x(title);
			}
		}

		private void SetTitleUnity5x(string title)
		{
			base.titleContent.text = title;
			base.titleContent.image = null;
		}

		private void OnEnable()
		{
			this.mainMenu = new SettingsWindow.MainMenuState(new ApiInfo[]
			{
				ApiInfo.Analytics(),
				ApiInfo.Auth(),
				ApiInfo.CloudMessaging(),
				ApiInfo.Database(),
				ApiInfo.DynamicLinks(),
				ApiInfo.Functions(),
				ApiInfo.Invites(),
				ApiInfo.RemoteConfig(),
				ApiInfo.Storage()
			});
			this.menuStateStack = new Stack<SettingsWindow.IMenuState>();
			this.SetTitle("Firebase");
			this.ResetStyles();
		}

		private void OnFocus()
		{
			Dictionary<string, string> dictionary = GenerateXmlFromGoogleServicesJson.ReadProjectFields();
			if (!dictionary.TryGetValue("project_id", out SettingsWindow.s_androidProjectId))
			{
				SettingsWindow.s_androidProjectId = null;
			}
			XcodeProjectPatcher.ReadConfig(false, null);
			Dictionary<string, string> config = XcodeProjectPatcher.GetConfig();
			if (!config.TryGetValue("PROJECT_ID", out SettingsWindow.s_iosProjectId))
			{
				SettingsWindow.s_iosProjectId = null;
			}
			base.Repaint();
		}

		private static void DrawLine()
		{
			EditorGUILayout.Separator();
			GUILayout.Box(string.Empty, new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(true),
				GUILayout.Height(1f)
			});
			EditorGUILayout.Separator();
		}

		private static void Indent(int pixels, Action toIndent)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space((float)pixels);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			toIndent();
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
		}

		private static void IndentedLabel(int pixels, string text)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space((float)pixels);
			GUILayout.Label(text, new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
		}

		private static void IndentedLabel(int pixels, string text, GUIStyle style)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space((float)pixels);
			GUILayout.Label(text, style, new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
		}

		private static bool IndentedButton(int pixels, string text)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space((float)pixels);
			bool result = GUILayout.Button(text, new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(false)
			});
			GUILayout.EndHorizontal();
			return result;
		}

		private static bool IndentedButtonLink(int pixels, string text, string link)
		{
			bool flag = SettingsWindow.IndentedButton(pixels, text);
			if (flag)
			{
				Application.OpenURL(link + "?utm_referrer=unity");
			}
			return flag;
		}

		private void OnGUI()
		{
			GUIStyle label = GUI.skin.label;
			GUI.skin.label = SettingsWindow.LabelStyle;
			this.CurrentMenuState.OnGUI(this.menuStateStack);
			GUI.skin.label = label;
		}

		private static bool IsAndroidConnected()
		{
			return SettingsWindow.s_androidProjectId != null;
		}

		private static bool IsIosConnected()
		{
			return SettingsWindow.s_iosProjectId != null;
		}
	}
}
