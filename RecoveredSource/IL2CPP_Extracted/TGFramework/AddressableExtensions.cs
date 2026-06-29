// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class AddressableExtensions
	{
		// Fields
		private static Dictionary<AssetReference, List<System.Action>> assetCallbacks;
	
		// Constructors
		static AddressableExtensions() {}
	
		// Extension methods
		public static void GetAsset<T>(this AssetReference currentReference, Action<T> callback)
			where T : UnityEngine.Object {}
	}
