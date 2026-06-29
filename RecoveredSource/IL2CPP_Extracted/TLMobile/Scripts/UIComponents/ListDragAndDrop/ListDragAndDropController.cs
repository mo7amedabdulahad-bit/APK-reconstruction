// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.ListDragAndDrop
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ListDragAndDropController : ViewModel
	{
		// Fields
		[ObservableValue]
		private bool _inSortingMode;
		[ObservableValue]
		private bool _isCurrentlySorting;
		[ObservableValue]
		private int? _currentlySortingGroupId;
		public Action<int, int, Transform, bool> OnElementDropped;
		public Action<int> OnDragStarted;
	
		// Properties
		[ObservableValue]
		public bool inSortingMode { get => default; set {} }
		[ObservableValue]
		public bool isCurrentlySorting { get => default; set {} }
		[ObservableValue]
		public int? currentlySortingGroupId { get => default; set {} }
	
		// Constructors
		public ListDragAndDropController() {}
	
		// Methods
		private void OnEnable() {}
		public void Init() {}
		[UICallable]
		public void SetSortingModeActive(int value) {}
		public void StartDrag(int id) {}
		public void DropElement(int id, int newSortingIndex, Transform target, bool isBelowTarget) {}
		public void ElementSelected(int groupId) {}
	}
