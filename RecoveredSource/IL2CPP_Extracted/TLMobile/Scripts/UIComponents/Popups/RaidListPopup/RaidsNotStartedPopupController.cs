// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Popups.RaidListPopup
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RaidsNotStartedPopupController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private ObservableList<string> _errorMessages;
		[ObservableValue]
		private ObservableList<int> _errorMessagesCount;
		private System.Action openRaidListDetailAction;
	
		// Properties
		[ObservableValue]
		public ObservableList<string> errorMessages { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> errorMessagesCount { get => default; set {} }
		public FarmList CurrentRaidList { get; private set; }
	
		// Constructors
		public RaidsNotStartedPopupController() {}
	
		// Methods
		private void _errorMessagesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _errorMessagesCountNotify(object sender, PropertyChangedEventArgs args) {}
		public virtual void Init(FarmList raidList, IList<FarmSlot> raids, System.Action openRaidListDetailAction = null) {}
		[UICallable]
		public void OpenRaidListDetail() {}
	}
