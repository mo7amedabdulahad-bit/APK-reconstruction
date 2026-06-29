// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class BuildingDetailWindowController : DetailWindowController
	{
		// Fields
		[ObservableValue]
		private Building _building;
		[ObservableValue]
		private int _buildingSpriteIndex;
		[ObservableValue]
		private string _buildingName;
		[ObservableValue]
		private ObservableList<string> _buildingInfoText;
		[ObservableValue]
		private int _currentlyBuildingLevel;
		[ObservableValue]
		private ObservableDictionary<int, float?> _upgradeEffects;
		[ObservableValue]
		private string _levelEffectCurrentKey;
		[ObservableValue]
		private string _levelEffectDescriptionKey;
		[ObservableValue]
		private string _levelEffectAmountKey;
		[ObservableValue]
		private string _levelEffectAmountKeyInfoTab;
		[ObservableValue]
		private string _nextLevelValueChangeInBrackets;
		[ObservableValue]
		private float _nextLevelEffectValue;
		[ObservableValue]
		private bool _showLevelEffectInUI;
		private OwnPlayer ownPlayer;
		protected BuildingInfo buildingInfo;
		protected OwnVillage currentVillage;
	
		// Properties
		[ObservableValue]
		public Building building { get => default; set {} }
		[ObservableValue]
		public int buildingSpriteIndex { get => default; set {} }
		[ObservableValue]
		public string buildingName { get => default; set {} }
		[ObservableValue]
		public ObservableList<string> buildingInfoText { get => default; set {} }
		[ObservableValue]
		public int currentlyBuildingLevel { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, float?> upgradeEffects { get => default; set {} }
		[ObservableValue]
		public string levelEffectCurrentKey { get => default; set {} }
		[ObservableValue]
		public string levelEffectDescriptionKey { get => default; set {} }
		[ObservableValue]
		public string levelEffectAmountKey { get => default; set {} }
		[ObservableValue]
		public string levelEffectAmountKeyInfoTab { get => default; set {} }
		[ObservableValue]
		public string nextLevelValueChangeInBrackets { get => default; set {} }
		[ObservableValue]
		public float nextLevelEffectValue { get => default; set {} }
		[ObservableValue]
		public bool showLevelEffectInUI { get => default; set {} }
	
		// Constructors
		public BuildingDetailWindowController() {}
	
		// Methods
		private void _buildingInfoTextNotify(object sender, PropertyChangedEventArgs args) {}
		private void _upgradeEffectsNotify(object sender, PropertyChangedEventArgs args) {}
		public void SetBuilding(Building building) {}
		protected override void OnDestroy() {}
		[Testable]
		protected virtual void CurrentVillageChanged(OwnVillage newVill) {}
		protected virtual void NewBuildingInfo(OwnVillage newVill) {}
		protected void OnCurrentVillageChanged() {}
		protected virtual void UpdateBuildingData(OwnVillage village) {}
		[UICallable]
		public void OpenTravianAnswers(Building building) {}
		protected virtual void UpdateUpgradeTabData(OwnVillage village) {}
		private void UpdateLevelEffectKeys(Building.TypeId buildingType) {}
		private bool ValidateBuilding() => default;
		public static BuildingDetailWindowController Show(Building building) => default;
		public virtual float GetArtefactBonusValue() => default;
		[UICallable]
		public void OpenMainBuilding() {}
	}
