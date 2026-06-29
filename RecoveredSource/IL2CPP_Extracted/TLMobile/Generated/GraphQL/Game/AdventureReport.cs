// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AdventureReport : ReportInterface
	{
		// Fields
		[ObservableValue]
		private Village _sourceVillage;
		[ObservableValue]
		private Adventure _adventure;
		[ObservableValue]
		private AdventureResult _result;
		[ObservableValue]
		private int? _silver;
		[ObservableValue]
		private AdventureDroppedUnit _unit;
		[ObservableValue]
		private AdventureDroppedItem _item;
		[ObservableValue]
		private ResourcesAmount _addedResources;
		[ObservableValue]
		private TroopInfo _troopInfo;
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
		[ObservableValue]
		private bool _nothingFound;
		[ObservableValue]
		private InventoryItemWrapper _foundItem;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public Village sourceVillage { get => default; set {} }
		[ObservableValue]
		public Adventure adventure { get => default; set {} }
		[ObservableValue]
		public AdventureResult result { get => default; set {} }
		[ObservableValue]
		public int? silver { get => default; set {} }
		[ObservableValue]
		public AdventureDroppedUnit unit { get => default; set {} }
		[ObservableValue]
		public AdventureDroppedItem item { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount addedResources { get => default; set {} }
		[ObservableValue]
		public TroopInfo troopInfo { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
		[ObservableValue]
		public bool nothingFound { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper foundItem { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AdventureReport() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AdventureReportDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AdventureReportDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		[UICallable]
		public void ShowItemDetailsPopup() {}
	}
