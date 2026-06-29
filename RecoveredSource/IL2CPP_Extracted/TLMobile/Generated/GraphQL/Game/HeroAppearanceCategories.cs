// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class HeroAppearanceCategories : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private GraphQLObservableList<HeroAppearanceCategory> _male;
		[ObservableValue]
		private GraphQLObservableList<HeroAppearanceCategory> _female;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public GraphQLObservableList<HeroAppearanceCategory> male { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<HeroAppearanceCategory> female { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public HeroAppearanceCategories() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(HeroAppearanceCategoriesDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(HeroAppearanceCategoriesDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListMale(GraphQLObservableList<HeroAppearanceCategory> to, List<HeroAppearanceCategoryDTO> from, int query) => default;
		private bool CopyValuesFromDtoListFemale(GraphQLObservableList<HeroAppearanceCategory> to, List<HeroAppearanceCategoryDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _maleNotify(object sender, PropertyChangedEventArgs args) {}
		private void _femaleNotify(object sender, PropertyChangedEventArgs args) {}
		public GraphQLObservableList<HeroAppearanceCategory> GetAppearance(Gender gender) => default;
	}
