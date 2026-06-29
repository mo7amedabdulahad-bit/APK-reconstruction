// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CraftingItems : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.SmeltedItem> _smelt;
		[ObservableValue]
		private GraphQLObservableList<InventoryItem> _forge;
		private static readonly string[] namesInNestedResponseFromOwnPlayerHeroCrafting;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public CraftingItemsSource Source { get; set; }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.SmeltedItem> smelt { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<InventoryItem> forge { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			Smelting = 1,
			Forging = 2
		}
	
		public enum CraftingItemsSource
		{
			FromOwnPlayerHeroCrafting = 0
		}
	
		// Constructors
		public CraftingItems() {}
		static CraftingItems() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CraftingItemsDTO dtoValue) => default;
		private bool EqualToDTOSmelting(CraftingItemsDTO dtoValue) => default;
		private bool EqualToDTOForging(CraftingItemsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CraftingItemsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOSmelting(CraftingItemsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOForging(CraftingItemsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListSmelt(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.SmeltedItem> to, List<SmeltedItemDTO> from, int query) => default;
		private bool CopyValuesFromDtoListForge(GraphQLObservableList<InventoryItem> to, List<InventoryItemDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<CraftingItems> PromiseGetFromOwnPlayerHeroCrafting(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<CraftingItems> PromiseGetFromOwnPlayerHeroCrafting(out CraftingItems cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static CraftingItems GetNoFetchFromOwnPlayerHeroCrafting(Query query = Query.All) => default;
		public static CraftingItems GetFromOwnPlayerHeroCrafting(bool forceRefresh, Query query = Query.All) => default;
		public static CraftingItems GetFromOwnPlayerHeroCrafting(Query query = Query.All) => default;
		private static CraftingItems FetchFromOwnPlayerHeroCrafting(CraftingItemsSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerHeroCrafting(object dummy = null) => default;
		private void _smeltNotify(object sender, PropertyChangedEventArgs args) {}
		private void _forgeNotify(object sender, PropertyChangedEventArgs args) {}
	}
