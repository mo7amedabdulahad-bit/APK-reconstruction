// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.UIComponents.Windows.VillageOverview
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnVillageWithOverviewInfos : ObservableModel
	{
		// Fields
		[ObservableValue]
		private OwnVillage _ownVillage;
		[ObservableValue]
		private bool _isExpanded;
		[ObservableValue]
		private MerchantsInfo _merchantsInfo;
		[ObservableValue]
		private Generated.GraphQL.Game.TownHall _townHall;
		[ObservableValue]
		private Expansion _expansion;
		[ObservableValue]
		private Smithy _smithy;
		[ObservableValue]
		private bool _hasSmithy;
		[ObservableValue]
		private int _firstResourceCapacityFull;
		[ObservableValue]
		private int _resourceTypesFull;
		[ObservableValue]
		private ObservableDictionary<Building.TypeId, int> _trainingUntil;
		[ObservableValue]
		private ObservableList<int> _troopTypesInTraining;
		[ObservableValue]
		private int _settlerSpriteIndex;
		[ObservableValue]
		private int _chiefSpriteIndex;
		[ObservableValue]
		private TroopAmounts _smithyLevels;
		[ObservableValue]
		private Hospital _hospital;
		[ObservableValue]
		private bool _hasHospital;
		[ObservableValue]
		private TroopAmounts _hospitalWounded;
		[ObservableValue]
		private TroopsPower _stationaryTroopsPower;
		[ObservableValue]
		private Trapper _trapper;
	
		// Properties
		[ObservableValue]
		public OwnVillage ownVillage { get => default; set {} }
		[ObservableValue]
		public bool isExpanded { get => default; set {} }
		[ObservableValue]
		public MerchantsInfo merchantsInfo { get => default; set {} }
		[ObservableValue]
		public Generated.GraphQL.Game.TownHall townHall { get => default; set {} }
		[ObservableValue]
		public Expansion expansion { get => default; set {} }
		[ObservableValue]
		public Smithy smithy { get => default; set {} }
		[ObservableValue]
		public bool hasSmithy { get => default; set {} }
		[ObservableValue]
		public int firstResourceCapacityFull { get => default; set {} }
		[ObservableValue]
		public int resourceTypesFull { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<Building.TypeId, int> trainingUntil { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> troopTypesInTraining { get => default; set {} }
		[ObservableValue]
		public int settlerSpriteIndex { get => default; set {} }
		[ObservableValue]
		public int chiefSpriteIndex { get => default; set {} }
		[ObservableValue]
		public TroopAmounts smithyLevels { get => default; set {} }
		[ObservableValue]
		public Hospital hospital { get => default; set {} }
		[ObservableValue]
		public bool hasHospital { get => default; set {} }
		[ObservableValue]
		public TroopAmounts hospitalWounded { get => default; set {} }
		[ObservableValue]
		public TroopsPower stationaryTroopsPower { get => default; set {} }
		[ObservableValue]
		public Trapper trapper { get => default; set {} }
	
		// Constructors
		public OwnVillageWithOverviewInfos() {}
		public OwnVillageWithOverviewInfos(OwnVillage vill) {}
	
		// Methods
		private void _trainingUntilNotify(object sender, PropertyChangedEventArgs args) {}
		private void _troopTypesInTrainingNotify(object sender, PropertyChangedEventArgs args) {}
		public void Destroy() {}
		private void UpdateEverything() {}
		public void UpdateResourceValues() {}
		private void ResetTrainingTime(Building.TypeId building) {}
		public void UpdateTrainingTimes() {}
		private void IterateTrainingBatch(GraphQLObservableList<TrainingBatch> batch) {}
	}
