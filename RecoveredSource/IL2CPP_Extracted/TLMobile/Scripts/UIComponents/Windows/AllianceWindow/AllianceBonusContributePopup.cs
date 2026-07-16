// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.AllianceWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceBonusContributePopup : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private OwnAlliance _alliance;
		[ObservableValue]
		private OwnAllianceBonus.Type _selectedBonus;
		[ObservableValue]
		private ResourceAmounts _selectedResources;
		[ObservableValue]
		private ResourceAmounts _maxResources;
		[ObservableValue]
		private int _resultResourceSum;
		[ObservableValue]
		private int _maxContributionLimit;
		[ObservableValue]
		private bool _use3X;
		[ObservableValue]
		private bool _showGoldContributionSuccessOverlay;
		[ObservableValue]
		private OwnAllianceBonuses _bonuses;
		private ResourceAmounts lastSelectedResources;
		protected OwnVillage village;
	
		// Properties
		[ObservableValue]
		public OwnAlliance alliance { get => default; set {} }
		[ObservableValue]
		public OwnAllianceBonus.Type selectedBonus { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts selectedResources { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts maxResources { get => default; set {} }
		[ObservableValue]
		public int resultResourceSum { get => default; set {} }
		[ObservableValue]
		public int maxContributionLimit { get => default; set {} }
		[ObservableValue]
		public bool use3X { get => default; set {} }
		[ObservableValue]
		public bool showGoldContributionSuccessOverlay { get => default; set {} }
		[ObservableValue]
		public OwnAllianceBonuses bonuses { get => default; set {} }
	
		// Constructors
		public AllianceBonusContributePopup() {}
	
		// Methods
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Setup(OwnAllianceBonus.Type bonusType) {}
		public void InitForCurrentVillage(OwnVillage newVill) {}
		private void ResourcesChanged() {}
		[UICallable]
		public void Toggle3X() {}
		[UICallable]
		public void Contribute() {}
		public void Show3XContributeToastMessage() {}
		[UICallable]
		public override void Hide() {}
		[IteratorStateMachine(typeof(_ShowRewardAnimation_d__47))]
		private IEnumerator ShowRewardAnimation() => default;
	}
