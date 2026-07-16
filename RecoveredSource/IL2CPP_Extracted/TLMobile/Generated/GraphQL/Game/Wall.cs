// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Wall : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _buildingTypeId;
		[ObservableValue]
		private int _slotId;
		[ObservableValue]
		private int _level;
		[ObservableValue]
		private int _levelUpdateTimestamp;
		[ObservableValue]
		private int? _watchtowersLevel;
		[ObservableValue]
		private GraphQLObservableList<BuildEvent> _watchtowersInUpgrade;
		private int ownVillageIdFromOwnVillageWall;
		private static readonly string[] namesInNestedResponseFromOwnVillageWall;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public WallSource Source { get; set; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int buildingTypeId { get => default; set {} }
		[ObservableValue]
		public int slotId { get => default; set {} }
		[ObservableValue]
		public int level { get => default; set {} }
		[ObservableValue]
		public int levelUpdateTimestamp { get => default; set {} }
		[ObservableValue]
		public int? watchtowersLevel { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<BuildEvent> watchtowersInUpgrade { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum WallSource
		{
			FromOwnVillageWall = 0
		}
	
		// Constructors
		public Wall() {}
		static Wall() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(WallDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(WallDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListWatchtowersInUpgrade(GraphQLObservableList<BuildEvent> to, List<BuildEventDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Wall> PromiseGetFromOwnVillageWall(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Wall> PromiseGetFromOwnVillageWall(out Wall cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Wall GetNoFetchFromOwnVillageWall(int ownVillageId, Query query = Query.All) => default;
		public static Wall GetFromOwnVillageWall(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Wall GetFromOwnVillageWall(int ownVillageId, Query query = Query.All) => default;
		private static Wall FetchFromOwnVillageWall(WallSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageWall(int ownVillageId, object dummy = null) => default;
		private void _watchtowersInUpgradeNotify(object sender, PropertyChangedEventArgs args) {}
	}
