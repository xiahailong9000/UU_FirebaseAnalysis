using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FirebaseAnalysisTest : MonoBehaviour {
    public Button sendEventButton,
        sendUserPropertyButton,
        sendScreenButton;

    void Start() {
        // 记录没有参数的事件。
        Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLogin);
        Firebase.Analytics.FirebaseAnalytics.SetUserId("testUserId");
        //用浮点参数记录事件
        sendEventButton.onClick.AddListener(delegate () {
            Firebase.Analytics.FirebaseAnalytics.LogEvent("progress-" + Random.Range(0, 10), "percent-" + Random.Range(0, 10), Random.Range(0.3f, 20.3f));
        });
        //用户属性上报
        sendEventButton.onClick.AddListener(delegate () {
            Firebase.Analytics.FirebaseAnalytics.SetUserProperty("TestProperty", "你妹的去死,,=====djsoooookkkkk__" + Random.Range(0, 20));
        });
        //用户属性上报
        sendScreenButton.onClick.AddListener(delegate () {
            Firebase.Analytics.FirebaseAnalytics.SetCurrentScreen("screenName_"+ Random.Range(0, 20), "screenClass_" + Random.Range(0, 20));
        });
    }
	
	void Update () {
		
	}
}
