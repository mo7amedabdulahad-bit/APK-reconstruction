// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RepeatedCallHelper : IBootable
	{
		// Fields
		public static RepeatedCallHelper instance;
		private static List<CallbackInfo> repeatedCallbacks;
		private static ObjectPool<CallbackInfo> callbackInfoPool;
	
		// Nested types
		private class CallbackInfo
		{
			// Fields
			public System.Action callback;
			public float intervalTime;
			public float nextCallTime;
			public int intervalFrame;
			public int seedFrame;
			public GameObject checkGO;
			public bool shouldCheckGO;
			public bool oneTime;
	
			// Constructors
			public CallbackInfo() {}
	
			// Methods
			public bool Handle() => default;
			public void Clear() {}
		}
	
		// Constructors
		public RepeatedCallHelper() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		private static void HandleRepeatedCalls() {}
		public static void RepeatedCallingUnique(System.Action callback, float secondInterval = 1f, GameObject checkGO = null) {}
		public static void RepeatedCallingUnique(System.Action callback, int frameInterval, int frameSeed = 0, GameObject checkGO = null) {}
		public static void RepeatedCalling(System.Action callback, float secondInterval = 1f, GameObject checkGO = null) {}
		public static void RepeatedCalling(System.Action callback, int frameInterval, int frameSeed = 0, GameObject checkGO = null) {}
		public static void CallDelayed(System.Action callback, float secondDelay, GameObject checkGO = null) {}
		public static void CallDelayed(System.Action callback, int inFrames = 1, GameObject checkGO = null) {}
		public static void StopRepeatedCalling(System.Action callback) {}
	}
