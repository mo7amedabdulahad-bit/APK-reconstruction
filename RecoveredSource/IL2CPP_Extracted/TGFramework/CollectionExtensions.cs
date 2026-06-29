// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class CollectionExtensions
	{
		// Extension methods
		public static ObservableDictionary<TInnerKey, TInnerValue> GetAsserted<TKey, TInnerKey, TInnerValue>(this IDictionary<TKey, ObservableDictionary<TInnerKey, TInnerValue>> dictionary, TKey key) => default;
		public static Dictionary<TInnerKey, TInnerValue> GetAsserted<TKey, TInnerKey, TInnerValue>(this IDictionary<TKey, Dictionary<TInnerKey, TInnerValue>> dictionary, TKey key) => default;
		public static ObservableList<TValue> GetAsserted<TKey, TValue>(this IDictionary<TKey, ObservableList<TValue>> dictionary, TKey key) => default;
		public static List<TValue> GetAsserted<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary, TKey key) => default;
		public static HashSet<TValue> GetAsserted<TKey, TValue>(this IDictionary<TKey, HashSet<TValue>> dictionary, TKey key) => default;
		public static bool GetAsserted<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary, TKey key, out List<TValue> listForKey) {
			listForKey = default;
			return default;
		}
		public static bool GetAsserted<TKey, TValue>(this IDictionary<TKey, ObservableList<TValue>> dictionary, TKey key, out ObservableList<TValue> listForKey) {
			listForKey = default;
			return default;
		}
		public static void FromLinq<TEntry>(this ObservableList<TEntry> list, IEnumerable<TEntry> linqResult) {}
		public static TEntry AtIndexOrDefault<TEntry>(this IList<TEntry> list, int atIndex) => default;
		public static bool AtIndexOrDefault<TEntry>(this IList<TEntry> list, int atIndex, out ref TEntry entryOut) {
			entryOut = default;
			return default;
		}
		public static bool InIndexRange<TEntry>(this IList<TEntry> list, int checkIndex) => default;
		public static void SetAt<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value) {}
	}
