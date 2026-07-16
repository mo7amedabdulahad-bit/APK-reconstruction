// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Embassy : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<NearbyAllianceInfo> _nearbyAlliances;
		[ObservableValue]
		private GraphQLObservableList<AllianceInvitation> _invitations;
		private int ownVillageIdFromOwnVillageEmbassy;
		private static readonly string[] namesInNestedResponseFromOwnVillageEmbassy;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public EmbassySource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<NearbyAllianceInfo> nearbyAlliances { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<AllianceInvitation> invitations { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum EmbassySource
		{
			FromOwnVillageEmbassy = 0
		}
	
		// Constructors
		public Embassy() {}
		static Embassy() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(EmbassyDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(EmbassyDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListNearbyAlliances(GraphQLObservableList<NearbyAllianceInfo> to, List<NearbyAllianceInfoDTO> from, int query) => default;
		private bool CopyValuesFromDtoListInvitations(GraphQLObservableList<AllianceInvitation> to, List<AllianceInvitationDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<Embassy> PromiseGetFromOwnVillageEmbassy(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<Embassy> PromiseGetFromOwnVillageEmbassy(out Embassy cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static Embassy GetNoFetchFromOwnVillageEmbassy(int ownVillageId, Query query = Query.All) => default;
		public static Embassy GetFromOwnVillageEmbassy(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static Embassy GetFromOwnVillageEmbassy(int ownVillageId, Query query = Query.All) => default;
		private static Embassy FetchFromOwnVillageEmbassy(EmbassySource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageEmbassy(int ownVillageId, object dummy = null) => default;
		private void _nearbyAlliancesNotify(object sender, PropertyChangedEventArgs args) {}
		private void _invitationsNotify(object sender, PropertyChangedEventArgs args) {}
	}
