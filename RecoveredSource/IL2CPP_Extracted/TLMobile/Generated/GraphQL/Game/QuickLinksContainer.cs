// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class QuickLinksContainer : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<QuickLinkSlot> _all;
		[ObservableValue]
		private GraphQLObservableList<QuickLinkSlot> _villageListSet;
		[ObservableValue]
		private GraphQLObservableList<QuickLinkSlot> _villageSet;
		private int ownVillageIdFromOwnVillageQuickLinks;
		private static readonly string[] namesInNestedResponseFromOwnVillageQuickLinks;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public QuickLinksContainerSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<QuickLinkSlot> all { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<QuickLinkSlot> villageListSet { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<QuickLinkSlot> villageSet { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum QuickLinksContainerSource
		{
			FromOwnVillageQuickLinks = 0
		}
	
		// Constructors
		public QuickLinksContainer() {}
		static QuickLinksContainer() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(QuickLinksContainerDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(QuickLinksContainerDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListAll(GraphQLObservableList<QuickLinkSlot> to, List<QuickLinkSlotDTO> from, int query) => default;
		private bool CopyValuesFromDtoListVillageListSet(GraphQLObservableList<QuickLinkSlot> to, List<QuickLinkSlotDTO> from, int query) => default;
		private bool CopyValuesFromDtoListVillageSet(GraphQLObservableList<QuickLinkSlot> to, List<QuickLinkSlotDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<QuickLinksContainer> PromiseGetFromOwnVillageQuickLinks(int ownVillageId, Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<QuickLinksContainer> PromiseGetFromOwnVillageQuickLinks(out QuickLinksContainer cacheObject, int ownVillageId, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static QuickLinksContainer GetNoFetchFromOwnVillageQuickLinks(int ownVillageId, Query query = Query.All) => default;
		public static QuickLinksContainer GetFromOwnVillageQuickLinks(bool forceRefresh, int ownVillageId, Query query = Query.All) => default;
		public static QuickLinksContainer GetFromOwnVillageQuickLinks(int ownVillageId, Query query = Query.All) => default;
		private static QuickLinksContainer FetchFromOwnVillageQuickLinks(QuickLinksContainerSource origin, int ownVillageId, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnVillageQuickLinks(int ownVillageId, object dummy = null) => default;
		private void _allNotify(object sender, PropertyChangedEventArgs args) {}
		private void _villageListSetNotify(object sender, PropertyChangedEventArgs args) {}
		private void _villageSetNotify(object sender, PropertyChangedEventArgs args) {}
	}
