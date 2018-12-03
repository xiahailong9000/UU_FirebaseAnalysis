// Copyright 2016 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Firebase.Sample.Analytics {
    using System;
    using System.Threading.Tasks;
    using UnityEngine;

    using Firebase;
    using Firebase.Analytics;

    // Handler for UI buttons on the scene.  Also performs some
    // necessary setup (initializing the firebase app, etc) on
    // startup.
    public class UIHandler : MonoBehaviour {
        public GUISkin fb_GUISkin;
        private Vector2 controlsScrollViewVector = Vector2.zero;
        private Vector2 scrollViewVector = Vector2.zero;
        bool UIEnabled = true;
        private string logText = "";
        const int kMaxLogSize = 16382;
        DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
        protected bool firebaseInitialized = false;

        // When the app starts, check to make sure that we have
        // the required dependencies to use Firebase, and if not,
        // add them if possible.
        public virtual void Start() {
            AppOptions app = new AppOptions() {
                AppId = "1:898200925370:android:5929dcbe0008296d",
                ApiKey = "AIzaSyDHPBbm8rKurctnZXxegGpxESGw-UoiuCk",
                ProjectId = "api-9101058431890075688-215796",
                MessageSenderId = "898200925370-haqpkh0jjaoreco3idi0fv2ltes2kh39.apps.googleusercontent.com",
            };
            FirebaseApp.Create(app,"Glider");
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available) {
                    InitializeFirebase();
                } else {
                    Debug.LogError("无法解析所有Firebase依赖项==Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
        }

        // Exit if escape (or back, on mobile) is pressed.
        public virtual void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }

        // Handle initialization of the necessary firebase modules:
        /// <summary>
        /// 处理必要的FixBASE模块的初始化：
        /// </summary>
        void InitializeFirebase() {
            DebugLog("启用数据收集。== Enabling data collection.");
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

            DebugLog("设置用户属性。== Set user properties.");
            // Set the user's sign up method.
            FirebaseAnalytics.SetUserProperty( FirebaseAnalytics.UserPropertySignUpMethod, "Google");
            // Set the user ID.
            FirebaseAnalytics.SetUserId("uber_user_510"+UnityEngine.Random.Range(0,4000));
            // Set default session duration values.
            FirebaseAnalytics.SetMinimumSessionDuration(new TimeSpan(0, 0, 10));
            FirebaseAnalytics.SetSessionTimeoutDuration(new TimeSpan(0, 30, 0));
            firebaseInitialized = true;
        }

        // End our analytics session when the program exits.
        void OnDestroy() { }
        /// <summary>
        /// 记录没有参数的事件。
        /// </summary>
        public void AnalyticsLogin() {
            // Log an event with no parameters.
            DebugLog("登录事件。==Logging a login event.");
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLogin);
        }
        /// <summary>
        /// 用浮点记录事件。
        /// </summary>
        public void AnalyticsProgress() {
            // Log an event with a float.
            DebugLog("正在记录进度事件。==Logging a progress event.");
            FirebaseAnalytics.LogEvent("progress", "percent", 0.4f);
        }
        /// <summary>
        /// 用int参数记录事件。
        /// </summary>
        public void AnalyticsScore() {
            // Log an event with an int parameter.
            DebugLog("记录后得分事件。== Logging a post-score event.");
            FirebaseAnalytics.LogEvent( FirebaseAnalytics.EventPostScore,FirebaseAnalytics.ParameterScore, 42);
        }
        /// <summary>
        /// 用字符串参数记录事件。
        /// </summary>
        public void AnalyticsGroupJoin() {
            // Log an event with a string parameter.
            DebugLog("记录组联接事件。==Logging a group join event.");
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventJoinGroup, FirebaseAnalytics.ParameterGroupId, "spoon_welders");
        }

        public void AnalyticsLevelUp() {
            // Log an event with multiple parameters.
            //记录具有多个参数的事件。
            DebugLog("记录升级事件。== Logging a level up event.");
            FirebaseAnalytics.LogEvent( 
                FirebaseAnalytics.EventLevelUp, 
                new Parameter(FirebaseAnalytics.ParameterLevel, 5), 
                new Parameter(FirebaseAnalytics.ParameterCharacter, "mrspoon"), 
                new Parameter("hit_accuracy", 3.14f)
                );
        }

        // Reset analytics data for this app instance.
        //重置此应用程序实例的分析数据。
        public void ResetAnalyticsData() {
            DebugLog("重置分析数据。== Reset analytics data.");
            FirebaseAnalytics.ResetAnalyticsData();
        }

        // Get the current app instance ID.
        //获取当前应用程序实例ID。
        public Task<string> DisplayAnalyticsInstanceId() {
            return FirebaseAnalytics.GetAnalyticsInstanceIdAsync().ContinueWith(task => {
                if (task.IsCanceled) {
                    DebugLog("APP实例ID获取被取消。 == App instance ID fetch was canceled.");
                } else if (task.IsFaulted) {
                    DebugLog(String.Format("枚举一个获取错误的应用程序实例ID== Encounted an error fetching app instance ID {0}", task.Exception.ToString()));
                } else if (task.IsCompleted) {
                    DebugLog(String.Format("App instance ID: {0}", task.Result));
                }
                return task;
            }).Unwrap();
        }

        // Output text to the debug log text field, as well as the console.
        //将文本输出到调试日志文本字段，以及控制台。
        public void DebugLog(string s) {
            print(s);
            logText += s + "\n";

            while (logText.Length > kMaxLogSize) {
                int index = logText.IndexOf("\n");
                logText = logText.Substring(index + 1);
            }

            scrollViewVector.y = int.MaxValue;
        }

        void DisableUI() {
            UIEnabled = false;
        }

        void EnableUI() {
            UIEnabled = true;
        }

        // Render the log output in a scroll view.
        void GUIDisplayLog() {
            scrollViewVector = GUILayout.BeginScrollView(scrollViewVector);
            GUILayout.Label(logText);
            GUILayout.EndScrollView();
        }

        // Render the buttons and other controls.
        void GUIDisplayControls() {
            if (UIEnabled) {
                controlsScrollViewVector = GUILayout.BeginScrollView(controlsScrollViewVector);
                GUILayout.BeginVertical();

                if (GUILayout.Button("Log Login")) {
                    AnalyticsLogin();
                }
                if (GUILayout.Button("Log Progress")) {
                    AnalyticsProgress();
                }
                if (GUILayout.Button("Log Score 对数记分法")) {
                    AnalyticsScore();
                }
                if (GUILayout.Button("Log Group Join")) {
                    AnalyticsGroupJoin();
                }
                if (GUILayout.Button("Log Level Up")) {
                    AnalyticsLevelUp();
                }
                if (GUILayout.Button("Reset Analytics Data")) {
                    ResetAnalyticsData();
                }
                if (GUILayout.Button("Show Analytics Instance ID")) {
                    DisplayAnalyticsInstanceId();
                }
                GUILayout.EndVertical();
                GUILayout.EndScrollView();
            }
        }

        // Render the GUI:
        void OnGUI() {
            GUI.skin = fb_GUISkin;
            if (dependencyStatus != DependencyStatus.Available) {
                GUILayout.Label("不存在一个或多个FieldBasic依赖项。== One or more Firebase dependencies are not present.");
                GUILayout.Label("当前依赖状态：== Current dependency status: " + dependencyStatus.ToString());
                return;
            }
            Rect logArea, controlArea;

            if (Screen.width < Screen.height) {
                // Portrait mode
                controlArea = new Rect(0.0f, 0.0f, Screen.width, Screen.height * 0.5f);
                logArea = new Rect(0.0f, Screen.height * 0.5f, Screen.width, Screen.height * 0.5f);
            } else {
                // Landscape mode
                controlArea = new Rect(0.0f, 0.0f, Screen.width * 0.5f, Screen.height);
                logArea = new Rect(Screen.width * 0.5f, 0.0f, Screen.width * 0.5f, Screen.height);
            }

            GUILayout.BeginArea(logArea);
            GUIDisplayLog();
            GUILayout.EndArea();

            GUILayout.BeginArea(controlArea);
            GUIDisplayControls();
            GUILayout.EndArea();
        }
    }
}
