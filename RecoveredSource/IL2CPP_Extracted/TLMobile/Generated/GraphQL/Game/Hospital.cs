// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Hospital : GraphQLFetchable, IBackendUpdateable
	{
		// Fields
		[ObservableValue]
		private UnitsAmount _woundedTroops;
		[ObservableValue]
		private GraphQLObservableList<TrainingBatch> _healingTroops;
		[ObservableValue]
		private float _trainingBonus;
		private int ownVillageIdFromOwnVillageHospital;
		private static readonly string[] namesInNestedResponseFromOwnVillageHospital;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public HospitalSource Source { get; set; }
		[ObservableValue]
		public UnitsAmount woundedTroops { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TrainingBatch> healingTroops { get => default; set {} }
		[ObservableValue]
		public float trainingBonus { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum HospitalSource
		{
			FromOwnVillageHospital = 0
		}
	
		// Constructors
		public Hospital() {}
		static Hospital() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HospitalDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HospitalDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListHealingTroops(GraphQLObservableList<TrainingBatch> to, List<TrainingBatchDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Hospital> PromiseGetFromOwnVillageHospital(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Hospital> PromiseGetFromOwnVillageHospital(out Hospital cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Hospital GetNoFetchFromOwnVillageHospital(int ownVillageId, Query query = Query.All) => default;
		public static Hospital GetFromOwnVillageHospital(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Hospital GetFromOwnVillageHospital(int ownVillageId, Query query = Query.All) => default;
		private static Hospital FetchFromOwnVillageHospital(HospitalSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageHospital(int ownVillageId, object dummy = null) => default;
		private void _healingTroopsNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
	}
