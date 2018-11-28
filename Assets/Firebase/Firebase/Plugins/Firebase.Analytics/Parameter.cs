using System;
using System.Runtime.InteropServices;

namespace Firebase.Analytics {
    public sealed class Parameter : IDisposable {
        private HandleRef swigCPtr;

        private bool swigCMemOwn;

        internal Parameter(IntPtr cPtr, bool cMemoryOwn) {
            this.swigCMemOwn = cMemoryOwn;
            this.swigCPtr = new HandleRef(this, cPtr);
        }

        public Parameter(string parameterName, string parameterValue) : this(FirebaseAnalyticsPINVOKE.new_Parameter__SWIG_0(parameterName, parameterValue), true) {
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public Parameter(string parameterName, long parameterValue) : this(FirebaseAnalyticsPINVOKE.new_Parameter__SWIG_1(parameterName, parameterValue), true) {
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public Parameter(string parameterName, double parameterValue) : this(FirebaseAnalyticsPINVOKE.new_Parameter__SWIG_2(parameterName, parameterValue), true) {
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        internal static HandleRef getCPtr(Parameter obj) {
            return (obj != null) ? obj.swigCPtr : new HandleRef(null, IntPtr.Zero);
        }

        ~Parameter() {
            this.Dispose();
        }

        public void Dispose() {
            lock (this) {
                if (this.swigCPtr.Handle != IntPtr.Zero) {
                    if (this.swigCMemOwn) {
                        this.swigCMemOwn = false;
                        FirebaseAnalyticsPINVOKE.delete_Parameter(this.swigCPtr);
                    }
                    this.swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }
    }
}
