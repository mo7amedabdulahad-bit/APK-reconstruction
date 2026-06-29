// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroAppearance : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private Colors _colors;
		[ObservableValue]
		private string _body;
		[ObservableValue]
		private string _leftArm;
		[ObservableValue]
		private string _rightArm;
		[ObservableValue]
		private int _jaw;
		[ObservableValue]
		private int _eyes;
		[ObservableValue]
		private int _nose;
		[ObservableValue]
		private int _mouth;
		[ObservableValue]
		private int _ears;
		[ObservableValue]
		private int _hair;
		[ObservableValue]
		private int _brows;
		[ObservableValue]
		private int? _beard;
		[ObservableValue]
		private int? _scar;
		[ObservableValue]
		private int? _tattoo;
		[ObservableValue]
		private AppearanceReplacementType _replacementTypeFrontHair;
		[ObservableValue]
		private AppearanceReplacementType _replacementTypeBackHair;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public Colors colors { get => default; set {} }
		[ObservableValue]
		public string body { get => default; set {} }
		[ObservableValue]
		public string leftArm { get => default; set {} }
		[ObservableValue]
		public string rightArm { get => default; set {} }
		[ObservableValue]
		public int jaw { get => default; set {} }
		[ObservableValue]
		public int eyes { get => default; set {} }
		[ObservableValue]
		public int nose { get => default; set {} }
		[ObservableValue]
		public int mouth { get => default; set {} }
		[ObservableValue]
		public int ears { get => default; set {} }
		[ObservableValue]
		public int hair { get => default; set {} }
		[ObservableValue]
		public int brows { get => default; set {} }
		[ObservableValue]
		public int? beard { get => default; set {} }
		[ObservableValue]
		public int? scar { get => default; set {} }
		[ObservableValue]
		public int? tattoo { get => default; set {} }
		[ObservableValue]
		public AppearanceReplacementType replacementTypeFrontHair { get => default; set {} }
		[ObservableValue]
		public AppearanceReplacementType replacementTypeBackHair { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		public enum AppearanceReplacementType
		{
			NotReplaced = 0,
			PartiallyReplaced = 1,
			FullReplace = 2
		}
	
		// Constructors
		public HeroAppearance() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HeroAppearanceDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HeroAppearanceDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public HeroAppearance GetDeepCopy() => default;
		public void UpdateReplacementTypes(Gender gender) {}
	}
