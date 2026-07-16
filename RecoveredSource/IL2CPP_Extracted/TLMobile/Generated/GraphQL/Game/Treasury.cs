// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Treasury : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<ActivatedAncientPower> _activatedAncientPowers;
		private int ownVillageIdFromOwnVillageTreasury;
		private static readonly string[] namesInNestedResponseFromOwnVillageTreasury;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public TreasurySource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<ActivatedAncientPower> activatedAncientPowers { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum TreasurySource
		{
			FromOwnVillageTreasury = 0
		}
	
		// Constructors
		public Treasury() {}
		static Treasury() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TreasuryDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TreasuryDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListActivatedAncientPowers(GraphQLObservableList<ActivatedAncientPower> to, List<ActivatedAncientPowerDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Treasury> PromiseGetFromOwnVillageTreasury(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Treasury> PromiseGetFromOwnVillageTreasury(out Treasury cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Treasury GetNoFetchFromOwnVillageTreasury(int ownVillageId, Query query = Query.All) => default;
		public static Treasury GetFromOwnVillageTreasury(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Treasury GetFromOwnVillageTreasury(int ownVillageId, Query query = Query.All) => default;
		private static Treasury FetchFromOwnVillageTreasury(TreasurySource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageTreasury(int ownVillageId, object dummy = null) => default;
		private void _activatedAncientPowersNotify(object sender, PropertyChangedEventArgs args) {}
	}
