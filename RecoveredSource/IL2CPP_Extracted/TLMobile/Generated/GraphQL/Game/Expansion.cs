// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Expansion : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<ExpansionSlot> _slots;
		[ObservableValue]
		private GraphQLObservableList<int> _levels;
		private int ownVillageIdFromOwnVillageExpansion;
		private static readonly string[] namesInNestedResponseFromOwnVillageExpansion;
		[ObservableValue]
		private int _availableSlots;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public ExpansionSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<ExpansionSlot> slots { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<int> levels { get => default; set {} }
		[ObservableValue]
		public int availableSlots { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum ExpansionSource
		{
			FromOwnVillageExpansion = 0
		}
	
		// Constructors
		public Expansion() {}
		static Expansion() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ExpansionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ExpansionDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListSlots(GraphQLObservableList<ExpansionSlot> to, List<ExpansionSlotDTO> from, int query) => default;
		private bool CopyValuesFromDtoListLevels(GraphQLObservableList<int> to, List<int?> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Expansion> PromiseGetFromOwnVillageExpansion(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Expansion> PromiseGetFromOwnVillageExpansion(out Expansion cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Expansion GetNoFetchFromOwnVillageExpansion(int ownVillageId, Query query = Query.All) => default;
		public static Expansion GetFromOwnVillageExpansion(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Expansion GetFromOwnVillageExpansion(int ownVillageId, Query query = Query.All) => default;
		private static Expansion FetchFromOwnVillageExpansion(ExpansionSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageExpansion(int ownVillageId, object dummy = null) => default;
		private void _slotsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _levelsNotify(object sender, PropertyChangedEventArgs args) {}
		public void UpdateAvailableSlots(int residenceLevel) {}
	}
