// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TownHall : GraphQLFetchable, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<Celebration> _celebrations;
		[ObservableValue]
		private GraphQLObservableList<OngoingCelebration> _ongoingCelebrations;
		[ObservableValue]
		private int _smallCelebrationMaxCP;
		[ObservableValue]
		private int _greatCelebrationMaxCP;
		private int ownVillageIdFromOwnVillageTownHall;
		private static readonly string[] namesInNestedResponseFromOwnVillageTownHall;
		[ObservableValue]
		private int _lastCelebrationTimestamp;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public TownHallSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<Celebration> celebrations { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OngoingCelebration> ongoingCelebrations { get => default; set {} }
		[ObservableValue]
		public int smallCelebrationMaxCP { get => default; set {} }
		[ObservableValue]
		public int greatCelebrationMaxCP { get => default; set {} }
		[ObservableValue]
		public int lastCelebrationTimestamp { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum TownHallSource
		{
			FromOwnVillageTownHall = 0
		}
	
		// Constructors
		public TownHall() {}
		static TownHall() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TownHallDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TownHallDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListCelebrations(GraphQLObservableList<Celebration> to, List<CelebrationDTO> from, int query) => default;
		private bool CopyValuesFromDtoListOngoingCelebrations(GraphQLObservableList<OngoingCelebration> to, List<OngoingCelebrationDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<TownHall> PromiseGetFromOwnVillageTownHall(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<TownHall> PromiseGetFromOwnVillageTownHall(out TownHall cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static TownHall GetNoFetchFromOwnVillageTownHall(int ownVillageId, Query query = Query.All) => default;
		public static TownHall GetFromOwnVillageTownHall(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static TownHall GetFromOwnVillageTownHall(int ownVillageId, Query query = Query.All) => default;
		private static TownHall FetchFromOwnVillageTownHall(TownHallSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageTownHall(int ownVillageId, object dummy = null) => default;
		private void _celebrationsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _ongoingCelebrationsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
