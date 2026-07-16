// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.Hero
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroMainTabController : DetailWindowTabController
	{
		// Fields
		[ObservableValue]
		private ResourcesCostInfo _reviveCosts;
		[ObservableValue]
		private HeroInventoryItem _bucketAvailable;
		[ObservableValue]
		private bool _bucketIsOnCooldown;
		[ObservableValue]
		private bool _reviveCostAvailable;
		[ObservableValue]
		private int _modifiedAvailablePoints;
		[ObservableValue]
		private ObservableList<HeroAttributeItem> _heroAttributes;
		[ObservableValue]
		private bool _hadNoPointsAvailable;
		[ObservableValue]
		private ResourceTypes _currentProductionSetting;
		[ObservableValue]
		private ResourceAmounts _possibleProduction;
		[ObservableValue]
		private ResourceAmounts _currentProduction;
		[ObservableValue]
		private int _possibleProductionForAll;
		[ObservableValue]
		private bool _regenerationFoldoutVisible;
		[ObservableValue]
		private int _regenerationSum;
		[ObservableValue]
		[SerializeField]
		private int _regenerationBase;
		[ObservableValue]
		private int _regenerationEquipment;
		[ObservableValue]
		private int _nextHeroLevel;
		private OwnHero hero;
		private OwnVillage ownVillage;
	
		// Properties
		[ObservableValue]
		public ResourcesCostInfo reviveCosts { get => default; set {} }
		[ObservableValue]
		public HeroInventoryItem bucketAvailable { get => default; set {} }
		[ObservableValue]
		public bool bucketIsOnCooldown { get => default; set {} }
		[ObservableValue]
		public bool reviveCostAvailable { get => default; set {} }
		[ObservableValue]
		public int modifiedAvailablePoints { get => default; set {} }
		[ObservableValue]
		public ObservableList<HeroAttributeItem> heroAttributes { get => default; set {} }
		[ObservableValue]
		public bool hadNoPointsAvailable { get => default; set {} }
		[ObservableValue]
		public ResourceTypes currentProductionSetting { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts possibleProduction { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts currentProduction { get => default; set {} }
		[ObservableValue]
		public int possibleProductionForAll { get => default; set {} }
		[ObservableValue]
		public bool regenerationFoldoutVisible { get => default; set {} }
		[ObservableValue]
		public int regenerationSum { get => default; set {} }
		[ObservableValue]
		public int regenerationBase { get => default; set {} }
		[ObservableValue]
		public int regenerationEquipment { get => default; set {} }
		[ObservableValue]
		public int nextHeroLevel { get => default; set {} }
	
		// Constructors
		public HeroMainTabController() {}
	
		// Methods
		private void _heroAttributesNotify(object sender, PropertyChangedEventArgs args) {}
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		public void Init() {}
		private void CurrentVillageChanged(OwnVillage newVill) {}
		public override void OnOpen(int tabNumber) {}
		private void UpdateHero() {}
		private void UpdateAttributes() {}
		private void AttributePointInputChanged() {}
		private void UpdateRemainingPoints() {}
		private void UpdatePointsAddDisabled() {}
		[UICallable]
		public void ReviveHero() {}
		[UICallable]
		public void ReviveHeroWithBucket() {}
		[UICallable]
		public void SetProductionType(ResourceTypes newType) {}
		[UICallable]
		public void SaveAttributes() {}
		private void SaveEverything(bool saveAttributes, bool saveProductionType, bool saveHero) {}
		[UICallable]
		public void ToggleRegenerationFoldout() {}
	}
