using Firebase.Platform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace Firebase.Unity {
    internal class WWWHttpRequest : FirebaseHttpRequest {
        private Dictionary<string, string> _headers = new Dictionary<string, string>();

        private NameValueCollection _responseheaders = new NameValueCollection();

        private MemoryStream _requestBody = new MemoryStream();

        private string _error;

        private bool _executed;

        private byte[] _requestBodyBytes;

        private byte[] _responseBodyBytes;

        private int _responseCode = FirebaseHttpRequest.StatusNetworkUnavailable;

        private long _responseLength;

        public override Stream OutputStream {
            get {
                return this._requestBody;
            }
        }

        public override int ResponseCode {
            get {
                this.EnsureExecuted();
                return this._responseCode;
            }
        }

        public override NameValueCollection ResponseHeaderFields {
            get {
                this.EnsureExecuted();
                return this._responseheaders;
            }
        }

        public override long ResponseContentLength {
            get {
                this.EnsureExecuted();
                return this._responseLength;
            }
        }

        public override Stream InputStream {
            get {
                this.EnsureExecuted();
                if (this._responseBodyBytes != null) {
                    return new MemoryStream(this._responseBodyBytes);
                }
                return null;
            }
        }

        public override Stream ErrorStream {
            get {
                this.EnsureExecuted();
                if (this._responseBodyBytes != null) {
                    return new MemoryStream(this._responseBodyBytes);
                }
                return null;
            }
        }

        public WWWHttpRequest(Uri url) : base(url) {
        }

        public override void SetRequestProperty(string key, string value) {
            this._headers[key] = value;
        }

        private void EnsureExecuted() {
            if (!this._headers.ContainsKey("X-HTTP-Method-Override") && !string.Equals(this._action, "POST", StringComparison.OrdinalIgnoreCase) && !string.Equals(this._action, "GET", StringComparison.OrdinalIgnoreCase)) {
                this._headers["X-HTTP-Method-Override"] = this._action;
            }
            if (!this._executed) {
                this._responseCode = 0;
                Services.Logging.LogMessage(PlatformLogLevel.Verbose, "Requesting " + this._url.ToString());
                this._executed = true;
                this._requestBodyBytes = this._requestBody.ToArray();
                Services.Logging.LogMessage(PlatformLogLevel.Verbose, "Waiting for result of " + this._url.ToString());
                UnitySynchronizationContext.Instance.SendCoroutine(() => this.SendUnityRequest(), -1);
                if (!string.IsNullOrEmpty(this._error)) {
                    Services.Logging.LogMessage(PlatformLogLevel.Error, this._error);
                }
                if (this._responseCode == 0) {
                    Services.Logging.LogMessage(PlatformLogLevel.Verbose, "Response timed out waiting for result");
                    this._responseCode = FirebaseHttpRequest.StatusNetworkUnavailable;
                }
            }
        }

        [DebuggerHidden]//xia9000
        //private IEnumerator SendUnityRequest() {
        //    WWWHttpRequest.< SendUnityRequest > c__Iterator0 < SendUnityRequest > c__Iterator = new WWWHttpRequest.< SendUnityRequest > c__Iterator0();

        //    < SendUnityRequest > c__Iterator.$this = this;
        //    return < SendUnityRequest > c__Iterator;
        //}
        private IEnumerator SendUnityRequest() {
            if (_requestBodyBytes == null || _requestBodyBytes.Length == 0) {
                if (string.Equals(_action, "POST", StringComparison.OrdinalIgnoreCase)) {
                    _requestBodyBytes = System.Text.Encoding.ASCII.GetBytes("\n");
                } else {
                    _requestBodyBytes = null;
                }
            }
            Services.Logging.LogMessage(PlatformLogLevel.Verbose, "About to send message to " + _action + " -> " + _url.ToString());
            var locvar0 = _headers.GetEnumerator();

            try {
                while (locvar0.MoveNext()) {
                    KeyValuePair<string, string> current = locvar0.Current;
                    Services.Logging.LogMessage(PlatformLogLevel.Verbose, current.Key + ":" + current.Value);
                }
            } finally {
                ((IDisposable)locvar0).Dispose();
            }
            if (_requestBodyBytes != null) {
                Services.Logging.LogMessage(PlatformLogLevel.Verbose, "body size:" + _requestBodyBytes.Length.ToString());
            } else {
                Services.Logging.LogMessage(PlatformLogLevel.Debug, "body:{null}");
            }
            if (string.Equals(_action, "GET", StringComparison.OrdinalIgnoreCase) && !_headers.ContainsKey("Content-Type")) {
                _headers["Content-Type"] = string.Empty;
            }

            WWW www = new WWW(_url.ToString(), _requestBodyBytes, _headers);
            yield return www;
            TryParseResponse(www);
            _requestBodyBytes = www.bytes;
            _error = www.error;
        }

        private void TryParseResponse(WWW www) {
            if (this._responseCode == 0 && www.responseHeaders != null) {
                foreach (KeyValuePair<string, string> current in www.responseHeaders) {
                    this._responseheaders[current.Key.ToUpper()] = current.Value;
                }
                if (this._responseheaders[FirebaseHttpRequest.HeaderStatus] != null) {
                    this._responseCode = WWWHttpRequest.ParseIntHeader(this._responseheaders[FirebaseHttpRequest.HeaderStatus]);
                }
                if (this._responseheaders[FirebaseHttpRequest.HeaderContentLength] != null) {
                    this._responseLength = (long)WWWHttpRequest.ParseIntHeader(this._responseheaders[FirebaseHttpRequest.HeaderContentLength]);
                }
            }
        }

        private static int ParseIntHeader(string statusLine) {
            int result = 0;
            string[] array = statusLine.Split(new char[]
            {
                ' '
            });
            if (array.Length >= 3 && !int.TryParse(array[1], out result)) {
                Services.Logging.LogMessage(PlatformLogLevel.Error, "invalid header: " + array[1]);
            }
            return result;
        }
    }
}
