// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class DeepLinkProcessor
	{
		// Fields
		private static Dictionary<string, string> domainMap;
		private static readonly string[] possibleExtensions;
	
		// Constructors
		static DeepLinkProcessor() {}
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void LoadRemoteConfig() {}
		private static void OnFetchRemoteCompleted(ConfigResponse configResponse) {}
		private static string GetMappedBaseUrl(string host) => default;
		public static string ConvertDeepLinkToWebUrl(string deepLink) => default;
		private static string ConvertManually(string deepLink) => default;
	}
