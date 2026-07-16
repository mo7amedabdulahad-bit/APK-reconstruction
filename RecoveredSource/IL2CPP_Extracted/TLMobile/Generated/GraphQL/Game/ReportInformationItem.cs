// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ReportInformationItem : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private CombatInfoType _type;
		[ObservableValue]
		private string _message;
		[ObservableValue]
		private string _metadata;
		[ObservableValue]
		private string _messageDecoded;
		[ObservableValue]
		private string _combatSimulatorIcon;
		[ObservableValue]
		private IconType _iconType;
		[ObservableValue]
		private int _iconSpriteId;
		[ObservableValue]
		private int _tribeId;
		[ObservableValue]
		private int _typeId;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public CombatInfoType type { get => default; set {} }
		[ObservableValue]
		public string message { get => default; set {} }
		[ObservableValue]
		public string metadata { get => default; set {} }
		[ObservableValue]
		public string messageDecoded { get => default; set {} }
		[ObservableValue]
		public string combatSimulatorIcon { get => default; set {} }
		[ObservableValue]
		public IconType iconType { get => default; set {} }
		[ObservableValue]
		public int iconSpriteId { get => default; set {} }
		[ObservableValue]
		public int tribeId { get => default; set {} }
		[ObservableValue]
		public int typeId { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum IconType
		{
			Info = 0,
			Village = 1,
			Hero = 2,
			Building = 3,
			Unit = 4,
			Skull = 5
		}
	
		// Constructors
		public ReportInformationItem() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ReportInformationItemDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ReportInformationItemDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
		private void TryGetIconFromTag() {}
	}
