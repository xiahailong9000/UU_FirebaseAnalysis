using Firebase.Unity;
using System;
using System.Threading;
using UnityEngine;

namespace Firebase.Platform
{
	internal sealed class FirebaseHandler
	{
		internal class ApplicationFocusChangedEventArgs : EventArgs
		{
			public bool HasFocus
			{
				get;
				set;
			}
		}

		private static FirebaseMonoBehaviour firebaseMonoBehaviour;

		private static FirebaseHandler firebaseHandler;

		internal event EventHandler<EventArgs> Updated
		{
			add
			{
				EventHandler<EventArgs> eventHandler = this.Updated;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange<EventHandler<EventArgs>>(ref this.Updated, (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value), eventHandler);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler<EventArgs> eventHandler = this.Updated;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange<EventHandler<EventArgs>>(ref this.Updated, (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value), eventHandler);
				}
				while (eventHandler != eventHandler2);
			}
		}

		internal event EventHandler<FirebaseHandler.ApplicationFocusChangedEventArgs> ApplicationFocusChanged{
			add{
				EventHandler<FirebaseHandler.ApplicationFocusChangedEventArgs> eventHandler = value;
				EventHandler<FirebaseHandler.ApplicationFocusChangedEventArgs> eventHandler2;
				do{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange<EventHandler<FirebaseHandler.ApplicationFocusChangedEventArgs>>(ref this.ApplicationFocusChanged, (EventHandler<FirebaseHandler.ApplicationFocusChangedEventArgs>)Delegate.Combine(eventHandler2, value), eventHandler);
				}
				while (eventHandler != eventHandler2);
			}
			remove{
				EventHandler<FirebaseHandler.ApplicationFocusChangedEventArgs> eventHandler = this.ApplicationFocusChanged;
				EventHandler<FirebaseHandler.ApplicationFocusChangedEventArgs> eventHandler2;
				do{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange<EventHandler<FirebaseHandler.ApplicationFocusChangedEventArgs>>(ref this.ApplicationFocusChanged, (EventHandler<FirebaseHandler.ApplicationFocusChangedEventArgs>)Delegate.Remove(eventHandler2, value), eventHandler);
				}
				while (eventHandler != eventHandler2);
			}
		}

		public static IFirebaseAppUtils AppUtils
		{
			get;
			private set;
		}

		private static Dispatcher ThreadDispatcher
		{
			get;
			set;
		}

		public bool IsPlayMode
		{
			get;
			set;
		}

		internal static FirebaseHandler DefaultInstance
		{
			get
			{
				return FirebaseHandler.firebaseHandler;
			}
		}

		static FirebaseHandler()
		{
			FirebaseHandler.AppUtils = FirebaseAppUtilsStub.Instance;
		}

		private FirebaseHandler()
		{
			if (Application.isEditor)
			{
				this.IsPlayMode = FirebaseEditorDispatcher.EditorIsPlaying;
				FirebaseEditorDispatcher.ListenToPlayState(true);
			}
			else
			{
				this.IsPlayMode = true;
			}
			if (this.IsPlayMode)
			{
				this.StartMonoBehaviour();
			}
			else
			{
				FirebaseEditorDispatcher.StartEditorUpdate();
			}
		}

		internal void StartMonoBehaviour()
		{
			if (FirebaseHandler.firebaseHandler == null)
			{
				FirebaseHandler.firebaseHandler = this;
			}
			GameObject gameObject = new GameObject("Firebase Services");
			FirebaseHandler.firebaseMonoBehaviour = gameObject.AddComponent<FirebaseMonoBehaviour>();
			UnitySynchronizationContext.Create(gameObject);
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
		}

		internal void StopMonoBehaviour()
		{
			if (FirebaseHandler.firebaseMonoBehaviour != null)
			{
				FirebaseHandler.RunOnMainThread<bool>(delegate
				{
					if (FirebaseHandler.firebaseMonoBehaviour != null)
					{
						UnitySynchronizationContext.Destroy();
						UnityEngine.Object.Destroy(FirebaseHandler.firebaseMonoBehaviour.gameObject);
					}
					return true;
				});
			}
		}

		public static TResult RunOnMainThread<TResult>(Func<TResult> f)
		{
			if (FirebaseHandler.ThreadDispatcher != null)
			{
				return FirebaseHandler.ThreadDispatcher.Run<TResult>(f);
			}
			return f();
		}

		internal bool IsMainThread()
		{
			return FirebaseHandler.ThreadDispatcher != null && FirebaseHandler.ThreadDispatcher.ManagesThisThread();
		}

		internal static void CreatePartialOnMainThread(IFirebaseAppUtils appUtils)
		{
			appUtils.TranslateDllNotFoundException(delegate
			{
				object typeFromHandle = typeof(FirebaseHandler);
				lock (typeFromHandle)
				{
					if (FirebaseHandler.firebaseHandler == null)
					{
						FirebaseHandler.AppUtils = appUtils;
						if (FirebaseHandler.ThreadDispatcher == null)
						{
							FirebaseHandler.ThreadDispatcher = new Dispatcher();
						}
						FirebaseHandler.firebaseHandler = new FirebaseHandler();
					}
				}
			});
		}

		internal static void Create(IFirebaseAppUtils appUtils)
		{
			FirebaseHandler.CreatePartialOnMainThread(appUtils);
			UnityPlatformServices.SetupServices();
		}

		internal void Update()
		{
			FirebaseHandler.ThreadDispatcher.PollJobs();
			FirebaseHandler.AppUtils.PollCallbacks();
			if (this.Updated != null)
			{
				this.Updated(this, null);
			}
		}

		internal void OnApplicationFocus(bool hasFocus)
		{
			if (this.ApplicationFocusChanged != null)
			{
				this.ApplicationFocusChanged(null, new FirebaseHandler.ApplicationFocusChangedEventArgs
				{
					HasFocus = hasFocus
				});
			}
		}

		internal static void Terminate()
		{
			if (FirebaseHandler.firebaseHandler != null)
			{
				FirebaseEditorDispatcher.Terminate(FirebaseHandler.firebaseHandler.IsPlayMode);
				FirebaseHandler.firebaseHandler.StopMonoBehaviour();
			}
			FirebaseHandler.firebaseHandler = null;
		}

		internal static void OnMonoBehaviourDestroyed(FirebaseMonoBehaviour behaviour)
		{
			if (behaviour == FirebaseHandler.firebaseMonoBehaviour)
			{
				FirebaseHandler.firebaseMonoBehaviour = null;
			}
		}
	}
}
