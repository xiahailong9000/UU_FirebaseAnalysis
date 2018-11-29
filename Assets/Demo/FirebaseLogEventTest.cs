using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseLogEventTest : MonoBehaviour {

	void Start () {
        // 记录没有参数的事件。
        Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLogin);

        //用浮点参数记录事件
        Firebase.Analytics.FirebaseAnalytics .LogEvent("progress2", "percent", 0.4f);
	}
	
	void Update () {
		
	}
}
