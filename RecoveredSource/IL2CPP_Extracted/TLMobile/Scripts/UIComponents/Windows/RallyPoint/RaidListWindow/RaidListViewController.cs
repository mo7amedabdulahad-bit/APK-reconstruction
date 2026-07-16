// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.RallyPoint.RaidListWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RaidListViewController : InjectableViewModel
	{
		// Fields
		[InjectableValue]
		[ObservableValue]
		private FarmList _farmList;
		[ObservableValue]
		private int _activeSlots;
		[ObservableValue]
		private GraphQLFetchableList<FarmSlot> _slots;
		[ObservableValue]
		private bool _slotsLoading;
	
		// Properties
		[InjectableValue]
		[ObservableValue]
		public FarmList farmList { get => default; set {} }
		[ObservableValue]
		public int activeSlots { get => default; set {} }
		[ObservableValue]
		public GraphQLFetchableList<FarmSlot> slots { get => default; set {} }
		[ObservableValue]
		public bool slotsLoading { get => default; set {} }
	
		// Constructors
		public RaidListViewController() {}
	
		// Methods
		private void _slotsNotify(object sender, PropertyChangedEventArgs args) {}
		private void OnEnable() {}
		[UICallable]
		public void RunRaids() {}
		private void AfterSendCallback(ApiResponse<SendRaidsResponse> response) {}
		public override void OnInjectedValueChanged() {}
		private void GetActiveFarmSlots() {}
	}
