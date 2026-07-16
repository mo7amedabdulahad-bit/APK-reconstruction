// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.TownHall
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CityTabController : DetailWindowTabController
	{
		// Fields
		private const int CityRequiredLevelOfTownHall = 20;
		[ObservableValue]
		private OwnPlayer _ownPlayer;
		[ObservableValue]
		private OwnVillage _ownVillage;
		[ObservableValue]
		private int _cityRequiredLevelOfTownHall;
		[ObservableValue]
		private bool _canUpgradeToACity;
		[ObservableValue]
		private bool _settlmentSlotRequirementMet;
		[ObservableValue]
		private bool _townHallRequirementMet;
	
		// Properties
		[ObservableValue]
		public OwnPlayer ownPlayer { get => default; set {} }
		[ObservableValue]
		public OwnVillage ownVillage { get => default; set {} }
		[ObservableValue]
		public int cityRequiredLevelOfTownHall { get => default; set {} }
		[ObservableValue]
		public bool canUpgradeToACity { get => default; set {} }
		[ObservableValue]
		public bool settlmentSlotRequirementMet { get => default; set {} }
		[ObservableValue]
		public bool townHallRequirementMet { get => default; set {} }
	
		// Constructors
		public CityTabController() {}
	
		// Methods
		protected override void Awake() {}
		protected override void OnEnable() {}
		protected override void OnDisable() {}
		private void CurrentVillageChanged(OwnVillage village) {}
		private void OnOwnPlayerUpdate() {}
		private void UpdateCanUpgradeToACity() {}
		[UICallable]
		public void UpgradeToCity() {}
		[UICallable]
		private void DoUpgradeToCity() {}
	}
