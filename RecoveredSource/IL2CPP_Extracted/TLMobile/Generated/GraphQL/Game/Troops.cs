// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Troops : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private StandingTroop _ownTroopsAtTown;
		[ObservableValue]
		private GraphQLObservableList<TroopsInVillage> _allTroopsInVillage;
		private int ownVillageIdFromOwnVillageTroops;
		private static readonly string[] namesInNestedResponseFromOwnVillageTroops;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public TroopsSource Source { get; set; }
		[ObservableValue]
		public StandingTroop ownTroopsAtTown { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TroopsInVillage> allTroopsInVillage { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum TroopsSource
		{
			FromOwnVillageTroops = 0
		}
	
		// Constructors
		public Troops() {}
		static Troops() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TroopsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TroopsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAllTroopsInVillage(GraphQLObservableList<TroopsInVillage> to, List<TroopsInVillageDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Troops> PromiseGetFromOwnVillageTroops(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Troops> PromiseGetFromOwnVillageTroops(out Troops cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Troops GetNoFetchFromOwnVillageTroops(int ownVillageId, Query query = Query.All) => default;
		public static Troops GetFromOwnVillageTroops(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Troops GetFromOwnVillageTroops(int ownVillageId, Query query = Query.All) => default;
		private static Troops FetchFromOwnVillageTroops(TroopsSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageTroops(int ownVillageId, object dummy = null) => default;
		private void _allTroopsInVillageNotify(object sender, PropertyChangedEventArgs args) {}
	}
