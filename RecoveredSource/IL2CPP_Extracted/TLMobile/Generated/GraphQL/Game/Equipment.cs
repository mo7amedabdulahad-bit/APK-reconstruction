// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Equipment : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private InventoryItem _helmet;
		[ObservableValue]
		private InventoryItem _leftHand;
		[ObservableValue]
		private InventoryItem _rightHand;
		[ObservableValue]
		private InventoryItem _body;
		[ObservableValue]
		private InventoryItem _horse;
		[ObservableValue]
		private InventoryItem _shoes;
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
		private bool _hasBenefits;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public InventoryItem helmet { get => default; set {} }
		[ObservableValue]
		public InventoryItem leftHand { get => default; set {} }
		[ObservableValue]
		public InventoryItem rightHand { get => default; set {} }
		[ObservableValue]
		public InventoryItem body { get => default; set {} }
		[ObservableValue]
		public InventoryItem horse { get => default; set {} }
		[ObservableValue]
		public InventoryItem shoes { get => default; set {} }
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
		public bool hasBenefits { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Equipment() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(EquipmentDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(EquipmentDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback(object data = null) {}
		public void ConvertToWrapper() {}
		private bool AnyBenefits() => default;
		private bool HasSlotEffect(InventoryItem item) => default;
	}
