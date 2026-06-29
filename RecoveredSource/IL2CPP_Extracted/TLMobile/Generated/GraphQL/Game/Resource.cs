// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Resource : GraphQLServerObject
	{
		// Fields
		[ObservableValue]
		private int _lumberProduction;
		[ObservableValue]
		private int _clayProduction;
		[ObservableValue]
		private int _ironProduction;
		[ObservableValue]
		private int _cropProduction;
		[ObservableValue]
		private int _netCropProduction;
		[ObservableValue]
		private int _freeCrop;
		[ObservableValue]
		private int _cropBalance;
		[ObservableValue]
		private float _lumberStock;
		[ObservableValue]
		private float _clayStock;
		[ObservableValue]
		private float _ironStock;
		[ObservableValue]
		private float _cropStock;
		[ObservableValue]
		private int _maxStorageCapacity;
		[ObservableValue]
		private int _maxCropStorageCapacity;
		[ObservableValue]
		private ObservableList<int> _resourcesProduction;
		[ObservableValue]
		private ObservableList<int> _resourcesStorageCapacity;
		[ObservableValue]
		private ObservableList<float> _resourcesStock;
		[ObservableValue]
		private ResourceAmounts _resourceAmounts;
		[ObservableValue]
		private ResourceAmounts _productionAmounts;
		[ObservableValue]
		private ObservableList<AdditionalResourceInfo> _additionalInfo;
		[ObservableValue]
		private int? _secondsUntilEmptyStorage;
	
		// Properties
		public override GraphQLServerIdentifier ServerIdentifier { get => default; }
		[ObservableValue]
		public int lumberProduction { get => default; set {} }
		[ObservableValue]
		public int clayProduction { get => default; set {} }
		[ObservableValue]
		public int ironProduction { get => default; set {} }
		[ObservableValue]
		public int cropProduction { get => default; set {} }
		[ObservableValue]
		public int netCropProduction { get => default; set {} }
		[ObservableValue]
		public int freeCrop { get => default; set {} }
		[ObservableValue]
		public int cropBalance { get => default; set {} }
		[ObservableValue]
		public float lumberStock { get => default; set {} }
		[ObservableValue]
		public float clayStock { get => default; set {} }
		[ObservableValue]
		public float ironStock { get => default; set {} }
		[ObservableValue]
		public float cropStock { get => default; set {} }
		[ObservableValue]
		public int maxStorageCapacity { get => default; set {} }
		[ObservableValue]
		public int maxCropStorageCapacity { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> resourcesProduction { get => default; set {} }
		[ObservableValue]
		public ObservableList<int> resourcesStorageCapacity { get => default; set {} }
		[ObservableValue]
		public ObservableList<float> resourcesStock { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts resourceAmounts { get => default; set {} }
		[ObservableValue]
		public ResourceAmounts productionAmounts { get => default; set {} }
		[ObservableValue]
		public ObservableList<AdditionalResourceInfo> additionalInfo { get => default; set {} }
		[ObservableValue]
		public int? secondsUntilEmptyStorage { get => default; set {} }
	
		// Nested types
		public enum Query
		{
			All = 0
		}
	
		// Constructors
		public Resource() {}
	
		// Methods
		public override string GetGraphQLBody(int query) => default;
		public override object GetDTOObject(object dtoObject) => default;
		public override System.Type GetDtoType() => default;
		public override GraphQLServerObject GetNewObject(object dtoObject, int query) => default;
		public override bool EqualToDTO(object dtoValue, int query = 0) => default;
		public bool EqualToDTO(object dtoValue, Query query = Query.All) => default;
		private bool EqualToDTOAll(ResourceDTO dtoValue) => default;
		public override bool CopyValuesFromDTO(object newValues, int query = 0, bool beSilent = false) => default;
		public bool CopyValuesFromDTO(object newValues, Query query = Query.All, bool beSilent = false) => default;
		private bool CopyValuesFromDTOAll(ResourceDTO newValues, bool beSilent = false) => default;
		public override void ParseDtoObjectsList(object rawDtoObj, Action<List<object>> resultCallback) {}
		public new string ToString() => default;
		private void _resourcesProductionNotify(object sender, PropertyChangedEventArgs args) {}
		private void _resourcesStorageCapacityNotify(object sender, PropertyChangedEventArgs args) {}
		private void _resourcesStockNotify(object sender, PropertyChangedEventArgs args) {}
		private void _additionalInfoNotify(object sender, PropertyChangedEventArgs args) {}
		public override void AfterServerDataCallback() {}
		public void UpdateValues(bool resetFirstCalculation) {}
		public GeneralErrorType GetErrorType(ResourceAmounts costAmounts, int cropUsage = 0) => default;
		public ResourceAmounts GetDifferenceToStock(ResourceAmounts costAmounts) => default;
		public ResourceAmounts GetDifferenceToCapacity(ResourceAmounts costAmounts) => default;
		public static int CalculateSecondsUntilEmptyStorage(float storageAmount, int cropBalancePerHour) => default;
	}
