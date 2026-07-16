// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroAppearanceCategory : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private CategoryCode _code;
		[ObservableValue]
		private GraphQLObservableList<HeroAppearanceColor> _colors;
		[ObservableValue]
		private GraphQLObservableList<HeroAppearanceOption> _options;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public CategoryCode code { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<HeroAppearanceColor> colors { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<HeroAppearanceOption> options { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public HeroAppearanceCategory() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HeroAppearanceCategoryDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HeroAppearanceCategoryDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListColors(GraphQLObservableList<HeroAppearanceColor> to, List<HeroAppearanceColorDTO> from, int query) => default;
		private bool CopyValuesFromDtoListOptions(GraphQLObservableList<HeroAppearanceOption> to, List<HeroAppearanceOptionDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _colorsNotify(object sender, PropertyChangedEventArgs args) {}
		private void _optionsNotify(object sender, PropertyChangedEventArgs args) {}
	}
