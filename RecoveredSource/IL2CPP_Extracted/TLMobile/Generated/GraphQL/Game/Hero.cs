// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Hero : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private Gender _gender;
		[ObservableValue]
		private string _imageHash;
		[ObservableValue]
		private int _level;
		[ObservableValue]
		private int _xp;
		[ObservableValue]
		private Equipment _equipment;
		[ObservableValue]
		private TLMobile.Generated.GraphQL.Game.HeroAppearance _appearance;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public Gender gender { get => default; set {} }
		[ObservableValue]
		public string imageHash { get => default; set {} }
		[ObservableValue]
		public int level { get => default; set {} }
		[ObservableValue]
		public int xp { get => default; set {} }
		[ObservableValue]
		public Equipment equipment { get => default; set {} }
		[ObservableValue]
		public TLMobile.Generated.GraphQL.Game.HeroAppearance appearance { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			Portrait = 1,
			OnlyXp = 2
		}
	
		// Constructors
		public Hero() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HeroDTO dtoValue) => default;
		private bool EqualToDTOPortrait(HeroDTO dtoValue) => default;
		private bool EqualToDTOOnlyXp(HeroDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HeroDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOPortrait(HeroDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOOnlyXp(HeroDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
