using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Firebase.Editor {
    public class ChooserDialog : EditorWindow {
        private static string[] options;

        private static int selectedOption;

        private static string longHelpText;

        private static string shortHelpText;

        private static string applyButtonText;

        private static string cancelButtonText;

        private static string title;

        private static Action<string> onClickHandler;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcache0;

        [CompilerGenerated]
        private static EditorApplication.CallbackFunction f__mgcache1;

        public static void Show(string title, string longHelpText, string shortHelpText, string[] options, int initialSelection, string applyButtonText, string cancelButtonText, Action<string> onClickHandler) {
            ChooserDialog.longHelpText = longHelpText;
            ChooserDialog.shortHelpText = shortHelpText;
            ChooserDialog.options = options;
            ChooserDialog.selectedOption = initialSelection;
            ChooserDialog.applyButtonText = applyButtonText;
            ChooserDialog.cancelButtonText = cancelButtonText;
            ChooserDialog.onClickHandler = onClickHandler;
            ChooserDialog.title = title;
            Delegate arg_56_0 = EditorApplication.update;
            if (ChooserDialog.f__mgcache0 == null) {
                ChooserDialog.f__mgcache0 = new EditorApplication.CallbackFunction(ChooserDialog.ShowImpl);
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(arg_56_0, ChooserDialog.f__mgcache0);
        }

        private static void ShowImpl() {
            Delegate arg_22_0 = EditorApplication.update;
            if (ChooserDialog.f__mgcache1 == null) {
                ChooserDialog.f__mgcache1 = new EditorApplication.CallbackFunction(ChooserDialog.ShowImpl);
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(arg_22_0, ChooserDialog.f__mgcache1);
            EditorWindow window = EditorWindow.GetWindow(typeof(ChooserDialog), true, ChooserDialog.title);
            window.minSize = new Vector2(255f, 200f);
            window.position = new Rect((float)(Screen.width / 3), (float)(Screen.height / 3), window.minSize.x, window.minSize.y);
        }

        public void OnGUI() {
            GUI.skin.label.wordWrap = true;
            GUILayout.BeginVertical(new GUILayoutOption[0]);
            GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
            gUIStyle.normal.textColor = new Color(0.7f, 0.7f, 1f);
            GUILayout.Space(10f);
            GUIStyle gUIStyle2 = new GUIStyle(GUI.skin.label);
            gUIStyle2.fontStyle = FontStyle.Bold;
            GUILayout.Label(ChooserDialog.longHelpText, gUIStyle2, new GUILayoutOption[0]);
            GUILayout.Space(10f);
            GUILayout.Label(ChooserDialog.shortHelpText, new GUILayoutOption[0]);
            GUILayout.Space(5f);
            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
            GUILayout.Space(15f);
            if (ChooserDialog.options != null) {
                ChooserDialog.selectedOption = EditorGUILayout.Popup(ChooserDialog.selectedOption, ChooserDialog.options, new GUILayoutOption[0]);
            }
            GUILayout.Space(5f);
            GUILayout.EndHorizontal();
            GUILayout.Space(10f);
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
            GUILayout.FlexibleSpace();
            if (GUILayout.Button(ChooserDialog.applyButtonText, new GUILayoutOption[]
            {
                GUILayout.Width(100f)
            })) {
                if (ChooserDialog.onClickHandler != null) {
                    ChooserDialog.onClickHandler(ChooserDialog.options[ChooserDialog.selectedOption]);
                    ChooserDialog.onClickHandler = null;
                }
                base.Close();
            }
            if (GUILayout.Button(ChooserDialog.cancelButtonText, new GUILayoutOption[]
            {
                GUILayout.Width(100f)
            })) {
                if (ChooserDialog.onClickHandler != null) {
                    ChooserDialog.onClickHandler(null);
                    ChooserDialog.onClickHandler = null;
                }
                base.Close();
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.Space(10f);
            GUILayout.EndVertical();
        }

        public void OnDestroy() {
            if (ChooserDialog.onClickHandler != null) {
                ChooserDialog.onClickHandler(null);
                ChooserDialog.onClickHandler = null;
            }
        }

        protected void OnLostFocus() {
            base.Focus();
        }
    }
}
