// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceContributionStatisticsPopup : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private OwnAllianceBonus.Type _selectedBonus;
		[ObservableValue]
		private DonationStatistics _donationStatistics;
		[ObservableValue]
		private OwnAllianceBonuses _bonuses;
	
		// Properties
		[ObservableValue]
		public OwnAllianceBonus.Type selectedBonus { get => default; set {} }
		[ObservableValue]
		public DonationStatistics donationStatistics { get => default; set {} }
		[ObservableValue]
		public OwnAllianceBonuses bonuses { get => default; set {} }
	
		// Constructors
		public AllianceContributionStatisticsPopup() {}
	
		// Methods
		public void Setup(OwnAllianceBonus.Type bonusType) {}
		private void UpdateBonuses() {}
	}
