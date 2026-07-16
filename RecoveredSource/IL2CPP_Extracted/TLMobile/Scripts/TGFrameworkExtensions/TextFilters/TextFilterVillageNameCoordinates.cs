// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.TGFrameworkExtensions.TextFilters
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class TextFilterVillageNameCoordinates : TextFilterClickableBase
	{
		// Fields
		private int savedId;
		private TLMobile.Generated.GraphQL.Game.Coordinate villageCoordinate;
		private Village villageToFilter;
	
		// Properties
		public override int Id { get => default; }
		public override string ShortName { get => default; }
		public override string Name { get => default; }
	
		// Constructors
		public TextFilterVillageNameCoordinates() {}
	
		// Methods
		protected override string GetOutputString(int id) => default;
		private string GetStringText(string name, int x, int y) => default;
		private void UpdateVillageData() {}
		private void OnVillageError(GraphQLServerError obj) {}
		protected override void ClickBehaviour() {}
	}
