// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.DataManagementHelpers
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TroopInfo : ObservableModel
	{
		// Fields
		public const int HeroUid = 0;
		public const int CatapultTroopId = 8;
		public static readonly int[] ShipIds;
		[ObservableValue]
		private int _tribeId;
		[ObservableValue]
		private int _tid;
		[ObservableValue]
		private string _tidString;
		[ObservableValue]
		private int _uidForTroop;
		[ObservableValue]
		private string _translateKey;
		[ObservableValue]
		private string _translateKeyCarry;
		[ObservableValue]
		private int _amount;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Unit _unitInfo;
		[ObservableValue]
		private int _unitLevel;
		[ObservableValue]
		private bool _researchAvailable;
		[ObservableValue]
		private ObservableList<UnitResearchRequirement> _researchRequiredBuildings;
		[ObservableValue]
		private int _upgradeTime;
		[ObservableValue]
		private int _upgradeTimeBoosted;
		[ObservableValue]
		private int _upgradeBoostPercentage;
		[ObservableValue]
		private ResourcesCostInfo _resourcesCostInfo;
		private bool includeResearchInfo;
	
		// Properties
		[ObservableValue]
		public int tribeId { get => default; set {} }
		[ObservableValue]
		public int tid { get => default; set {} }
		[ObservableValue]
		public string tidString { get => default; set {} }
		[ObservableValue]
		public int uidForTroop { get => default; set {} }
		[ObservableValue]
		public string translateKey { get => default; set {} }
		[ObservableValue]
		public string translateKeyCarry { get => default; set {} }
		[ObservableValue]
		public int amount { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Unit unitInfo { get => default; set {} }
		[ObservableValue]
		public int unitLevel { get => default; set {} }
		[ObservableValue]
		public bool researchAvailable { get => default; set {} }
		[ObservableValue]
		public ObservableList<UnitResearchRequirement> researchRequiredBuildings { get => default; set {} }
		[ObservableValue]
		public int upgradeTime { get => default; set {} }
		[ObservableValue]
		public int upgradeTimeBoosted { get => default; set {} }
		[ObservableValue]
		public int upgradeBoostPercentage { get => default; set {} }
		[ObservableValue]
		public ResourcesCostInfo resourcesCostInfo { get => default; set {} }
	
		// Constructors
		public TroopInfo(int tribeId, int tid, int amount, bool includeResearchInfo = false) {}
		public TroopInfo() {}
		static TroopInfo() {}
	
		// Methods
		private void SetTribeSpecificThings() {}
		public void SetResourcesInfoCostType(UnitCostType costType, int nextUnitLevel = 0) {}
		private bool HasResearchAvailableError(UnitCostType costType, bool skipToast = false) => default;
		public void UpdateBuildingRequirements() {}
		public static string GetTranslateKeyCarry(int tid) => default;
		public static string GetTranslateKey(int tribeId, int tid, int amount) => default;
		public static string GetTranslateKey(int tuid, int amount) => default;
		public static int GetUniqueIdForTroops(int tribeId, int tid) => default;
		public static ValueTuple<int, int> GetTribeAndTidFromUniqueId(int uniqueId) => default;
		public static int GetScoutingTroopUnitId(int tribeId) => default;
		public static bool IsAllowedToMerge(int tid, int? tribeId = default) => default;
		private static string TranslateKey(int tuid, int amount) => default;
		public TroopInfo Clone() => default;
		public void ChangeTribe(int tribe) {}
		private void _researchRequiredBuildingsNotify(object sender, PropertyChangedEventArgs args) {}
	}
