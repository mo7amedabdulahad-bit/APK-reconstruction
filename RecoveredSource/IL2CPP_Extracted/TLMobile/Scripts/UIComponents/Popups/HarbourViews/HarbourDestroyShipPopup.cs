// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.HarbourViews
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HarbourDestroyShipPopup : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private Harbour _harbour;
		[ObservableValue]
		private ObservableList<int> _selectedAmounts;
		[ObservableValue]
		private int _totalSelectedAmount;
	
		// Properties
		[ObservableValue]
		public Harbour harbour { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> selectedAmounts { get => default; set {} }
		[ObservableValue]
		public int totalSelectedAmount { get => default; set {} }
	
		// Constructors
		public HarbourDestroyShipPopup() {}
	
		// Methods
		private void _selectedAmountsNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		private void Init() {}
		private void SetAmount() {}
		[UICallable]
		public void DestroyShips() {}
		[UICallable]
		public void FillInput(int index) {}
	}
