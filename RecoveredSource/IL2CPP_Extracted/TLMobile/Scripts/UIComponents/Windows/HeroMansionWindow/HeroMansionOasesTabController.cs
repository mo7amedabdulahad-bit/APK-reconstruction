// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.HeroMansionWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroMansionOasesTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private HeroMansionSubTabs _currentSubTab;
		[ObservableValue]
		private GraphQLObservableList<OasisInterface> _oasesList;
		[ObservableValue]
		private GraphQLObservableList<OasisInterface> _oasesAbandonList;
		[ObservableValue]
		private ObservableList<float> _oasesBonusValues;
		[ObservableValue]
		private ObservableList<float> _oasesAbandonBonusValues;
		[ObservableValue]
		private float _waterworksEffectValue;
		private BootstrapData data;
		private HeroMansion heroMansion;
		private OwnVillage ownVillage;
		private Building waterworks;
	
		// Properties
		[ObservableValue]
		public HeroMansionSubTabs currentSubTab { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OasisInterface> oasesList { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OasisInterface> oasesAbandonList { get => default; set {} }
		[ObservableValue]
		public ObservableList<float> oasesBonusValues { get => default; set {} }
		[ObservableValue]
		public ObservableList<float> oasesAbandonBonusValues { get => default; set {} }
		[ObservableValue]
		public float waterworksEffectValue { get => default; set {} }
	
		// Constructors
		public HeroMansionOasesTabController() {}
	
		// Methods
		private void _oasesListNotify(object sender, PropertyChangedEventArgs args) {}
		private void _oasesAbandonListNotify(object sender, PropertyChangedEventArgs args) {}
		private void _oasesBonusValuesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _oasesAbandonBonusValuesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Setup() {}
		public override void OnOpen(int tabNumber) {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		private void CheckForWaterWork() {}
		private void UpdateDisplayedList() {}
		[Testable]
		private void UpdateWaterworksBonus(GraphQLObservableList<OasisInterface> observableList, ObservableList<float> valueList) {}
		private void FillListWithSlots() {}
		[UICallable]
		public void ChangeSubTab(HeroMansionSubTabs nextTab) {}
		[UICallable]
		public void AbandonOasis(OccupiedOasis oasis) {}
		[UICallable]
		public void StopOasisAbandoning(OccupiedOasis oasis) {}
		[UICallable]
		public void OpenOasisMapCell(OasisInterface oasis) {}
	}
