// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class GenericTabValueController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private int _selectedValue;
		private Action<int> closeAction;
	
		// Properties
		[ObservableValue]
		public int selectedValue { get => default; set {} }
	
		// Events
		public event SelectedValueChanged OnSelectedValueChanged;
	
		// Nested types
		public delegate void SelectedValueChanged(int value);
	
		// Constructors
		public GenericTabValueController() {}
	
		// Methods
		public void Setup(int defaultValue = 0, Action<int> closeAction = null) {}
		[UICallable]
		public void ChangeSelectedValue(int value) {}
		[UICallable]
		public void CallCloseAction() {}
	}
