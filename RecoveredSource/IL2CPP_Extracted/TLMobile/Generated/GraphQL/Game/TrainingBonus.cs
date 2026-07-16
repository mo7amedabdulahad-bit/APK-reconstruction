// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TrainingBonus : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		[Obsolete("Moved to specific building of ownVillage")]
		private float _value;
		private int trainingBonusBuildingId;
		private static readonly string[] namesInNestedResponse;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public TrainingBonusSource Source { get; set; }
		[ObservableValue]
		[Obsolete("Moved to specific building of ownVillage")]
		public float value { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum TrainingBonusSource
		{
			RootLevel = 0
		}
	
		// Constructors
		public TrainingBonus() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TrainingBonusDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TrainingBonusDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		[Obsolete("Please use {ownPlayer{village{barracks/hospital/stable/trapper{trainingBonus}}}}")]
		public static IPromise<TrainingBonus> PromiseGet(int trainingBonusBuildingId, Query query = Query.All, bool forceFetch = true) => default;
		[Obsolete("Please use {ownPlayer{village{barracks/hospital/stable/trapper{trainingBonus}}}}")]
		public static IPromise<TrainingBonus> PromiseGet(out TrainingBonus cacheObject, int trainingBonusBuildingId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		[Obsolete("Please use {ownPlayer{village{barracks/hospital/stable/trapper{trainingBonus}}}}")]
		public static TrainingBonus GetNoFetch(int trainingBonusBuildingId, Query query = Query.All) => default;
		[Obsolete("Please use {ownPlayer{village{barracks/hospital/stable/trapper{trainingBonus}}}}")]
		public static TrainingBonus Get(bool forceRefresh, int trainingBonusBuildingId, Query query = Query.All) => default;
		[Obsolete("Please use {ownPlayer{village{barracks/hospital/stable/trapper{trainingBonus}}}}")]
		public static TrainingBonus Get(int trainingBonusBuildingId, Query query = Query.All) => default;
		private static TrainingBonus Fetch(TrainingBonusSource origin, int trainingBonusBuildingId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPart(int trainingBonusBuildingId, object dummy = null) => default;
	}
