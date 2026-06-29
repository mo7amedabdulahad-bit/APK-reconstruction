// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Utilities
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class LocalStorageSaveHandler
	{
		// Methods
		public static void SaveForCurrentAvatar<T>(T data, string fileName) {}
		public static void Save<T>(T data, string fileName, string subfolder = null) {}
		public static T LoadForCurrentAvatar<T>(string fileName)
			where T : new() => default;
		public static T Load<T>(string fileName, string subfolder = null)
			where T : new() => default;
		public static bool Exists(string fileName, string subfolder = null) => default;
		public static void Delete(string fileName, string subfolder = null) {}
		private static string GetAvatarSaveFolder() => default;
		private static string GetPath(string fileName, string subfolder = null) => default;
	}
