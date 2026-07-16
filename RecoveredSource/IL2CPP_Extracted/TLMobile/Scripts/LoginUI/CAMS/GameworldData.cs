// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Scripts.LoginUI.CAMS
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public static class GameworldData
	{
		// Fields
		public static Dictionary<int, Domain> Domains;
		public static Dictionary<string, Locale> Locales;
		public static Dictionary<string, ServerDomain> RegionToServerDomainMap;
	
		// Nested types
		public class Domain
		{
			// Properties
			public int Id { get; set; }
			public string DomainName { get; set; }
			public string LangIso { get; set; }
			public string Region { get; set; }
			public string Name { get; set; }
	
			// Constructors
			public Domain() {}
		}
	
		public class Locale
		{
			// Properties
			public string Region { get; set; }
			public string Name { get; set; }
			public string Flag { get; set; }
			public string Language { get; set; }
			public string LocaleCode { get; set; }
			public string LangNative { get; set; }
			public string LangEnglish { get; set; }
			public string CountryNative { get; set; }
			public string CountryEnglish { get; set; }
			public string Direction { get; set; }
			public string HrefLang { get; set; }
			public string IntlAlias { get; set; }
	
			// Constructors
			public Locale() {}
		}
	
		// Constructors
		static GameworldData() {}
	
		// Methods
		public static ServerDomain ConvertRegionToServerDomain(string region) => default;
	}
