// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopsMovementMainUI : TLMViewModel
	{
		// Fields
		public const string KeepOverviewOpenPrefKey = "KeepTroopsMovementOverviewOpen";
		[ObservableValue]
		private bool _isExpanded;
		[ObservableValue]
		private TroopsMovementOverview _troopsMovementOverview;
	
		// Properties
		[ObservableValue]
		public bool isExpanded { get => default; set {} }
		[ObservableValue]
		public TroopsMovementOverview troopsMovementOverview { get => default; set {} }
	
		// Constructors
		public TroopsMovementMainUI() {}
	
		// Methods
		protected override void Awake() {}
		public void Init() {}
		[UICallable]
		public void ToggleExpanded() {}
	}
