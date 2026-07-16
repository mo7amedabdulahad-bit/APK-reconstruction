// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Extensions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class ObservableExtensions
	{
		// Fields
		private static readonly System.Type ItgObservableType;
		private static readonly ConcurrentDictionary<System.Type, List<PropertyInfo>> ObservablePropsCache;
		[ThreadStatic]
		private static HashSet<object> visitedCache;
	
		// Constructors
		static ObservableExtensions() {}
	
		// Methods
		private static void MergeFromInternal(object self, object source, System.Type type, HashSet<object> visited) {}
		private static bool TryMergeListNonGeneric(object origin, object source) => default;
		private static bool TryMergeDictNonGeneric(object origin, object source) => default;
		private static List<PropertyInfo> GetObservableProperties(System.Type type) => default;
	
		// Extension methods
		public static void MergeFrom<T>(this T self, T source)
			where T : class, ITGObservable {}
		public static void MergeFrom(this object self, object source, System.Type type) {}
		public static void MergeFrom<TList, T>(this TList self, IList<T> source)
			where TList : IList<T>, IList, INotifyPropertyChanged {}
		public static void MergeFrom<TDict, TKey, TValue>(this TDict self, IDictionary<TKey, TValue> source)
			where TDict : IDictionary<TKey, TValue>, IDictionary, INotifyPropertyChanged {}
	}
