// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.RateThisApp
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class RTAConfig : ScriptableObject
	{
		// Fields
		public ConfigData Data;
	
		// Nested types
		[Serializable]
		public class ConfigData
		{
			// Fields
			public bool IsEnabled;
			public string[] EnabledTriggerLocations;
			public Vector2Int[] EnabledThresholdsForAttributeLocation;
			public int MinDaysSinceInstall;
			public int MinSessionsSinceInstall;
			public float MinBatteryPercentage;
			public string MinAllowedBuild;
			public float MinCurrentSessionLength;
			public int MinHeroLevel;
			public bool EnableIntermediatePopup;
			public bool IntermediatePopupRedirectToHelpMenu;
			public string IntermediatePopupRedirectURL;
	
			// Constructors
			public ConfigData() {}
		}
	
		// Constructors
		public RTAConfig() {}
	
		// Methods
		public static RTAConfig FromJson(string json) => default;
		public void LoadFromJson(string json) {}
		public string ToJson() => default;
		public override string ToString() => default;
	}
