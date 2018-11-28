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
    IEnumerator fff() {
        yield return new WaitForSeconds(0);
    }

    public class MyWait : IEnumerator {
        private int frame = 0;

        // 对应协程运行时，当前上下文的对象。
        // 比如指令 yield return object; 返回的值。
        public object Current { get { return null; } }

        // 判定协程是否运行结束
        public bool MoveNext() {
            if (++this.frame < 60) {
                return true;
            } else {
                return false;
            }
        }

        public void Reset() {
            this.frame = 0;
        }
    }
}
