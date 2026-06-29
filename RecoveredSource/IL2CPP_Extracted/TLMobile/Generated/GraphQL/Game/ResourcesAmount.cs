// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class ResourcesAmount : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private float _lumber;
		[ObservableValue]
		private float _clay;
		[ObservableValue]
		private float _iron;
		[ObservableValue]
		private float _crop;
		[ObservableValue]
		private float? _each;
		[ObservableValue]
		private ObservableDictionary<int, int> _amount;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public float lumber { get => default; set {} }
		[ObservableValue]
		public float clay { get => default; set {} }
		[ObservableValue]
		public float iron { get => default; set {} }
		[ObservableValue]
		public float crop { get => default; set {} }
		[ObservableValue]
		public float? each { get => default; set {} }
		[ObservableValue]
		public ObservableDictionary<int, int> amount { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public ResourcesAmount() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ResourcesAmountDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ResourcesAmountDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _amountNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		private void AmountsChanged(object o, PropertyChangedEventArgs args) {}
		private void UpdateAmountAndSum() {}
	}
