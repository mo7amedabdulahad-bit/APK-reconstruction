// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TraderArrivedReport : ReportInterface
	{
		// Fields
		[ObservableValue]
		private RemovablePlayer _senderPlayer;
		[ObservableValue]
		private Village _from;
		[ObservableValue]
		private RemovablePlayer _receiverPlayer;
		[ObservableValue]
		private Village _to;
		[ObservableValue]
		private int _duration;
		[ObservableValue]
		private ResourcesAmount _broughtResources;
		[ObservableValue]
		private int? _icon;
		[ObservableValue]
		private bool? _ship;
		private const int ShipHeaderIndex = 101;
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public RemovablePlayer senderPlayer { get => default; set {} }
		[ObservableValue]
		public Village from { get => default; set {} }
		[ObservableValue]
		public RemovablePlayer receiverPlayer { get => default; set {} }
		[ObservableValue]
		public Village to { get => default; set {} }
		[ObservableValue]
		public int duration { get => default; set {} }
		[ObservableValue]
		public ResourcesAmount broughtResources { get => default; set {} }
		[ObservableValue]
		public int? icon { get => default; set {} }
		[ObservableValue]
		public bool? ship { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public TraderArrivedReport() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(TraderArrivedReportDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(TraderArrivedReportDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
