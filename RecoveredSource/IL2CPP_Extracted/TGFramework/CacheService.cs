// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CacheService : IBootable
	{
		// Fields
		private static Dictionary<string, System.Type> knownClasses;
		private static Dictionary<string, ServerObject> cache;
		private static Dictionary<string, Dictionary<string, MemberInfo>> objectFieldInfo;
		private static Dictionary<string, Dictionary<string, MethodInfo>> objectMethodInfo;
		private static Dictionary<string, Dictionary<string, PropertyInfo>> objectPropertyInfo;
		private static List<ObjectRequestInfo> objIdsToFetchFromServer;
		private static string gameAssemblyString;
		public static Action<ServerObject, MessageForClient.SerializedObjectInformation> DecodeServerObject;
		public static Action<List<ObjectRequestInfo>> RequestObjectsFromServer;
		private static int fillCallNumber;
	
		// Properties
		public static IReadOnlyDictionary<string, ServerObject> Cache { get => default; }
	
		// Nested types
		public class ObjectRequestInfo
		{
			// Fields
			public string uniqueId;
			public ServerObject currentObject;
	
			// Constructors
			public ObjectRequestInfo() {}
		}
	
		// Constructors
		public CacheService() {}
		static CacheService() {}
	
		// Methods
		public IPromise Init(params object[] args) => default;
		public IPromise BootInstance(params object[] args) => default;
		public static void clearObjectInfoCache() {}
		public static void ResetCacheService() {}
		public static void ClearWholeCache(bool hardClear = false) {}
		public static Dictionary<string, MemberInfo> GetObjectInfo(System.Type objToAnalyze, int loopChk = 0) => default;
		public static Dictionary<string, PropertyInfo> GetObjectPropertyInfo(System.Type objToAnalyze) => default;
		public static Dictionary<string, MethodInfo> GetObjectMethods(System.Type objToAnalyze) => default;
		public static System.Type GetClassFromString(string className) => default;
		public static ServerObject GetWithoutCheck(string serverId) => default;
		public static ServerObject Get(string className, string serverId, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public static void AddToServerRequest(string serverId, ServerObject obj) {}
		public static void CheckForNeededServerRequests() {}
		public static string TotalDebugOutput() => default;
		private static void AnalyzeObserverStats(ref Dictionary<string, int> counter) {}
		public static void DoDebugCallbackAnalyzation(ref Dictionary<string, int> counter) {}
		public static List<ServerObject> Fill(MessageForClient msg, List<ServerObject> newFilledObjects = null) => default;
	}
