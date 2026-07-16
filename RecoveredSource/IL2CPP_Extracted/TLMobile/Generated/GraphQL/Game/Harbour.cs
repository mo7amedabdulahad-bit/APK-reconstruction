// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Harbour : GraphQLFetchable, IBackendUpdateable, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<ShipAmount> _availableShips;
		[ObservableValue]
		private GraphQLObservableList<ShipAmount> _shipsOnTheWay;
		[ObservableValue]
		private GraphQLObservableList<ShipInProductionEntry> _inProduction;
		[ObservableValue]
		private int? _nextShipIsReadyAt;
		private int ownVillageIdFromOwnVillageHarbour;
		private static readonly string[] namesInNestedResponseFromOwnVillageHarbour;
		[ObservableValue]
		private int _totalShipAmount;
		[ObservableValue]
		private int _availableShipAmount;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public HarbourSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<ShipAmount> availableShips { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<ShipAmount> shipsOnTheWay { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<ShipInProductionEntry> inProduction { get => default; set {} }
		[ObservableValue]
		public int? nextShipIsReadyAt { get => default; set {} }
		[ObservableValue]
		public int totalShipAmount { get => default; set {} }
		[ObservableValue]
		public int availableShipAmount { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum HarbourSource
		{
			FromOwnVillageHarbour = 0
		}
	
		// Constructors
		public Harbour() {}
		static Harbour() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HarbourDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HarbourDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAvailableShips(GraphQLObservableList<ShipAmount> to, List<ShipAmountDTO> from, int query) => default;
		private bool CopyValuesFromDtoListShipsOnTheWay(GraphQLObservableList<ShipAmount> to, List<ShipAmountDTO> from, int query) => default;
		private bool CopyValuesFromDtoListInProduction(GraphQLObservableList<ShipInProductionEntry> to, List<ShipInProductionEntryDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Harbour> PromiseGetFromOwnVillageHarbour(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Harbour> PromiseGetFromOwnVillageHarbour(out Harbour cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Harbour GetNoFetchFromOwnVillageHarbour(int ownVillageId, Query query = Query.All) => default;
		public static Harbour GetFromOwnVillageHarbour(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Harbour GetFromOwnVillageHarbour(int ownVillageId, Query query = Query.All) => default;
		private static Harbour FetchFromOwnVillageHarbour(HarbourSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageHarbour(int ownVillageId, object dummy = null) => default;
		private void _availableShipsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _shipsOnTheWayNotify(object sender, PropertyChangedEventArgs args) {}
		private void _inProductionNotify(object sender, PropertyChangedEventArgs args) {}
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback() {}
		public static int GetMaxShips(OwnVillage currentVillage) => default;
		private static float GetArtefactBonusValue() => default;
	}
