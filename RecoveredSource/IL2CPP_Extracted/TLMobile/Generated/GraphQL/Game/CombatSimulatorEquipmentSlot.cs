// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorEquipmentSlot : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private string _category;
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> _items;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public string category { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> items { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public CombatSimulatorEquipmentSlot() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CombatSimulatorEquipmentSlotDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CombatSimulatorEquipmentSlotDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListItems(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> to, List<ItemDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _itemsNotify(object sender, PropertyChangedEventArgs args) {}
	}
