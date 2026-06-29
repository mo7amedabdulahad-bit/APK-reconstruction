// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorItems : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> _leftHand;
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> _rightHand;
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> _body;
		[ObservableValue]
		private GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> _bag;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> leftHand { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> rightHand { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> body { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> bag { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			Simplified = 1
		}
	
		// Constructors
		public CombatSimulatorItems() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CombatSimulatorItemsDTO dtoValue) => default;
		private bool EqualToDTOSimplified(CombatSimulatorItemsDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CombatSimulatorItemsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOSimplified(CombatSimulatorItemsDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListLeftHand(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> to, List<ItemDTO> from, int query) => default;
		private bool CopyValuesFromDtoListRightHand(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> to, List<ItemDTO> from, int query) => default;
		private bool CopyValuesFromDtoListBody(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> to, List<ItemDTO> from, int query) => default;
		private bool CopyValuesFromDtoListBag(GraphQLObservableList<TLMobile.Generated.GraphQL.Game.Item> to, List<ItemDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _leftHandNotify(object sender, PropertyChangedEventArgs args) {}
		private void _rightHandNotify(object sender, PropertyChangedEventArgs args) {}
		private void _bodyNotify(object sender, PropertyChangedEventArgs args) {}
		private void _bagNotify(object sender, PropertyChangedEventArgs args) {}
	}
