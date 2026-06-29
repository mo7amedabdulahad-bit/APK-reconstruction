// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.TGFrameworkExtensions.TextFilters
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TextFilterVillageLink : TextFilterClickableBase
	{
		// Fields
		private Village fetchedVillageObject;
		private TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinate;
	
		// Properties
		public override int Id { get => default; }
		public override string ShortName { get => default; }
		public override string Name { get => default; }
		public override string OutputWhenNull { get => default; }
	
		// Constructors
		public TextFilterVillageLink() {}
	
		// Methods
		protected override string GetOutputString(int villageId) => default;
		private void OnVillageError(GraphQLServerError obj) {}
		private void UpdateVillageData() {}
		protected override void ClickBehaviour() {}
	}
