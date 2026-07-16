// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.PointerExtension
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class PointerDatabindingDataProvider : ViewModel, IPointerClickHandler
	{
		// Fields
		[ObservableValue]
		private bool _isHovered;
		[ObservableValue]
		private bool _isSelected;
		public bool watchForSelectedState;
		public bool selectWillToggle;
		public bool initialStateIsSelected;
		private int selectedFrame;
	
		// Properties
		[ObservableValue]
		public bool isHovered { get => default; set {} }
		[ObservableValue]
		public bool isSelected { get => default; set {} }
	
		// Constructors
		public PointerDatabindingDataProvider() {}
	
		// Methods
		private void Start() {}
		private void Update() {}
		public void OnPointerClick(PointerEventData eventData) {}
		[UICallable]
		public void ToggleSelected() {}
	}
