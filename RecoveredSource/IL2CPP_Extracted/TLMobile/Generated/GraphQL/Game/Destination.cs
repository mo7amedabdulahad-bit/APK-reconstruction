// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Destination : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _id;
		[ObservableValue]
		private int _landDistribution;
		[ObservableValue]
		private int _tribeId;
		[ObservableValue]
		private int _mapId;
		[ObservableValue]
		private int _x;
		[ObservableValue]
		private int _y;
		[ObservableValue]
		private string _name;
		[ObservableValue]
		private int _type;
		[ObservableValue]
		private int _population;
		[ObservableValue]
		private bool _isWW;
		[ObservableValue]
		private GraphQLObservableList<OccupiedOasis> _occupiedOases;
		[ObservableValue]
		private Region _region;
		[ObservableValue]
		private string _typeText;
		[ObservableValue]
		private string _typeTitle;
		[ObservableValue]
		private bool _isShore;
		[ObservableValue]
		private bool _isCity;
		[ObservableValue]
		private Village _ownerVillage;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _player;
		[ObservableValue]
		private int? _victoryPoints;
		[ObservableValue]
		private float? _victoryPointsPerDay;
		[ObservableValue]
		private bool? _cropOnly;
		[ObservableValue]
		private int? _travelTime;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int id { get => default; set {} }
		[ObservableValue]
		public int landDistribution { get => default; set {} }
		[ObservableValue]
		public int tribeId { get => default; set {} }
		[ObservableValue]
		public int mapId { get => default; set {} }
		[ObservableValue]
		public int x { get => default; set {} }
		[ObservableValue]
		public int y { get => default; set {} }
		[ObservableValue]
		public string name { get => default; set {} }
		[ObservableValue]
		public int type { get => default; set {} }
		[ObservableValue]
		public int population { get => default; set {} }
		[ObservableValue]
		public bool isWW { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<OccupiedOasis> occupiedOases { get => default; set {} }
		[ObservableValue]
		public Region region { get => default; set {} }
		[ObservableValue]
		public string typeText { get => default; set {} }
		[ObservableValue]
		public string typeTitle { get => default; set {} }
		[ObservableValue]
		public bool isShore { get => default; set {} }
		[ObservableValue]
		public bool isCity { get => default; set {} }
		[ObservableValue]
		public Village ownerVillage { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player player { get => default; set {} }
		[ObservableValue]
		public int? victoryPoints { get => default; set {} }
		[ObservableValue]
		public float? victoryPointsPerDay { get => default; set {} }
		[ObservableValue]
		public bool? cropOnly { get => default; set {} }
		[ObservableValue]
		public int? travelTime { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Destination() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(DestinationDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(DestinationDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListOccupiedOases(GraphQLObservableList<OccupiedOasis> to, List<OccupiedOasisDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _occupiedOasesNotify(object sender, PropertyChangedEventArgs args) {}
	}
