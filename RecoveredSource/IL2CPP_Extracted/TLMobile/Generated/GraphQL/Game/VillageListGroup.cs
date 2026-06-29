// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class VillageListGroup : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private GroupColor _color;
		[ObservableValue]
		private GraphQLObservableList<VillageListVillage> _villages;
		[ObservableValue]
		private bool _isExpanded;
		[ObservableValue]
		private int _incomingAttacks;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public GroupColor color { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<VillageListVillage> villages { get => default; set {} }
		[ObservableValue]
		public bool isExpanded { get => default; set {} }
		[ObservableValue]
		public int incomingAttacks { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public VillageListGroup() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(VillageListGroupDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(VillageListGroupDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListVillages(GraphQLObservableList<VillageListVillage> to, List<VillageListVillageDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _villagesNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
	}
