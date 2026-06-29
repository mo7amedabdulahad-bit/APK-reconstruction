// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ObservableListDummy<T> : List<T>, IList, INotifyPropertyChanged
	{
		// Fields
		protected bool beSilent;
		protected bool haveUpdatesWhileSilent;
	
		// Properties
		public new object this[int index] { get => default; set {} }
	
		// Events
		public event PropertyChangedEventHandler PropertyChanged;
	
		// Constructors
		public ObservableListDummy() {}
	
		// Methods
		protected void Updated() {}
	}
