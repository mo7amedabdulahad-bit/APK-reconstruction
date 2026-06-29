// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnVillage : GraphQLFetchable, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _landDistribution;
		[ObservableValue]
		private int _tribeId;
		[ObservableValue]
		private int _mapId;
		[ObservableValue]
		private int _x;
		[ObservableValue]
		private int _y;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private int _type;
		[ObservableValue]
		private int _population;
		[ObservableValue]
		private bool _isWW;
		[ObservableValue]
		private Region _region;
		[ObservableValue]
		private string _typeText;
		[ObservableValue]
		private string _typeTitle;
		[ObservableValue]
		private bool _isShore;
		[ObservableValue]
		private bool _isCity;
		[ObservableValue]
		private string _objectId;
		[ObservableValue]
		private OwnVillage _ownerVillage;
		[ObservableValue]
		private int _oasesCount;
		[ObservableValue]
		private GraphQLObservableList<Building> _buildings;
		[ObservableValue]
		private Troops _troops;
		[ObservableValue]
		private Troop _troopsSummary;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Resource _resources;
		[ObservableValue]
		private GraphQLObservableList<BuildEvent> _buildEvents;
		[ObservableValue]
		private int _loyalty;
		[ObservableValue]
		private GraphQLObservableList<ResearchedUnit> _researchedUnits;
		[ObservableValue]
		private bool _waveBuilderIsActivated;
		[ObservableValue]
		private int? _goldLeftToMergeTroops;
		[ObservableValue]
		private GraphQLObservableList<TrainingBatch> _trainingTroops;
		[ObservableValue]
		private TroopsOverview _troopOverview;
		[ObservableValue]
		private bool _hasRallyPoint;
		[ObservableValue]
		private bool _hasHarbour;
		[ObservableValue]
		private int _cpProduction;
		[ObservableValue]
		private int? _sortIndex;
		[ObservableValue]
		private Stable _stable;
		[ObservableValue]
		private Barracks _barracks;
		[ObservableValue]
		private Residence _residence;
		[ObservableValue]
		private ProductionOverview _productionOverview;
		[ObservableValue]
		private int _notCollectedTasks;
		[ObservableValue]
		[Obsolete("Please use \'troopsSummary\' as less ambiguous name")]
		private Troop _ownTroops;
		[ObservableValue]
		private WoW _wow;
		[ObservableValue]
		private int? _upgradeToCityInProgressUntil;
		[ObservableValue]
		private float _distance;
		[ObservableValue]
		private bool _settlersCanChangeTribe;
		private int ownVillageId;
		private static readonly string[] namesInNestedResponse;
		[ObservableValue]
		private Type _typeEnum;
		[ObservableValue]
		private string _nameDecoded;
		[ObservableValue]
		private LoyaltyStatus _loyaltyStatus;
		[ObservableValue]
		private TroopAmounts _trainingTroopsAsAmounts;
		[ObservableValue]
		private TroopAmounts _ownTroopsAsAmounts;
		[ObservableValue]
		private Building _mainBuilding;
		[ObservableValue]
		private VillageLayoutType _villageLayoutType;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public OwnVillageSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int landDistribution { get => default; set {} }
		[ObservableValue]
		public int tribeId { get => default; set {} }
		[ObservableValue]
		public int mapId { get => default; set {} }
		[ObservableValue]
		public int x { get => default; set {} }
		[ObservableValue]
		public int y { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public int population { get => default; set {} }
		[ObservableValue]
		public bool isWW { get => default; set {} }
		[ObservableValue]
		public Region region { get => default; set {} }
		[ObservableValue]
		public string typeText { get => default; set {} }
		[ObservableValue]
		public string typeTitle { get => default; set {} }
		[ObservableValue]
		public bool isShore { get => default; set {} }
		[ObservableValue]
		public bool isCity { get => default; set {} }
		[ObservableValue]
		public string objectId { get => default; set {} }
		[ObservableValue]
		public OwnVillage ownerVillage { get => default; set {} }
		[ObservableValue]
		public int oasesCount { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<Building> buildings { get => default; set {} }
		[ObservableValue]
		public Troops troops { get => default; set {} }
		[ObservableValue]
		public Troop troopsSummary { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Resource resources { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<BuildEvent> buildEvents { get => default; set {} }
		[ObservableValue]
		public int loyalty { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<ResearchedUnit> researchedUnits { get => default; set {} }
		[ObservableValue]
		public bool waveBuilderIsActivated { get => default; set {} }
		[ObservableValue]
		public int? goldLeftToMergeTroops { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TrainingBatch> trainingTroops { get => default; set {} }
		[ObservableValue]
		public TroopsOverview troopOverview { get => default; set {} }
		[ObservableValue]
		public bool hasRallyPoint { get => default; set {} }
		[ObservableValue]
		public bool hasHarbour { get => default; set {} }
		[ObservableValue]
		public int cpProduction { get => default; set {} }
		[ObservableValue]
		public int? sortIndex { get => default; set {} }
		[ObservableValue]
		public Stable stable { get => default; set {} }
		[ObservableValue]
		public Barracks barracks { get => default; set {} }
		[ObservableValue]
		public Residence residence { get => default; set {} }
		[ObservableValue]
		public ProductionOverview productionOverview { get => default; set {} }
		[ObservableValue]
		public int notCollectedTasks { get => default; set {} }
		[ObservableValue]
		[Obsolete("Please use \'troopsSummary\' as less ambiguous name")]
		public Troop ownTroops { get => default; set {} }
		[ObservableValue]
		public WoW wow { get => default; set {} }
		[ObservableValue]
		public int? upgradeToCityInProgressUntil { get => default; set {} }
		[ObservableValue]
		public float distance { get => default; set {} }
		[ObservableValue]
		public bool settlersCanChangeTribe { get => default; set {} }
		[ObservableValue]
		public Type typeEnum { get => default; set {} }
		[ObservableValue]
		public string nameDecoded { get => default; set {} }
		[ObservableValue]
		public LoyaltyStatus loyaltyStatus { get => default; set {} }
		[ObservableValue]
		public TroopAmounts trainingTroopsAsAmounts { get => default; set {} }
		[ObservableValue]
		public TroopAmounts ownTroopsAsAmounts { get => default; set {} }
		[ObservableValue]
		public Building mainBuilding { get => default; set {} }
		[ObservableValue]
		public VillageLayoutType villageLayoutType { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			OnlyId = 1,
			Name = 2,
			IncomingAttacks = 3,
			Resources = 4,
			BuildingUpgrade = 5,
			WaveBuilder = 6,
			TroopOverview = 7,
			TroopOverviewAndResources = 8,
			FinishedImmediately = 9,
			TroopsTraining = 10,
			NotCollectedTasks = 11
		}
	
		public enum OwnVillageSource
		{
			RootLevel = 0
		}
	
		public enum OwnVillageListSource
		{
			FromOwnPlayerVillages = 0
		}
	
		public enum LoyaltyStatus
		{
			Normal = 0,
			Negative = 1,
			Positive = 2
		}
	
		public enum Type
		{
			Village = 0,
			MainVillage = 1,
			OccupiedOasis = 2,
			FreeOasis = 3
		}
	
		public enum VillageLayoutType
		{
			Village = 1,
			Shore = 2,
			City = 3,
			ShoreCity = 4
		}
	
		public enum Sector
		{
			Nw = 1,
			No = 2,
			Sw = 3,
			So = 4
		}
	
		// Constructors
		public OwnVillage() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTOOnlyId(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTOName(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTOIncomingAttacks(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTOResources(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTOBuildingUpgrade(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTOWaveBuilder(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTOTroopOverview(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTOTroopOverviewAndResources(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTOFinishedImmediately(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTOTroopsTraining(OwnVillageDTO dtoValue) => default;
		private bool EqualToDTONotCollectedTasks(OwnVillageDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyId(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOName(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOIncomingAttacks(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOResources(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOBuildingUpgrade(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOWaveBuilder(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOTroopOverview(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOTroopOverviewAndResources(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOFinishedImmediately(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOTroopsTraining(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTONotCollectedTasks(OwnVillageDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListBuildings(GraphQLObservableList<Building> to, List<BuildingDTO> from, int query) => default;
		private bool CopyValuesFromDtoListBuildEvents(GraphQLObservableList<BuildEvent> to, List<BuildEventDTO> from, int query) => default;
		private bool CopyValuesFromDtoListResearchedUnits(GraphQLObservableList<ResearchedUnit> to, List<ResearchedUnitDTO> from, int query) => default;
		private bool CopyValuesFromDtoListTrainingTroops(GraphQLObservableList<TrainingBatch> to, List<TrainingBatchDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static OwnVillage GetById(object dtoObject) => default;
		public static IPromise<OwnVillage> PromiseGet(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<OwnVillage> PromiseGet(out OwnVillage cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static OwnVillage GetNoFetch(int ownVillageId, Query query = Query.All) => default;
		public static OwnVillage Get(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static OwnVillage Get(int ownVillageId, Query query = Query.All) => default;
		private static OwnVillage Fetch(OwnVillageSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int ownVillageId, object dummy = null) => default;
		public static GraphQLFetchableList<OwnVillage> CollectionGetNoFetchFromOwnPlayerVillages(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<OwnVillage>> PromiseCollectionGetFromOwnPlayerVillages(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<OwnVillage>> PromiseCollectionGetFromOwnPlayerVillages(out GraphQLFetchableList<OwnVillage> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<OwnVillage> CollectionGetFromOwnPlayerVillages(Query query = Query.All) => default;
		public static GraphQLFetchableList<OwnVillage> CollectionGetFromOwnPlayerVillages(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<OwnVillage> CollectionFetchFromOwnPlayerVillages(OwnVillageListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerVillages(object dummy = null) => default;
		private void _buildingsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _buildEventsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _researchedUnitsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _trainingTroopsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		public Building GetBuilding(Building.TypeId type) => default;
		public Sector GetSector() => default;
	}
