// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.Extensions
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class BuildingExtentions
	{
		// Nested types
		private class BuildingInfoDescriptionContent
		{
			// Fields
			public Dictionary<string, string> Replacements;
			public string TranslationKey;
	
			// Constructors
			public BuildingInfoDescriptionContent() {} // Dummy constructor
			public BuildingInfoDescriptionContent(string translationKey, Dictionary<string, string> replacements = null) {}
		}
	
		// Extension methods
		public static ObservableList<string> GetBuildingInfoDescription(this Building building) => default;
		public static DetailWindows GetDetailWindowID(this Building building) => default;
	}
