// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnAllianceBonusTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private OwnAlliance _alliance;
		[ObservableValue]
		private OwnAllianceBonuses _bonuses;
	
		// Properties
		[ObservableValue]
		public OwnAlliance alliance { get => default; set {} }
		[ObservableValue]
		public OwnAllianceBonuses bonuses { get => default; set {} }
	
		// Constructors
		public OwnAllianceBonusTabController() {}
	
		// Methods
		public override void OnOpen(int tabNumber) {}
		[UICallable]
		public void OpenContributePopup(OwnAllianceBonus bonus) {}
		[UICallable]
		public void OpenContributeStatistics(OwnAllianceBonus bonus) {}
	}
