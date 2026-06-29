// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class CombatSimulatorEquipment : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _tribeId;
		[ObservableValue]
		private GraphQLObservableList<CombatSimulatorEquipmentSlot> _leftHand;
		[ObservableValue]
		private GraphQLObservableList<CombatSimulatorEquipmentSlot> _rightHand;
		[ObservableValue]
		private GraphQLObservableList<CombatSimulatorEquipmentSlot> _body;
		[ObservableValue]
		private CombatSimulatorEquipmentSlot _bag;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int tribeId { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<CombatSimulatorEquipmentSlot> leftHand { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<CombatSimulatorEquipmentSlot> rightHand { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<CombatSimulatorEquipmentSlot> body { get => default; set {} }
		[ObservableValue]
		public CombatSimulatorEquipmentSlot bag { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public CombatSimulatorEquipment() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CombatSimulatorEquipmentDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CombatSimulatorEquipmentDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListLeftHand(GraphQLObservableList<CombatSimulatorEquipmentSlot> to, List<CombatSimulatorEquipmentSlotDTO> from, int query) => default;
		private bool CopyValuesFromDtoListRightHand(GraphQLObservableList<CombatSimulatorEquipmentSlot> to, List<CombatSimulatorEquipmentSlotDTO> from, int query) => default;
		private bool CopyValuesFromDtoListBody(GraphQLObservableList<CombatSimulatorEquipmentSlot> to, List<CombatSimulatorEquipmentSlotDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _leftHandNotify(object sender, PropertyChangedEventArgs args) {}
		private void _rightHandNotify(object sender, PropertyChangedEventArgs args) {}
		private void _bodyNotify(object sender, PropertyChangedEventArgs args) {}
	}
