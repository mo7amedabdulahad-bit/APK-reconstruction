// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyPropertyChanged, INotifyStoppable, IDictionary
	{
		// Fields
		private bool beSilent;
		private bool haveUpdatesWhileSilent;
	
		// Properties
		public new TValue this[TKey index] { get => default; set {} }
		public object this[object key] { get => default; set {} }
	
		// Events
		public event PropertyChangedEventHandler PropertyChanged;
	
		// Constructors
		public ObservableDictionary() {}
	
		// Methods
		public void StopNotifying() {}
		public void ResumeNotifying() {}
		public void ResumeNotifying(bool forceNotify) {}
		public bool IsNotifying() => default;
		private void Updated() {}
		public new void Add(TKey key, TValue value) {}
		public new void Clear() {}
		public new void Remove(TKey key) {}
		public void Add(object key, object value) {}
	}
