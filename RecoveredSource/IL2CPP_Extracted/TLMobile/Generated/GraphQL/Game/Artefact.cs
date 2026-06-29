// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Artefact : PlaceBonusInterface
	{
		// Fields
		[ObservableValue]
		private bool _isActive;
		[ObservableValue]
		private int? _conquerTime;
		[ObservableValue]
		private int? _timeOfActivation;
		[ObservableValue]
		private Village _village;
		[ObservableValue]
		private GraphQLObservableList<FormerOwners> _formerOwners;
		private int ownVillageIdListFromOwnVillageNearbyArtefacts;
		private ArtefactSize artefactsTypeListByArtefacts;
		private const string NegativeDescriptionSuffix = "_neg";
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public bool isActive { get => default; set {} }
		[ObservableValue]
		public int? conquerTime { get => default; set {} }
		[ObservableValue]
		public int? timeOfActivation { get => default; set {} }
		[ObservableValue]
		public Village village { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<FormerOwners> formerOwners { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum ArtefactListSource
		{
			FromOwnPlayerStoredArtefacts = 0,
			FromOwnVillageNearbyArtefacts = 1,
			RootLevelByArtefacts = 2
		}
	
		// Constructors
		public Artefact() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ArtefactDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ArtefactDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListFormerOwners(GraphQLObservableList<FormerOwners> to, List<FormerOwnersDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public static GraphQLFetchableList<Artefact> CollectionGetNoFetchFromOwnPlayerStoredArtefacts(Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Artefact>> PromiseCollectionGetFromOwnPlayerStoredArtefacts(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Artefact>> PromiseCollectionGetFromOwnPlayerStoredArtefacts(out GraphQLFetchableList<Artefact> cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Artefact> CollectionGetFromOwnPlayerStoredArtefacts(Query query = Query.All) => default;
		public static GraphQLFetchableList<Artefact> CollectionGetFromOwnPlayerStoredArtefacts(bool forceRefresh, Query query = Query.All) => default;
		private static GraphQLFetchableList<Artefact> CollectionFetchFromOwnPlayerStoredArtefacts(ArtefactListSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnPlayerStoredArtefacts(object dummy = null) => default;
		public static GraphQLFetchableList<Artefact> CollectionGetNoFetchFromOwnVillageNearbyArtefacts(int ownVillageId, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Artefact>> PromiseCollectionGetFromOwnVillageNearbyArtefacts(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Artefact>> PromiseCollectionGetFromOwnVillageNearbyArtefacts(out GraphQLFetchableList<Artefact> cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Artefact> CollectionGetFromOwnVillageNearbyArtefacts(int ownVillageId, Query query = Query.All) => default;
		public static GraphQLFetchableList<Artefact> CollectionGetFromOwnVillageNearbyArtefacts(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		private static GraphQLFetchableList<Artefact> CollectionFetchFromOwnVillageNearbyArtefacts(ArtefactListSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartFromOwnVillageNearbyArtefacts(int ownVillageId, object dummy = null) => default;
		public static GraphQLFetchableList<Artefact> CollectionGetNoFetchByArtefacts(ArtefactSize artefactsType, Query query = Query.All) => default;
		public static IPromise<GraphQLFetchableList<Artefact>> PromiseCollectionGetByArtefacts(ArtefactSize artefactsType, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<GraphQLFetchableList<Artefact>> PromiseCollectionGetByArtefacts(out GraphQLFetchableList<Artefact> cacheObject, ArtefactSize artefactsType, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static GraphQLFetchableList<Artefact> CollectionGetByArtefacts(ArtefactSize artefactsType, Query query = Query.All) => default;
		public static GraphQLFetchableList<Artefact> CollectionGetByArtefacts(bool forceRefresh, ArtefactSize artefactsType, Query query = Query.All) => default;
		private static GraphQLFetchableList<Artefact> CollectionFetchByArtefacts(ArtefactListSource origin, ArtefactSize artefactsType, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		private static string GetRequestBodyPartByArtefacts(ArtefactSize artefactsType, object dummy = null) => default;
		private void _formerOwnersNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback(object data = null) {}
		public override void CalculateDistance(int x, int y) {}
	}
