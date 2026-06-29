// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class AllianceBanner : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _pattern;
		[ObservableValue]
		private int _baseForm;
		[ObservableValue]
		private string _baseColor;
		[ObservableValue]
		private int _backSymbol;
		[ObservableValue]
		private string _borderColor;
		[ObservableValue]
		private int _frontSymbol;
		[ObservableValue]
		private string _primaryColor;
		[ObservableValue]
		private string _secondaryColor;
		[ObservableValue]
		private string _backSymbolColor;
		[ObservableValue]
		private string _frontSymbolColor;
		[ObservableValue]
		private UnityEngine.Color _unityBaseColor;
		[ObservableValue]
		private UnityEngine.Color _unityBorderColor;
		[ObservableValue]
		private UnityEngine.Color _unityPrimaryColor;
		[ObservableValue]
		private UnityEngine.Color _unitySecondaryColor;
		[ObservableValue]
		private UnityEngine.Color _unityBackSymbolColor;
		[ObservableValue]
		private UnityEngine.Color _unityFrontSymbolColor;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int pattern { get => default; set {} }
		[ObservableValue]
		public int baseForm { get => default; set {} }
		[ObservableValue]
		public string baseColor { get => default; set {} }
		[ObservableValue]
		public int backSymbol { get => default; set {} }
		[ObservableValue]
		public string borderColor { get => default; set {} }
		[ObservableValue]
		public int frontSymbol { get => default; set {} }
		[ObservableValue]
		public string primaryColor { get => default; set {} }
		[ObservableValue]
		public string secondaryColor { get => default; set {} }
		[ObservableValue]
		public string backSymbolColor { get => default; set {} }
		[ObservableValue]
		public string frontSymbolColor { get => default; set {} }
		[ObservableValue]
		public UnityEngine.Color unityBaseColor { get => default; set {} }
		[ObservableValue]
		public UnityEngine.Color unityBorderColor { get => default; set {} }
		[ObservableValue]
		public UnityEngine.Color unityPrimaryColor { get => default; set {} }
		[ObservableValue]
		public UnityEngine.Color unitySecondaryColor { get => default; set {} }
		[ObservableValue]
		public UnityEngine.Color unityBackSymbolColor { get => default; set {} }
		[ObservableValue]
		public UnityEngine.Color unityFrontSymbolColor { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public AllianceBanner() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(AllianceBannerDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(AllianceBannerDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		public override void AfterServerDataCallback() {}
	}
