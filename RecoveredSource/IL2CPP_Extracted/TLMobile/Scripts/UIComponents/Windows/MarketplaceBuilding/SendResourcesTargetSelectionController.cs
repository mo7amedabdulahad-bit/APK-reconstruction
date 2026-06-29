// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.MarketplaceBuilding
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class SendResourcesTargetSelectionController : GenericTargetSelection
	{
		// Fields
		[ObservableValue]
		private bool _invalidTarget;
		[ObservableValue]
		private bool _showBeginnerProtectionWarning;
	
		// Properties
		[ObservableValue]
		public bool invalidTarget { get => default; set {} }
		[ObservableValue]
		public bool showBeginnerProtectionWarning { get => default; set {} }
	
		// Constructors
		public SendResourcesTargetSelectionController() {}
	
		// Methods
		[UICallable]
		public void OpenCustomVillageSelection() {}
		private bool CheckForValidVillage(Village value) => default;
		protected override void OnEnable() {}
		protected override void DoAfterChangeChecks() {}
	}
