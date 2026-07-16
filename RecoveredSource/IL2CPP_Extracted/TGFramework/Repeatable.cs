// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Repeatable : ViewModel
	{
		// Fields
		[ObservableValue]
		private object _repeatObject;
		[ObservableValue]
		private object _index;
		[ObservableValue]
		private int _intIndex;
		[ObservableValue]
		private bool _isLastElement;
		public TGFramework.Repeat parentRepeater;
		private PropertyChangedEventHandler _repeatObjectNotify;
	
		// Properties
		[ObservableValue]
		public object repeatObject { get => default; set {} }
		[ObservableValue]
		public object index { get => default; set {} }
		[ObservableValue]
		public int intIndex { get => default; set {} }
		[ObservableValue]
		public bool isLastElement { get => default; set {} }
	
		// Constructors
		public Repeatable() {}
	}
