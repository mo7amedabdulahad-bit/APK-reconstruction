// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI.UpgradeQueue
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class UpgradeQueueController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private Wallet _wallet;
		[ObservableValue]
		private GoldActionPrices _priceList;
		[ObservableValue]
		private ObservableList<BuildEventInQueue> _currentlyBuildingEvents;
		[ObservableValue]
		private ObservableList<BuildEvent> _masterBuilderQueue;
		[ObservableValue]
		private BuildEvent _demolishingBuilding;
		[ObservableValue]
		private BuildEventInQueue _demolishingBuildingInQueue;
		[ObservableValue]
		private Academy _academy;
		[ObservableValue]
		private Smithy _smithy;
		[ObservableValue]
		private bool _immediateConstructionNotPossible;
		private OwnVillage ownVillage;
	
		// Properties
		[ObservableValue]
		public Wallet wallet { get => default; set {} }
		[ObservableValue]
		public GoldActionPrices priceList { get => default; set {} }
		[ObservableValue]
		public ObservableList<BuildEventInQueue> currentlyBuildingEvents { get => default; set {} }
		[ObservableValue]
		public ObservableList<BuildEvent> masterBuilderQueue { get => default; set {} }
		[ObservableValue]
		public BuildEvent demolishingBuilding { get => default; set {} }
		[ObservableValue]
		public BuildEventInQueue demolishingBuildingInQueue { get => default; set {} }
		[ObservableValue]
		public Academy academy { get => default; set {} }
		[ObservableValue]
		public Smithy smithy { get => default; set {} }
		[ObservableValue]
		public bool immediateConstructionNotPossible { get => default; set {} }
	
		// Constructors
		public UpgradeQueueController() {}
	
		// Methods
		private void _currentlyBuildingEventsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _masterBuilderQueueNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Init() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void UpdateBuildEventsProgress() {}
		private void SplitBuildingQueue() {}
		[UICallable]
		public void CancelDemolish(BuildEvent eventToCancel) {}
		[UICallable]
		public void CancelUpgrade(BuildEvent eventToCancel) {}
		[UICallable]
		public void ShowCompleteImmediatelyPopup() {}
		private bool CheckIfImmediateConstructionIsPossible() => default;
		private void CheckForEmptyEvents() {}
	}
