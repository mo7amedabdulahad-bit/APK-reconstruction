// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class InventoryItemAttributes : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private EffectType? _effectType;
		[ObservableValue]
		private bool? _sign;
		[ObservableValue]
		private float? _value;
		[ObservableValue]
		private string _unit;
		[ObservableValue]
		private int? _tribeId;
		[ObservableValue]
		private string _unitId;
		[ObservableValue]
		private string _descriptionTranslationKey;
		[ObservableValue]
		private GraphQLObservableList<NameValueContainer> _descriptionPlaceholders;
		[ObservableValue]
		private string _description;
		[ObservableValue]
		private string _descriptionDetails;
		[ObservableValue]
		private string _effectDescriptionDecoded;
		[ObservableValue]
		private string _descriptionDetailsDecoded;
		[ObservableValue]
		private string _effectValueDisplay;
		[ObservableValue]
		private string _effectUnitDisplay;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public EffectType? effectType { get => default; set {} }
		[ObservableValue]
		public bool? sign { get => default; set {} }
		[ObservableValue]
		public float? value { get => default; set {} }
		[ObservableValue]
		public string unit { get => default; set {} }
		[ObservableValue]
		public int? tribeId { get => default; set {} }
		[ObservableValue]
		public string unitId { get => default; set {} }
		[ObservableValue]
		public string descriptionTranslationKey { get => default; set {} }
		[ObservableValue]
		public GraphQLObservableList<NameValueContainer> descriptionPlaceholders { get => default; set {} }
		[ObservableValue]
		public string description { get => default; set {} }
		[ObservableValue]
		public string descriptionDetails { get => default; set {} }
		[ObservableValue]
		public string effectDescriptionDecoded { get => default; set {} }
		[ObservableValue]
		public string descriptionDetailsDecoded { get => default; set {} }
		[ObservableValue]
		public string effectValueDisplay { get => default; set {} }
		[ObservableValue]
		public string effectUnitDisplay { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0,
			SimplifiedAttributes = 1
		}
	
		// Constructors
		public InventoryItemAttributes() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(InventoryItemAttributesDTO dtoValue) => default;
		private bool EqualToDTOSimplifiedAttributes(InventoryItemAttributesDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(InventoryItemAttributesDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDTOSimplifiedAttributes(InventoryItemAttributesDTO newValues, bool beSilent = false) => default;
		private bool CopyValuesFromDtoListDescriptionPlaceholders(GraphQLObservableList<NameValueContainer> to, List<NameValueContainerDTO> from, int query) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _descriptionPlaceholdersNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		public void SetEffectUnitDisplay(int tribeId, int unitId) {}
		public void SetEffectUnitDisplay(int tribeId, string unitId) {}
	}
