// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class OwnTroopsConsumption : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _reinforcements;
		[ObservableValue]
		private int _inOases;
		[ObservableValue]
		private int? _forwarded;
		[ObservableValue]
		private int? _horseDrinkingTrough;
		[ObservableValue]
		private float _artefactBonus;
		[ObservableValue]
		private float? _worldWonderCropBonus;
		[ObservableValue]
		private int? _total;
		[ObservableValue]
		private int _inVillage;
		[ObservableValue]
		private int _onTheWay;
		[ObservableValue]
		private int _imprisoned;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int reinforcements { get => default; set {} }
		[ObservableValue]
		public int inOases { get => default; set {} }
		[ObservableValue]
		public int? forwarded { get => default; set {} }
		[ObservableValue]
		public int? horseDrinkingTrough { get => default; set {} }
		[ObservableValue]
		public float artefactBonus { get => default; set {} }
		[ObservableValue]
		public float? worldWonderCropBonus { get => default; set {} }
		[ObservableValue]
		public int? total { get => default; set {} }
		[ObservableValue]
		public int inVillage { get => default; set {} }
		[ObservableValue]
		public int onTheWay { get => default; set {} }
		[ObservableValue]
		public int imprisoned { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public OwnTroopsConsumption() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(OwnTroopsConsumptionDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(OwnTroopsConsumptionDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
	}
