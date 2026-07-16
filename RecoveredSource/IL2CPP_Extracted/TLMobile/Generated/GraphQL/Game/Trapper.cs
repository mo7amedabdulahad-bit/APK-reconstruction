// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Trapper : GraphQLFetchable, IBackendUpdateable, ITimedUpdater
	{
		// Fields
		[ObservableValue]
		private int _total;
		[ObservableValue]
		private int _occupied;
		[ObservableValue]
		private GraphQLObservableList<TrapInProductionEntry> _inProduction;
		[ObservableValue]
		private int? _nextTrapIsReadyAt;
		[ObservableValue]
		private float _trainingBonus;
		private int ownVillageIdFromOwnVillageTrapper;
		private static readonly string[] namesInNestedResponseFromOwnVillageTrapper;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public TrapperSource Source { get; set; }
		[ObservableValue]
		public int total { get => default; set {} }
		[ObservableValue]
		public int occupied { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TrapInProductionEntry> inProduction { get => default; set {} }
		[ObservableValue]
		public int? nextTrapIsReadyAt { get => default; set {} }
		[ObservableValue]
		public float trainingBonus { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum TrapperSource
		{
			FromOwnVillageTrapper = 0
		}
	
		// Constructors
		public Trapper() {}
		static Trapper() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TrapperDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TrapperDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListInProduction(GraphQLObservableList<TrapInProductionEntry> to, List<TrapInProductionEntryDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Trapper> PromiseGetFromOwnVillageTrapper(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Trapper> PromiseGetFromOwnVillageTrapper(out Trapper cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Trapper GetNoFetchFromOwnVillageTrapper(int ownVillageId, Query query = Query.All) => default;
		public static Trapper GetFromOwnVillageTrapper(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Trapper GetFromOwnVillageTrapper(int ownVillageId, Query query = Query.All) => default;
		private static Trapper FetchFromOwnVillageTrapper(TrapperSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageTrapper(int ownVillageId, object dummy = null) => default;
		private void _inProductionNotify(object sender, PropertyChangedEventArgs args) {}
		public int GetRequiredUpdateTime() => default;
		public override void AfterServerDataCallback() {}
		public static int GetMaxTraps(OwnVillage currentVillage) => default;
		private static float GetArtefactBonusValue() => default;
	}
