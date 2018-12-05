using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Analytics;
using UnityEngine;
using UnityEngine.UI;

public class C_Demo : MonoBehaviour {
    public Button LoginButton,
        progressButton,
        scoreButton,
        groupJoinButton,
        levelUpButton,
        resetDataButton,
        displayAppIdButton,
        SetUserButton,
        SetUserPropertyButton,
        SetUserProperty2Button,
        testEventButton;
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    bool firebaseInitialized = false;
    void Start() { 
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available) {
                try {
                    isCanInit = true;
                } catch { }
            } else {
                Debug.LogError("无法解析所有Firebase依赖项==Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }
    bool isCanInit;
    private void Update() {
        if (isCanInit) {
            isCanInit = false;
            Init();
        }
    }

    void Init() {
        AppOptions app = new AppOptions() {
            AppId = "1:898200925370:android:5929dcbe0008296d",
            ApiKey = "AIzaSyDHPBbm8rKurctnZXxegGpxESGw-UoiuCk",
            ProjectId = "api-9101058431890075688-215796",
            MessageSenderId = "898200925370-haqpkh0jjaoreco3idi0fv2ltes2kh39.apps.googleusercontent.com",
        };
        FirebaseApp.Create(app, "Glider");

        Debug.Log("启用数据收集");
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

        FirebaseAnalytics.SetUserId("testUserId");

        FirebaseAnalytics.SetUserProperty(FirebaseAnalytics.UserPropertySignUpMethod, "Google_" + UnityEngine.Random.Range(0, 4000));
      

        FirebaseAnalytics.SetMinimumSessionDuration(new TimeSpan(0, 0, 30));
        FirebaseAnalytics.SetSessionTimeoutDuration(new TimeSpan(0, 50, 0));
        LoginButton.onClick.AddListener(delegate () {
            AnalyticsLogin();
        });
        progressButton.onClick.AddListener(delegate () {
            AnalyticsProgress();
        });
        scoreButton.onClick.AddListener(delegate () {
            AnalyticsScore();
        });
     
        groupJoinButton.onClick.AddListener(delegate () {
            AnalyticsGroupJoin();
        });
        levelUpButton.onClick.AddListener(delegate () {
            AnalyticsLevelUp();
        });
        resetDataButton.onClick.AddListener(delegate () {
            ResetAnalyticsData();
        });
        displayAppIdButton.onClick.AddListener(delegate () {
            DisplayAnalyticsInstanceId();
        });
        SetUserButton.onClick.AddListener(delegate () {
            Debug.Log("设置userId");
            FirebaseAnalytics.SetUserId("user_" + UnityEngine.Random.Range(0, 4000));
        });
        SetUserPropertyButton.onClick.AddListener(delegate () {
            Debug.Log("设置user   flghtNumber");
            FirebaseAnalytics.SetUserProperty("flghtNumber", "shas--" + UnityEngine.Random.Range(0, 4000));
        });
        SetUserProperty2Button.onClick.AddListener(delegate () {
            Debug.Log("设置user   deathNumber");
            FirebaseAnalytics.SetUserProperty("deathNumber", "shas--" + UnityEngine.Random.Range(0, 4000));
        });
        testEventButton.onClick.AddListener(delegate () {
            FirebaseAnalytics.LogEvent("testEvent02","xiaName","夏海龙9000");
        });
    }
    /// <summary>
    /// 记录没有参数的事件。
    /// </summary>
    public void AnalyticsLogin() {
        Debug.Log("登录事件。==Logging a login event.");
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLogin);
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventSelectContent, "dsdsd" + UnityEngine.Random.Range(0, 4000), UnityEngine.Random.Range(0, 4000));
    }
    /// <summary>
    /// 用浮点记录事件。
    /// </summary>
    public void AnalyticsProgress() {
        Debug.Log("正在记录进度事件。==Logging a progress event.");
        FirebaseAnalytics.LogEvent("progress", "percent", 0.4f + UnityEngine.Random.Range(0, 4000));
    }
    /// <summary>
    /// 用int参数记录事件。
    /// </summary>
    public void AnalyticsScore() {
        Debug.Log("记录后得分事件。== Logging a post-score event.");
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventPostScore, FirebaseAnalytics.ParameterScore, 42);
    }
    /// <summary>
    /// 用字符串参数记录事件。
    /// </summary>
    public void AnalyticsGroupJoin() {
        Debug.Log("记录组联接事件。==Logging a group join event.");
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventJoinGroup, FirebaseAnalytics.ParameterGroupId, "spoon_welders");
    }
    public void AnalyticsLevelUp() {
        //记录具有多个参数的事件。
        Debug.Log("记录升级事件。== Logging a level up event.");
        FirebaseAnalytics.LogEvent(
            FirebaseAnalytics.EventLevelUp,
            new Parameter(FirebaseAnalytics.ParameterLevel, 5),
            new Parameter(FirebaseAnalytics.ParameterCharacter, "mrspoon"),
            new Parameter("hit_accuracy", 3.14f)
            );
    }
    //重置此应用程序实例的分析数据。
    public void ResetAnalyticsData() {
        Debug.Log("重置分析数据。== Reset analytics data.");
        FirebaseAnalytics.ResetAnalyticsData();
    }

    //获取当前应用程序实例ID。
    public Task<string> DisplayAnalyticsInstanceId() {
        return FirebaseAnalytics.GetAnalyticsInstanceIdAsync().ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.Log("APP实例ID获取被取消。 == App instance ID fetch was canceled.");
            } else if (task.IsFaulted) {
                Debug.Log(String.Format("枚举一个获取错误的应用程序实例ID== Encounted an error fetching app instance ID {0}", task.Exception.ToString()));
            } else if (task.IsCompleted) {
                Debug.Log(String.Format("App instance ID: {0}", task.Result));
            }
            return task;
        }).Unwrap();
    }


}
