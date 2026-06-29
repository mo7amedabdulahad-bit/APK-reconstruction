// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroEquipment : GraphQLFetchable
	{
		// Fields
		[ObservableValue]
		private HeroInventoryItem _helmet;
		[ObservableValue]
		private HeroInventoryItem _leftHand;
		[ObservableValue]
		private HeroInventoryItem _rightHand;
		[ObservableValue]
		private HeroInventoryItem _body;
		[ObservableValue]
		private HeroInventoryItem _horse;
		[ObservableValue]
		private HeroInventoryItem _shoes;
		[ObservableValue]
		private HeroInventoryItem _bag;
		private static readonly string[] namesInNestedResponseFromOwnPlayerHeroEquipment;
		private ObservableList<HeroInventoryItem> items;
		[ObservableValue]
		private InventoryItemWrapper _wrappedHelmet;
		[ObservableValue]
		private InventoryItemWrapper _wrappedLeftHand;
		[ObservableValue]
		private InventoryItemWrapper _wrappedRightHand;
		[ObservableValue]
		private InventoryItemWrapper _wrappedBody;
		[ObservableValue]
		private InventoryItemWrapper _wrappedHorse;
		[ObservableValue]
		private InventoryItemWrapper _wrappedShoes;
		[ObservableValue]
		private InventoryItemWrapper _wrappedBag;
		[ObservableValue]
		private bool _hasBenefits;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		public HeroEquipmentSource Source { get; set; }
		[ObservableValue]
		public HeroInventoryItem helmet { get => default; set {} }
		[ObservableValue]
		public HeroInventoryItem leftHand { get => default; set {} }
		[ObservableValue]
		public HeroInventoryItem rightHand { get => default; set {} }
		[ObservableValue]
		public HeroInventoryItem body { get => default; set {} }
		[ObservableValue]
		public HeroInventoryItem horse { get => default; set {} }
		[ObservableValue]
		public HeroInventoryItem shoes { get => default; set {} }
		[ObservableValue]
		public HeroInventoryItem bag { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper wrappedHelmet { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper wrappedLeftHand { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper wrappedRightHand { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper wrappedBody { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper wrappedHorse { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper wrappedShoes { get => default; set {} }
		[ObservableValue]
		public InventoryItemWrapper wrappedBag { get => default; set {} }
		[ObservableValue]
		public bool hasBenefits { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum HeroEquipmentSource
		{
			FromOwnPlayerHeroEquipment = 0
		}
	
		// Constructors
		public HeroEquipment() {}
		static HeroEquipment() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HeroEquipmentDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HeroEquipmentDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void FillWithDTO(object dataObject, bool beSilent = false) {}
		public static IPromise<HeroEquipment> PromiseGetFromOwnPlayerHeroEquipment(Query query = Query.All, bool forceFetch = true) => default;
		public static IPromise<HeroEquipment> PromiseGetFromOwnPlayerHeroEquipment(out HeroEquipment cacheObject, Query query = Query.All, bool forceFetch = true) {
			cacheObject = default;
			return default;
		}
		public static HeroEquipment GetNoFetchFromOwnPlayerHeroEquipment(Query query = Query.All) => default;
		public static HeroEquipment GetFromOwnPlayerHeroEquipment(bool forceRefresh, Query query = Query.All) => default;
		public static HeroEquipment GetFromOwnPlayerHeroEquipment(Query query = Query.All) => default;
		private static HeroEquipment FetchFromOwnPlayerHeroEquipment(HeroEquipmentSource origin, Query query = Query.All, bool fetchIfMissing = true, ServerObject newObjectToUse = null, bool forceRefresh = false) => default;
		public void Update(Query queryType = Query.All) {}
		public override void Update(int queryType) {}
		public void ObserveOnce(Query queryType, System.Action callback, bool onlyReactOnServerData = true) {}
		public void StopObserveOnce(Query queryType, System.Action callback) {}
		public override string[] GetNamesInNestedResponse() => default;
		private static string GetRequestBodyPartFromOwnPlayerHeroEquipment(object dummy = null) => default;
		public override void AfterServerDataCallback() {}
		public ObservableList<HeroInventoryItem> GetAsArray() => default;
		public Equipment ConvertToEquipment() => default;
		public void ConvertToWrapper() {}
		private bool AnyBenefits() => default;
		private bool HasSlotEffect(HeroInventoryItem item) => default;
	}
