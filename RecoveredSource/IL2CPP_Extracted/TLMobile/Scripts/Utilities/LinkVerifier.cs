// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class LinkVerifier
	{
		// Fields
		private static HashSet<string> allowedDomains;
		private static HashSet<string> allowedUrls;
	
		// Constructors
		static LinkVerifier() {}
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void LoadAllowedDomains() {}
		private static void OnFetchRemoteCompleted(ConfigResponse configResponse) {}
		private static List<string> ParseCsvToList(string csv) => default;
		public static void OpenExternalLinkInBrowser(string url) {}
		public static bool IsValidWebUrl(string url) => default;
		private static bool VerifiedHostOrUrl(Uri uri) => default;
	}
