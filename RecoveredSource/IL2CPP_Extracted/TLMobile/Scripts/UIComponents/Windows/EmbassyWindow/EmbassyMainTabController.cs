// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.EmbassyWindow
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class EmbassyMainTabController : DetailWindowTabControllerWithSubTab
	{
		// Fields
		private const int AllianceInfoTab = 0;
		private const int NearbyVillagesTab = 1;
		public const int AllianceRejoinCooldown = 24;
		[ObservableValue]
		private OwnAlliance _currentAlliance;
		[ObservableValue]
		private Embassy _embassy;
		[ObservableValue]
		private Building _currentEmbassyBuilding;
		[ObservableValue]
		private int _leavingTimeout;
		[ObservableValue]
		private bool _ancientPowersInUse;
	
		// Properties
		[ObservableValue]
		public OwnAlliance currentAlliance { get => default; set {} }
		[ObservableValue]
		public Embassy embassy { get => default; set {} }
		[ObservableValue]
		public Building currentEmbassyBuilding { get => default; set {} }
		[ObservableValue]
		public int leavingTimeout { get => default; set {} }
		[ObservableValue]
		public bool ancientPowersInUse { get => default; set {} }
	
		// Constructors
		public EmbassyMainTabController() {}
	
		// Methods
		private void Start() {}
		protected override void OnEnable() {}
		private void AllianceChanged() {}
		private void CurrentVillageChanged(OwnVillage newVillage) {}
		[UICallable]
		public void DeclineInvitation(AllianceInvitation invitation) {}
	}
