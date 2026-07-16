// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.MainUI.TroopsOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopsOverviewController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private TroopAmounts _troopAmounts;
		[ObservableValue]
		private Harbour _harbour;
		private Troops troops;
	
		// Properties
		[ObservableValue]
		public TroopAmounts troopAmounts { get => default; set {} }
		[ObservableValue]
		public Harbour harbour { get => default; set {} }
	
		// Constructors
		public TroopsOverviewController() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void CurrentVillageChanged(OwnVillage newVill) {}
		private void TroopsUpdated() {}
		private void UpdateShipInformation() {}
		private void CheckForNoTroops() {}
		[UICallable]
		public void ToTroopOverview() {}
	}
