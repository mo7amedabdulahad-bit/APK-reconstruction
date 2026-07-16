// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Cropland : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private float _distance;
		[ObservableValue]
		private int _x;
		[ObservableValue]
		private int _y;
		[ObservableValue]
		private Region _region;
		[ObservableValue]
		private CroplandType _type;
		[ObservableValue]
		private CroplandBonus? _bonus;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Player _occupiedBy;
		public static readonly int CropLandBonusCount;
		[ObservableValue]
		private int _mapId;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.Coordinate _coordinate;
		[ObservableValue]
		private int _croplandBonusInt;
		[ObservableValue]
		private int _croplandTypeInt;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public float distance { get => default; set {} }
		[ObservableValue]
		public int x { get => default; set {} }
		[ObservableValue]
		public int y { get => default; set {} }
		[ObservableValue]
		public Region region { get => default; set {} }
		[ObservableValue]
		public CroplandType type { get => default; set {} }
		[ObservableValue]
		public CroplandBonus? bonus { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Player occupiedBy { get => default; set {} }
		[ObservableValue]
		public int mapId { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.Coordinate coordinate { get => default; set {} }
		[ObservableValue]
		public int croplandBonusInt { get => default; set {} }
		[ObservableValue]
		public int croplandTypeInt { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Cropland() {}
		static Cropland() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(CroplandDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(CroplandDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback(object data = null) {}
		public static int CropLandBonusToInt(CroplandBonus? croplandBonus) => default;
		public static int CropLandTypeToInt(CroplandType? croplandType) => default;
	}
