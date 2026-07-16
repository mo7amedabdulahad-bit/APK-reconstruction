// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ObservableList<T> : ObservableListDummy<T>, INotifyPropertyChanged, INotifyStoppable, IList<T>
	{
		// Properties
		public new T this[int index] { get => default; set {} }
	
		// Constructors
		public ObservableList() {}
	
		// Methods
		public void StopNotifying() {}
		public void ResumeNotifying() {}
		public bool IsNotifying() => default;
		public void TriggerUpdate() {}
		public new void Add(T item) {}
		public new bool Remove(T item) => default;
		public new void AddRange(IEnumerable<T> collection) {}
		public new void RemoveRange(int index, int count) {}
		public new void Clear() {}
		public new void Insert(int index, T item) {}
		public new void InsertRange(int index, IEnumerable<T> collection) {}
		public new void RemoveAll(Predicate<T> match) {}
		public new void RemoveAt(int index) {}
		public ObservableList<T> Snapshot(Comparison<T> sortFunc = null) => default;
		public void FillFiltered(IEnumerable<T> sourceCollection, Func<T, bool> filterPredicate, bool onlyNotifyOnce = true) {}
		public void SyncWith<T2>(IEnumerable<T2> sourceCollection, Func<T2, bool> filterBy, Func<T, T2, bool> areEqual, Func<T2, T> createElement) {}
		public void SyncWith(IEnumerable<T> sourceCollection, Func<T, bool> filterBy) {}
		public void SyncWith(IEnumerable<T> sourceCollection) {}
		public void SyncWith<T2>(IEnumerable<T2> sourceCollection, Func<T, T2, bool> areEqual, Func<T2, T> createElement) {}
		public void WhileNotificationPaused(System.Action action, bool skipUpdate = false) {}
		public static void WhileAllNotificationsPaused(System.Action action, bool skipUpdate = false, params ObservableList<T>[] lists) {}
	}
